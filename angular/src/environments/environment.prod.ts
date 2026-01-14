import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4299';

export const environment = {
  production: false,
  application: {
    baseUrl: baseUrl + '/',
    name: 'VeraClinic',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44399/',  // Backend loglarında HTTPS olduğu için burası HTTPS olmalı
    redirectUri: baseUrl + '/',
    clientId: 'VeraClinic_App',
    responseType: 'code',
    scope: 'offline_access VeraClinic',
    requireHttps: true,                 // Issuer HTTPS olduğu için burası true olmalı
  },
  apis: {
    default: {
      url: 'https://localhost:44399',    // API istekleri HTTPS portuna gitmeli
      rootNamespace: 'VeraClinic',
    },
  },
} as Environment;