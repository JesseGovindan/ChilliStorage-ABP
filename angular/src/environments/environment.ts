 import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44313/',
  redirectUri: baseUrl,
  clientId: 'ChilliStorage_App',
  responseType: 'code',
  scope: 'offline_access ChilliStorage',
  requireHttps: true,
};

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'ChilliStorage',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44313',
      rootNamespace: 'ChilliStorage',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
} as Environment;
