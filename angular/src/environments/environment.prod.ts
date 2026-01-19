export const environment = {
  production: false,
  application: {
    baseUrl: 'http://localhost:4299/',
    name: 'VeraClinic',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'http://localhost:44398/', // Burası 44398 ve http olmalı
    redirectUri: 'http://localhost:4299/',
    clientId: 'VeraClinic_App',
    responseType: 'code',
    scope: 'offline_access VeraClinic',
    showDebugInformation: true,
  },
  apis: {
    default: {
      url: 'http://localhost:44398', // Burası 44398 ve http olmalı
      rootNamespace: 'VeraClinic',
    },
  },
};