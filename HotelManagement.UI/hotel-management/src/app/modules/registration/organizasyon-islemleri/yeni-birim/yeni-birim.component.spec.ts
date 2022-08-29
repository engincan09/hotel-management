/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { YeniBirimComponent } from './yeni-birim.component';

describe('YeniBirimComponent', () => {
  let component: YeniBirimComponent;
  let fixture: ComponentFixture<YeniBirimComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ YeniBirimComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(YeniBirimComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
