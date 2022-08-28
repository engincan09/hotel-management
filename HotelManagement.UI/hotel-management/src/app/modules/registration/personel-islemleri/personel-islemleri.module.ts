import { PersonelIslemleriRoutes } from './personel-islemleri.routing';
import { YeniPersonelComponent } from './yeni-personel/yeni-personel.component';
import { TumPersonellerComponent } from './tum-personeller/tum-personeller.component';
import { ToastrModule } from 'ngx-toastr';
import { SharedModule } from './../../../shared/shared.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { DashboardLayoutModule } from 'src/app/shared/layouts/dashboard-layout/dashboard-layout.module';

@NgModule({
  declarations: [TumPersonellerComponent,YeniPersonelComponent],
  imports: [
    CommonModule,SharedModule,
    RouterModule.forChild(PersonelIslemleriRoutes),
    DashboardLayoutModule
  ]
})
export class PersonelIslemleriModule { }

