import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideHttpClient, withInterceptorsFromDi, withJsonpSupport } from '@angular/common/http';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';

export const appConfig: ApplicationConfig = {
  providers: 
  [
    provideHttpClient(withInterceptorsFromDi()), provideAnimationsAsync()
  ]
};
