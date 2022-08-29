import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CustomvalidationService } from 'src/app/shared/services/custom-validation.service';
import { environment } from 'src/environments/environment';
import { UserService } from '../../kullanici-islemleri/services/user.service';
import { Employee } from '../models/employee.model';
import { EmployeeService } from '../services/employee.service';
declare var $;
@Component({
  selector: 'app-yeni-personel',
  templateUrl: './yeni-personel.component.html',
  styleUrls: ['./yeni-personel.component.scss']
})
export class YeniPersonelComponent implements OnInit {
  employeeForm: FormGroup;
  employee: Employee = new Employee();
  employeeId: number;
  environment = environment;
  submitted = false;
  userDataSource;
  constructor( private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private employeeService: EmployeeService,
    private activatedRoute: ActivatedRoute,
    private route: ActivatedRoute,
    private router: Router,
    private customValidator: CustomvalidationService,
    private userService:UserService) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe((params) => {
      if (params['id']) {
        this.employeeId = parseInt(params['id']);
        this.getEmployee(this.employeeId);
        this.createEmployeeUpdateForm();
      } else {
        this.createEmployeeAddForm();
      }
    });
    this.getUserDataSource();
  }

  getUserDataSource(){
    this.userService.getAllUsersForSelection().subscribe((res)=>{this.userDataSource = res.data;})
  }

  get formControl() {
    return this.employeeForm.controls;
  }

  saveEmployee() {
    this.submitted = true;
    if (this.employeeForm.valid) {
      let model: Employee = Object.assign({}, this.employeeForm.value);
      console.log(model,"model");
      
      if (this.employee.id) {
        this.updateEmployee(model);
      } else {
        this.addEmployee(model);
      }
    } else {
      this.toastr.error('Zorunlu alanları kontrol ediniz!', 'Hata');
    }
  }

  addEmployee(model){
    this.employeeService.postEmployee(model).subscribe(
      (res) => {
        if (res.success) {
          this.toastr.success(res.messages, 'Başarılı!');
          this.routeChange();
        }else{
          this.toastr.error(res.messages, 'Hata!');
        }
      },     
    );
  }
  updateEmployee(model) {
    this.employeeService.updateEmployee(model).subscribe(
      (res) => {
        if (res.success) {
          this.toastr.success(res.messages, 'Başarılı!');
          this.routeChange();
        }else{
          this.toastr.error(res.messages, 'Hata!');
        }
      }
    );
  }

  getEmployee(id:number){
    this.employeeService.getEmployee(id).subscribe((res) => {
      this.employee = res.data;
    });
  }


  createEmployeeAddForm(){
    this.employeeForm = this.formBuilder.group({
      userId: ['', Validators.required],
      employeeType: ['', Validators.required],
      name: ['', Validators.required],
      surname: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      email: ['', Validators.required],
      jobStartDate: ['', Validators.required],
    });
  }

  createEmployeeUpdateForm(){
    this.employeeForm = this.formBuilder.group({
      userId: ['', Validators.required],
      employeeType: [''],
      name: ['', Validators.required],
      surname: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      email: ['', Validators.required],
      password: [''],
      jobStartDate: ['', Validators.required],
      id:this.employeeId
    });
  }

  routeChange(){
    this.router.navigate(['/yonetim/idari-isler/personel-islemleri/tum-personeller']);
  }

  changeType(e){
    this.typeName?.setValue(e.target.value, {
      onlySelf: true,
    });    
  }

  get typeName() {
    return this.employeeForm.get('employeeType');
  }


  changeUser(e){
    if (e.target.value) {
      this.userId?.setValue(Number(e.target.value), {
        onlySelf: true,
      });   
      this.userService.getUser(e.target.value).subscribe((res)=>{
        this.employeeForm.controls.name.setValue(res.data.name);
        this.employeeForm.controls.surname.setValue(res.data.surname);
        this.employeeForm.controls.email.setValue(res.data.email);
        this.employeeForm.controls.phoneNumber.setValue(res.data.phoneNumber);
      })
    }
   
  }
  get userId() {
    return this.employeeForm.get('userId');
  }

}
