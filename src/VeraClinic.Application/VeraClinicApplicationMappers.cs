using Riok.Mapperly.Abstractions;
using VeraClinic.Patients;
using System.Collections.Generic; // Bunu ekledik

namespace VeraClinic;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.None)]
public partial class VeraClinicApplicationMappers
{
    public partial PatientDto MapToDto(Patient patient);
    
    public partial void MapToEntity(CreateUpdatePatientDto input, Patient patient);

    // Yeni eklediğimiz liste dönüştürücü metodumuz
    public partial List<PatientDto> MapToDtoList(List<Patient> patients); 
} // Sınıf parantezi burada kapanmalı