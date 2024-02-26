import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenericDialogWarningComponent } from './generic-dialog-warning.component';

describe('GenericDialogWarningComponent', () => {
  let component: GenericDialogWarningComponent;
  let fixture: ComponentFixture<GenericDialogWarningComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GenericDialogWarningComponent]
    });
    fixture = TestBed.createComponent(GenericDialogWarningComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
