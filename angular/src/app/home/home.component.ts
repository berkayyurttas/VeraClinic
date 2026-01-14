import { AuthService } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core'; 
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { 
  ThemeSharedModule, 
  ToasterService, 
  ConfirmationService 
} from '@abp/ng.theme.shared'; 
import { CommonModule } from '@angular/common';

// ✅ jsPDF importu
import { jsPDF } from 'jspdf';

// Proxy yolları
import { PatientService } from '../proxy/services/patient.service'; 

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, ThemeSharedModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  patients: any[] = [];
  selectedPatient: any = {};
  
  isModalOpen = false;
  isViewModalOpen = false; 
  patientForm: FormGroup;

  totalPatients = 0;
  criticalCount = 0;   
  observationCount = 0; 
  stableCount = 0;     

  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated;
  }

  constructor(
    private patientService: PatientService,
    private authService: AuthService,
    private fb: FormBuilder,
    private toaster: ToasterService,
    private confirmation: ConfirmationService 
  ) {}

  ngOnInit() {
    this.buildForm();
    if (this.hasLoggedIn) {
      this.getPatients();
    }
  }

  buildForm() {
    this.patientForm = this.fb.group({
      name: ['', Validators.required],
      surname: ['', Validators.required],
      identityNumber: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(11)]],
      complaint: [''],
      oxygenSaturation: [95, [Validators.required, Validators.min(0), Validators.max(100)]],
      bodyTemperature: [36.5, [Validators.required, Validators.min(30), Validators.max(45)]]
    });
  }

  getPatients() {
    this.patientService.getList().subscribe((result) => {
      this.patients = (result as any[]).sort((a, b) => (b.currentTriageStatus || 0) - (a.currentTriageStatus || 0));
      this.calculateStats();
    });
  }

  calculateStats() {
    this.totalPatients = this.patients.length;
    this.criticalCount = this.patients.filter(p => p.currentTriageStatus === 3).length;
    this.observationCount = this.patients.filter(p => p.currentTriageStatus === 2).length;
    this.stableCount = this.patients.filter(p => p.currentTriageStatus === 1).length;
  }

  openModal() {
    this.patientForm.reset({ oxygenSaturation: 95, bodyTemperature: 36.5 });
    this.isModalOpen = true;
  }

  save() {
    if (this.patientForm.invalid) return;

    this.patientService.create(this.patientForm.value).subscribe((result) => {
      this.isModalOpen = false;
      this.getPatients(); 

      if (result.currentTriageStatus === 3) {
        this.toaster.error("ACİL MÜDAHALE GEREKLİ!", "Kritik Hasta Girişi");
      } else {
        this.toaster.success("Hasta başarıyla kayıt edildi.");
      }
    });
  }

  dischargePatient(id: string) {
    if (window.confirm("Bu hastayı taburcu etmek istediğinize emin misiniz?")) {
      this.patientService.delete(id).subscribe({
        next: () => {
          this.toaster.success('Hasta başarıyla taburcu edildi.');
          this.getPatients(); 
        },
        error: () => this.toaster.error("Taburcu işlemi başarısız oldu.")
      });
    }
  }

  viewPatient(patient: any) {
    this.selectedPatient = patient;
    this.isViewModalOpen = true;
  }

  /**
   * ✅ KESİN ÇÖZÜM: 180 dakikalık farkı yok eden fonksiyon
   */
  getWaitingTime(creationTime: string): number {
    if (!creationTime) return 0;
    
    const now = new Date();
    const created = new Date(creationTime);

    // getTimezoneOffset() dakika cinsinden farkı verir (Türkiye için -180 döner)
    // Bu iki ofset arasındaki farkı milisaniyeye çevirip gerçek farktan çıkarıyoruz
    const offsetMs = (now.getTimezoneOffset() - created.getTimezoneOffset()) * 60 * 1000;
    
    let diffMs = now.getTime() - created.getTime() - offsetMs;

    // Eğer backend UTC (0) gönderiyor ve biz GMT+3'te hesaplıyorsak 
    // bazen tarayıcı hala 180 dk ekler. Bunu manuel kontrolle düzeltiyoruz:
    const threeHoursInMs = 3 * 60 * 60 * 1000;
    if (diffMs >= threeHoursInMs) {
        diffMs -= threeHoursInMs;
    }

    const minutes = Math.floor(diffMs / 60000); 
    return minutes < 0 ? 0 : minutes;
  }

  getWaitColorClass(creationTime: string): string {
    const minutes = this.getWaitingTime(creationTime);
    if (minutes >= 30) return 'text-danger fw-bold blink'; 
    if (minutes >= 15) return 'text-warning fw-bold';      
    return 'text-success';                                
  }

  downloadReport(patient: any) {
    const doc = new jsPDF();
    
    doc.setFontSize(22);
    doc.setTextColor(44, 62, 80); 
    doc.text('VERACLINIC TRIYAJ RAPORU', 105, 20, { align: 'center' });
    
    doc.setLineWidth(0.5);
    doc.line(20, 25, 190, 25);
    
    doc.setFontSize(12);
    doc.setTextColor(0, 0, 0);
    doc.text(`Hasta: ${patient.name || ''} ${patient.surname || ''}`, 20, 40);
    doc.text(`TC: ${patient.identityNumber || ''}`, 20, 50);
    
    // PDF çıktısında saati doğru göstermek için
    const waitMins = this.getWaitingTime(patient.creationTime);
    doc.text(`Giris Saati: ${new Date(patient.creationTime).toLocaleString()}`, 20, 60);
    doc.text(`Toplam Bekleme: ${waitMins} dakika`, 20, 65);
    
    doc.setFillColor(245, 247, 250);
    doc.rect(20, 75, 170, 40, 'F');
    doc.text('TIBBI BULGULAR', 25, 85);
    doc.text(`Oksijen Saturasyonu: %${patient.oxygenSaturation || 0}`, 25, 95);
    doc.text(`Vucut Isisi: ${patient.bodyTemperature || 0} C`, 25, 105);
    
    doc.text('HASTA SIKAYETI:', 20, 125);
    const complaintText = patient.complaint || 'Sikayet belirtilmedi.';
    const splitComplaint = doc.splitTextToSize(complaintText, 160);
    doc.text(splitComplaint, 20, 135);
    
    doc.setFontSize(14);
    doc.text(`SONUC: ${this.getTriageText(patient.currentTriageStatus)}`, 20, 165);
    
    doc.save(`Rapor_${patient.name}.pdf`);
  }

  getTriageBadgeClass(status: number) {
    switch (status) {
      case 3: return 'bg-danger';
      case 2: return 'bg-warning text-dark';
      case 1: return 'bg-success';
      default: return 'bg-secondary';
    }
  }

  getTriageText(status: number) {
    switch (status) {
      case 3: return 'ACİL (KRİTİK)';
      case 2: return 'GÖZLEM';
      case 1: return 'STABİL';
      default: return 'BİLİNMİYOR';
    }
  }

  login() {
    this.authService.navigateToLogin();
  }
}