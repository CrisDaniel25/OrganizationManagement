import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SelectWithApiResultComponent } from './select-with-api-result.component';

describe('SelectWithApiResultComponent', () => {
  let component: SelectWithApiResultComponent;
  let fixture: ComponentFixture<SelectWithApiResultComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SelectWithApiResultComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SelectWithApiResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
