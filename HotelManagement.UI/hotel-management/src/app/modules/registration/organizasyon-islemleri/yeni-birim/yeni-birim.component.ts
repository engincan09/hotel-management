import { Organizasyon } from '../models/organizasyon.model';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { OrganizasyonService } from '../service/organizasyon.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomvalidationService } from 'src/app/shared/services/custom-validation.service';
import { ConfirmationDialogService } from 'src/app/shared/services/confirmation-dialog.service';
declare var $;

@Component({
  selector: 'app-yeni-birim',
  templateUrl: './yeni-birim.component.html',
  styleUrls: ['./yeni-birim.component.scss'],
})
export class YeniBirimComponent implements OnInit {
  birimForm: FormGroup;
  birim: Organizasyon = new Organizasyon();
  birimId: number;
  environment = environment;
  submitted = false;
  birimler;
  displayStyle = 'none';

  birimSelectBoxDataSource;

  constructor(
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private organizasyonService: OrganizasyonService,
    private activatedRoute: ActivatedRoute,
    private route: ActivatedRoute,
    private router: Router,
    private customValidator: CustomvalidationService,
    private confirmationDialogService: ConfirmationDialogService
  ) {}

  ngOnInit() {
    this.createBirimAddForm();
    this.uploadData();
  }

  get formControl() {
    return this.birimForm.controls;
  }

  getBirimDataSource(){
    this.organizasyonService.getAllOrganizasyon().subscribe((res)=>{
      this.birimSelectBoxDataSource = res.data;
    });
  }

  changeBirim(e){
    this.typeName?.setValue(e.target.value, {
      onlySelf: true,
    });    
  }

  get typeName() {
    return this.birimForm.get('parentId');
  }



  saveOrganizasyon() {
    console.log(this.birimForm,"a");
    
    this.submitted = true;
    if (this.birimForm.valid) {
      let model: Organizasyon = Object.assign({}, this.birimForm.value);
      if (this.birim.id) {
        this.updateOrganizasyon(model);
        this.closePopup();
      } else {
        this.addOrganizasyon(model);
        this.closePopup();
      }
    } else {
      this.toastr.error('Zorunlu alanları kontrol ediniz!', 'Hata');
    }
  }

  addOrganizasyon(model) {
    this.organizasyonService.postOrganizasyon(model).subscribe((res) => {
      if (res.success) {
        this.toastr.success(res.messages, 'Başarılı!');
        this.uploadData();
      } else {
        this.toastr.error(res.messages, 'Hata!');
      }
    });
  }
  updateOrganizasyon(model) {
    this.organizasyonService.updateOrganizasyon(model).subscribe((res) => {
      if (res.success) {
        this.toastr.success(res.messages, 'Başarılı!');
        this.uploadData();
      } else {
        this.toastr.error(res.messages, 'Hata!');
      }
    });
  }

  createBirimAddForm() {
    this.birimForm = this.formBuilder.group({
      parentId: [''],
      numberOfStaff: ['', Validators.required],
      name: ['', Validators.required],
      code: ['', Validators.required],
      isBirimMudur: [''],
    });
  }

  createBirimUpdateForm(id) {
    this.birimForm = this.formBuilder.group({
      parentId: [''],
      numberOfStaff: ['', Validators.required],
      name: ['', Validators.required],
      code: ['', Validators.required],
      isBirimMudur: [''],
      id: id,
    });
  }

  uploadData() {
    var self = this;
    this.organizasyonService
      .getAllOrganizasyoneDetailTable()
      .subscribe((res) => {
        this.birimler = res.data;
        $('#jsGrid1').jsGrid({
          width: '100%',
          height: 300,
          sorting: true,
          paging: true,
          pageSize: 10,
          pageButtonCount: 5,
          deleteConfirm: 'Birimi silmek istediğinize emin misiniz?',
          inserting: false,
          editing: false,
          data: this.birimler,
          viewrecords: true,
          gridview: true,
          autoencode: true,
          loadonce: true,
          fields: [
            {
              type: 'control',
              width: 90,
              editButton: false,
              deleteButton: false,
              title: 'İşlemler',
              itemTemplate: function (value, item) {
                var $iconPencil = $('<i>').attr({ class: 'fa fa-pencil p-2' });
                var $iconTrash = $('<i>').attr({ class: 'fa fa-trash p-2' });

                var $customEditButton = $('<button>')
                  .attr({
                    class:
                      'btn btn-warning btn-xs mr-2 d-flex justify-content-center',
                  })
                  .attr({ role: 'button' })
                  .attr({ title: 'Düzenle' })
                  .attr({ id: 'btn-edit-' + item.id })
                  .click((e) => {
                    self.openPopup(item.id);
                  })
                  .append($iconPencil);

                var $customDeleteButton = $('<button>')
                  .attr({ class: 'btn btn-danger btn-xs' })
                  .attr({ role: 'button' })
                  .attr({ title: 'Sil' })
                  .attr({ id: 'btn-delete-' + item.id })
                  .click(function (e) {
                    self.delete(item.id);
                  })
                  .append($iconTrash);

                return $('<div>')
                  .attr({ class: 'btn-toolbar' })
                  .append($customEditButton)
                  .append($customDeleteButton);
              },
            },
            {
              name: 'code',
              type: 'text',
              width: 120,
              title: 'Kod',
              autosearch: true,
            },
            { name: 'name', type: 'text', width: 150, title: 'Birim Adı' },
            {
              name: 'parentName',
              type: 'text',
              width: 150,
              title: 'Üst Birim Adı',
            },
            {
              name: 'isBirimMudur',
              type: 'bool',
              width: 150,
              title: 'Yönetici mi?',
            },
            {
              name: 'numberOfStaff',
              type: 'text',
              width: 150,
              title: 'Kadro Sayısı',
            },
          ],
        });
      });
  }

  delete(id) {
    if (id) {
      this.confirmationDialogService
        .confirm('İşlem Onayı', 'Birimi silmek istediğinize emin misiniz ?')
        .then((confirmed) => {
          if (confirmed) {
            this.organizasyonService.deleteOrganizasyon(id).subscribe((res) => {
              this.uploadData();
            });
          }
        });
    }
  }

  openPopup(id) {
    this.getBirimDataSource();
    if (id) {
      this.createBirimUpdateForm(id);
      this.organizasyonService.getOrganizasyon(id).subscribe((res) => {
        this.birimId = res.data.id;
        this.birim = res.data;
        this.displayStyle = 'block'; 
      });
    }else{
      this.createBirimAddForm();
      this.displayStyle = 'block'; 
    }
  }

  closePopup() {
    this.displayStyle = 'none';
    this.birim = new Organizasyon();
    this.birimForm.reset;
  }
}
