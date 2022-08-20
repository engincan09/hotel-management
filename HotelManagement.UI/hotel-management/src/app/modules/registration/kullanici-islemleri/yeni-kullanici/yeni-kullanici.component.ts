import { UserService } from './../services/user.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { User } from '../models/user.model';
import { environment } from 'src/environments/environment';
import { ActivatedRoute, Router } from '@angular/router';
declare var $;
@Component({
  selector: 'app-yeni-kullanici',
  templateUrl: './yeni-kullanici.component.html',
  styleUrls: ['./yeni-kullanici.component.scss'],
})
export class YeniKullaniciComponent implements OnInit {
  userForm: FormGroup;
  user: User = new User();
  userId: number;
  environment = environment;

  constructor(
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private userService: UserService,
    private activatedRoute: ActivatedRoute,
    private route: ActivatedRoute,
    private router: Router
  ) {}
  ngOnInit() {
    this.activatedRoute.params.subscribe((params) => {
      if (params['id']) {
        this.userId = parseInt(params['id']);
        this.getUser(this.userId);
        this.createUserUpdateForm();
      } else {
        this.createUserAddForm();
      }
    });
  }

  saveUser() {
    if (this.userForm.valid) {
      let model: User = Object.assign({}, this.userForm.value);
      model.fullName = model.name + ' ' + model.surname;
      if (this.user.id) {
        this.updateUser(model);
      } else {
        this.addUser(model);
      }
    } else {
      this.toastr.error('Zorunlu alanları kontrol ediniz!', 'Hata');
    }
  }

  addUser(model){
    this.userService.postUser(model).subscribe(
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
  updateUser(model) {
    this.userService.updateUser(model).subscribe(
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

  createUserAddForm() {
    this.userForm = this.formBuilder.group({
      name: ['', Validators.required],
      surname: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
      username: ['', Validators.required],
      // photo:['',Validators.required]
    });
  }

  createUserUpdateForm() {
    this.userForm = this.formBuilder.group({
      name: ['', Validators.required],
      surname: ['', Validators.required],
      phoneNumber: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
      username: ['', Validators.required],
      id: this.userId,
    });
  }

  routeChange(){
    this.router.navigate(['/yonetim/idari-isler/kullanici-islemleri/tum-kullanicilar']);
  }

  getUser(userId: number) {
    this.userService.getUser(userId).subscribe((res) => {
      this.user = res.data;
    });
  }
}
