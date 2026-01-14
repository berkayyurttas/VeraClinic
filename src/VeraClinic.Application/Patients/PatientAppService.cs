using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeraClinic.Patients;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace VeraClinic.Services;

public class PatientAppService : ApplicationService
{
    private readonly IRepository<Patient, Guid> _patientRepository;

    public PatientAppService(IRepository<Patient, Guid> patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<PatientDto> CreateAsync(CreateUpdatePatientDto input)
    {
        var patient = new Patient(GuidGenerator.Create())
        {
            Name = input.Name,
            Surname = input.Surname,
            IdentityNumber = input.IdentityNumber,
            Complaint = input.Complaint,
            LastOxygenSaturation = input.OxygenSaturation,
            LastBodyTemperature = input.BodyTemperature
        };

        SetTriageStatus(patient, input.OxygenSaturation, input.BodyTemperature);

        var insertedPatient = await _patientRepository.InsertAsync(patient, autoSave: true);
        
        return MapToDtoManual(insertedPatient);
    }

    public async Task<List<PatientDto>> GetListAsync()
    {
        var patients = await _patientRepository.GetListAsync();
        var dtos = new List<PatientDto>();
        foreach (var patient in patients)
        {
            dtos.Add(MapToDtoManual(patient));
        }
        return dtos;
    }

    public async Task<PatientDto> GetAsync(Guid id)
    {
        var patient = await _patientRepository.GetAsync(id);
        return MapToDtoManual(patient);
    }

    public async Task<PatientDto> UpdateAsync(Guid id, CreateUpdatePatientDto input)
    {
        var patient = await _patientRepository.GetAsync(id);

        patient.Name = input.Name;
        patient.Surname = input.Surname;
        patient.IdentityNumber = input.IdentityNumber;
        patient.Complaint = input.Complaint;
        patient.LastOxygenSaturation = input.OxygenSaturation;
        patient.LastBodyTemperature = input.BodyTemperature;

        SetTriageStatus(patient, input.OxygenSaturation, input.BodyTemperature);

        await _patientRepository.UpdateAsync(patient, autoSave: true);
        return MapToDtoManual(patient);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _patientRepository.DeleteAsync(id);
    }

    // ✅ YARDIMCI MAPPER: Veriyi DTO'ya eksiksiz aktarır
    private PatientDto MapToDtoManual(Patient patient)
    {
        return new PatientDto
        {
            Id = patient.Id,
            Name = patient.Name,
            Surname = patient.Surname,
            IdentityNumber = patient.IdentityNumber,
            Complaint = patient.Complaint,
            CurrentTriageStatus = patient.CurrentTriageStatus,
            // ⏱️ Bekleme süresi hesaplaması için bu alan ŞART:
            CreationTime = patient.CreationTime, 
            // Eğer veritabanında null ise varsayılan değerleri basar:
            OxygenSaturation = patient.LastOxygenSaturation ?? 0, 
            BodyTemperature = patient.LastBodyTemperature ?? 36.5
        };
    }

    private void SetTriageStatus(Patient patient, int oxygen, double temperature)
    {
        // Triyaj mantığı (Kritik -> Gözlem -> Stabil)
        if (oxygen < 90 || temperature >= 40)
            patient.CurrentTriageStatus = TriageCode.Red;
        else if (oxygen < 94 || temperature >= 38.5)
            patient.CurrentTriageStatus = TriageCode.Yellow;
        else
            patient.CurrentTriageStatus = TriageCode.Green;
    }
}