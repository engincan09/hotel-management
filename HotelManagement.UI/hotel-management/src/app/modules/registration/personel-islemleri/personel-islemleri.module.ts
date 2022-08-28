import { PersonelIslemleriRoutes } from './personel-islemleri.routing';
import { ToastrModule } from 'ngx-toastr';
import { SharedModule } from './../../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DashboardLayoutModule } from 'src/app/shared/layouts/dashboard-layout/dashboard-layout.module';
import { YeniPersonelComponent } from './yeni-personel/yeni-personel.component';
import { TumPersonellerComponent } from './tum-personeller/tum-personeller.component';

@NgModule({
  declarations: [TumPersonellerComponent,YeniPersonelComponent],
  imports: [
    CommonModule,SharedModule,
    RouterModule.forChild(PersonelIslemleriRoutes),
    DashboardLayoutModule
  ]
})
export class PersonelIslemleriModule { }

