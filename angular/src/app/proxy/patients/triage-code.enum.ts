import { mapEnumToOptions } from '@abp/ng.core';

export enum TriageCode {
  None = 0,
  Green = 1,
  Yellow = 2,
  Red = 3,
}

export const triageCodeOptions = mapEnumToOptions(TriageCode);
