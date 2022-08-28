import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ConfirmationDialogService } from 'src/app/shared/services/confirmation-dialog.service';
import { EmployeeService } from '../services/employee.service';
declare var $;
@Component({
  selector: 'app-tum-personeller',
  templateUrl: './tum-personeller.component.html',
  styleUrls: ['./tum-personeller.component.scss']
})
export class TumPersonellerComponent implements OnInit {
  employees: any[] = [];
  constructor(
    private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private confirmationDialogService: ConfirmationDialogService
  ) {}

  ngOnInit() {
    this.uploadData();
  }

  delete(id) {
    if (id) {
      this.confirmationDialogService
        .confirm('İşlem Onayı', 'Personeli silmek istediğinize emin misiniz ?')
        .then((confirmed) => {
          if (confirmed) {
            this.employeeService.deleteEmployee(id).subscribe((res) => {
              this.uploadData();
            });
          }      
        });
    }
  }

  uploadData() {
    var self = this;
    this.employeeService.getAllEmployeeDetailTable().subscribe((res) => {
      this.employees = res.data;
      $('#jsGrid1').jsGrid({
        width: '100%',
        height: 300,
        sorting: true,
        paging: true,
        pageSize: 10,
        pageButtonCount: 5,
        deleteConfirm: 'Personeli silmek istediğinize emin misiniz?',
        inserting: false,
        editing: false,
        data: this.employees,
        viewrecords: true,
        gridview: true,
        autoencode: true,
        loadonce: true,
        fields: [
          {
            type: 'control',
            width: 80,
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
                  document.location.href =
                    'yonetim/idari-isler/personel-islemleri/yeni-personel/' +
                    item.id;
                  e.stopPropagation();
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
            name: 'employeeCode',
            type: 'text',
            width: 100,
            title: 'SicilNo',
            autosearch: true,
          },
          {
            name: 'fullName',
            type: 'text',
            width: 150,
            title: 'Ad Soyad',
            autosearch: true,
          },        
          { name: 'phoneNumber', type: 'text', width: 150, title: 'Telefon' },
          { name: 'email', type: 'text', width: 150, title: 'Mail' },
          { name: 'type', type: 'text', width: 150, title: 'Personel Tipi' },
          { name: 'jobStartDate', type: 'date', width: 150, title: 'İş Başlangıç Tarihi' },

        ],
      });
    });
  
  
  }
}
