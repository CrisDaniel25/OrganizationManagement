import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeConfirmDeleteComponent } from './employee-confirm-delete.component';

describe('EmployeeConfirmDeleteComponent', () => {
  let component: EmployeeConfirmDeleteComponent;
  let fixture: ComponentFixture<EmployeeConfirmDeleteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [EmployeeConfirmDeleteComponent]
    });
    fixture = TestBed.createComponent(EmployeeConfirmDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
