/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TumPersonellerComponent } from './tum-personeller.component';

describe('TumPersonellerComponent', () => {
  let component: TumPersonellerComponent;
  let fixture: ComponentFixture<TumPersonellerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TumPersonellerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TumPersonellerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
