import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientConfirmDeleteComponent } from './client-confirm-delete.component';

describe('ClientConfirmDeleteComponent', () => {
  let component: ClientConfirmDeleteComponent;
  let fixture: ComponentFixture<ClientConfirmDeleteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ClientConfirmDeleteComponent]
    });
    fixture = TestBed.createComponent(ClientConfirmDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
