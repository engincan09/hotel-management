import { YeniPersonelComponent } from './yeni-personel/yeni-personel.component';
import { TumPersonellerComponent } from './tum-personeller/tum-personeller.component';

import { Routes } from '@angular/router';
import { AuthGuardService } from 'src/app/shared/services/auth-guard.service';


export const PersonelIslemleriRoutes: Routes = [
  {
    path: 'tum-personeller',
    canActivate: [AuthGuardService],
    data: { pageId: 8 },
    component: TumPersonellerComponent,
  },
  {
    path: 'yeni-personel',
    canActivate: [AuthGuardService],
    data: { pageId: 9 },
    component: YeniPersonelComponent,
  },
  {
    path: 'yeni-personel/:id',
    canActivate: [AuthGuardService],
    data: { pageId: 9 },
    component: YeniPersonelComponent,
  },
];
