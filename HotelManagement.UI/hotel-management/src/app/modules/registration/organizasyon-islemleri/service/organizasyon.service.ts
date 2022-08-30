import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';
import { HttpService } from 'src/app/shared/services/http.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class OrganizasyonService {
  constructor(private http: HttpService, private router: Router) {}

  getAllOrganizasyon() {
    return this.http
      .get(environment.api, {
        url: 'Organizasyon/GetAllOrganizasyon',
        version: '1.0',
      })
      .pipe(
        map((data) => {
          return data;
        })
      );
  }
  getAllOrganizasyoneDetailTable() {
    return this.http
      .get(environment.api, {
        url: 'Organizasyon/GetAllOrganizasyoneDetailTable',
        version: '1.0',
      })
      .pipe(
        map((data) => {
          return data;
        })
      );
  }
  postOrganizasyon(model) {
    return this.http
      .post(environment.api, {
        url: 'Organizasyon/PostOrganizasyon/',
        version: '1.0',
      },model)
      .pipe(
        map((data) => {
          return data;
        })
      );
  }
  updateOrganizasyon(model) {
    return this.http
      .post(environment.api, {
        url: 'Organizasyon/UpdateOrganizasyon/',
        version: '1.0',
      },model)
      .pipe(
        map((data) => {
          return data;
        })
      );
  }
  deleteOrganizasyon(id) {
    return this.http
      .get(environment.api, {
        url: 'Organizasyon/DeleteOrganizasyon/'+id,
        version: '1.0',
      })
      .pipe(
        map((data) => {
          return data;
        })
      );
  }

  getOrganizasyon(id:number){
    return this.http
    .get(environment.api, {
      url: 'Organizasyon/GetById/'+id,
      version: '1.0',
    })
    .pipe(
      map((data) => {
        return data;
      })
    );
  }
}
