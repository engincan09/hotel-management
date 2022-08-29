import { SharedModule } from './../../shared/shared.module';
import { OrganizasyonSemasiComponent } from './organizasyon-islemleri/organizasyon-semasi/organizasyon-semasi.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DashboardLayoutModule } from 'src/app/shared/layouts/dashboard-layout/dashboard-layout.module';
import { RegistrationRoutes } from './registration.routing';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(RegistrationRoutes),
    DashboardLayoutModule,
    SharedModule
  ]
})
export class RegistrationModule { }

