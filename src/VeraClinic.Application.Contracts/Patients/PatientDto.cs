using System;
using Volo.Abp.Application.Dtos;

namespace VeraClinic.Patients;

public class PatientDto : AuditedEntityDto<Guid>
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string IdentityNumber { get; set; }
    public string? Complaint { get; set; } // Gözlem butonu için eklendi
    public TriageCode CurrentTriageStatus { get; set; }
    
    // İsimleri CreateUpdatePatientDto ile aynı (veya çok benzer) yapıyoruz
    public int OxygenSaturation { get; set; } 
    public double BodyTemperature { get; set; }
}

public class CreateUpdatePatientDto
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string IdentityNumber { get; set; }
    public string? Complaint { get; set; }
    public int OxygenSaturation { get; set; } 
    public double BodyTemperature { get; set; }
}