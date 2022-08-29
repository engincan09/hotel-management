import { YeniBirimComponent } from './yeni-birim/yeni-birim.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DashboardLayoutModule } from 'src/app/shared/layouts/dashboard-layout/dashboard-layout.module';
import { OrganizasyonSemasiComponent } from './organizasyon-semasi/organizasyon-semasi.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { OrganizasyonRoutes } from './organizasyon.routing';


@NgModule({
  declarations: [OrganizasyonSemasiComponent,YeniBirimComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(OrganizasyonRoutes),
    DashboardLayoutModule,
    SharedModule
  ]
})
export class OrganizasyonModule { }

