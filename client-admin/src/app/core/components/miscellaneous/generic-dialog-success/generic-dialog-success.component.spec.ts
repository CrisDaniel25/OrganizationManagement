import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenericDialogSuccessComponent } from './generic-dialog-success.component';

describe('GenericDialogSuccessComponent', () => {
  let component: GenericDialogSuccessComponent;
  let fixture: ComponentFixture<GenericDialogSuccessComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GenericDialogSuccessComponent]
    });
    fixture = TestBed.createComponent(GenericDialogSuccessComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
