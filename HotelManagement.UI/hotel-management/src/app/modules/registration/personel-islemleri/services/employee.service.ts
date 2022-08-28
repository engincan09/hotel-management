import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { map } from 'rxjs/operators';
import { HttpService } from 'src/app/shared/services/http.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  constructor(private http: HttpService, private router: Router) {}

  getAllEmployee() {
    return this.http
      .get(environment.api, {
        url: 'Employee/GetAllEmployee',
        version: '1.0',
      })
      .pipe(
        map((data) => {
          return data;
        })
      );
  }

  getAllEmployeeDetailTable() {
    return this.http
      .get(environment.api, {
        url: 'Employee/GetAllEmployeeDetailTable',
        version: '1.0',
      })
      .pipe(
        map((data) => {
          return data;
        })
      );
  }
  postEmployee(model) {
    return this.http
      .post(environment.api, {
        url: 'Employee/PostEmployee/',
        version: '1.0',
      },model)
      .pipe(
        map((data) => {
          return data;
        })
      );
  }
  updateEmployee(model) {
    return this.http
      .post(environment.api, {
        url: 'Employee/UpdateEmployee/',
        version: '1.0',
      },model)
      .pipe(
        map((data) => {
          return data;
        })
      );
  }
  deleteEmployee(id) {
    return this.http
      .get(environment.api, {
        url: 'Employee/DeleteEmployee/'+id,
        version: '1.0',
      })
      .pipe(
        map((data) => {
          return data;
        })
      );
  }

  getEmployee(id:number){
    return this.http
    .get(environment.api, {
      url: 'Employee/GetById/'+id,
      version: '1.0',
    })
    .pipe(
      map((data) => {
        return data;
      })
    );
  }
}
