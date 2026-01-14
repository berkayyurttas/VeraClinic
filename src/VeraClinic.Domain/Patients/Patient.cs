using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace VeraClinic.Patients;

public class Patient : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string IdentityNumber { get; set; } = string.Empty;
    public string? Complaint { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    
    public TriageCode CurrentTriageStatus { get; set; }

    // ✅ Soru işareti (?) ekleyerek nullable yaptık. 
    // Bu sayede AppService içindeki "?? 0" kontrolü hata vermeyecek.
    public double? LastBodyTemperature { get; set; } 
    public int? LastOxygenSaturation { get; set; }

    public Patient() 
    { 
        CurrentTriageStatus = TriageCode.Green;
    }

    public Patient(Guid id) : base(id) 
    { 
        CurrentTriageStatus = TriageCode.Green;
    }
}