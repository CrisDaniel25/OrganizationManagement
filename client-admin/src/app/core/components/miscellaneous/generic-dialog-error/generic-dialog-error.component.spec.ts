import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenericDialogErrorComponent } from './generic-dialog-error.component';

describe('GenericDialogErrorComponent', () => {
  let component: GenericDialogErrorComponent;
  let fixture: ComponentFixture<GenericDialogErrorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GenericDialogErrorComponent]
    });
    fixture = TestBed.createComponent(GenericDialogErrorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
