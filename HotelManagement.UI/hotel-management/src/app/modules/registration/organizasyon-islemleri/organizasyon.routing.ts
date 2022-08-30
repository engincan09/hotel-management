import { YeniBirimComponent } from './yeni-birim/yeni-birim.component';
import { Routes } from '@angular/router';
import { AuthGuardService } from 'src/app/shared/services/auth-guard.service';
import { OrganizasyonSemasiComponent } from './organizasyon-semasi/organizasyon-semasi.component';


export const OrganizasyonRoutes: Routes = [
  {
    path: 'organizasyon-semasi',
    canActivate: [AuthGuardService],
    data: { pageId: 11 },
    component: OrganizasyonSemasiComponent,
  },
  {
    path: 'yeni-birim',
    canActivate: [AuthGuardService],
    data: { pageId: 12 },
    component: YeniBirimComponent,
  },
  {
    path: 'yeni-birim/:id',
    canActivate: [AuthGuardService],
    data: { pageId: 12 },
    component: YeniBirimComponent,
  },
];
