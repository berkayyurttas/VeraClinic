import type { AuditedEntityDto } from '@abp/ng.core';
import type { TriageCode } from './triage-code.enum';

export interface CreateUpdatePatientDto {
  name: string;
  surname: string;
  identityNumber: string;
  complaint?: string | null;
  oxygenSaturation?: number;
  bodyTemperature?: number;
}

export interface PatientDto extends AuditedEntityDto<string> {
  name: string;
  surname: string;
  identityNumber: string;
  complaint?: string | null;
  currentTriageStatus?: TriageCode;
  oxygenSaturation?: number;
  bodyTemperature?: number;
}
