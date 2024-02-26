import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DynamicGridComponent } from './dynamic-grid.component';

describe('DynamicGridComponent', () => {
  let component: DynamicGridComponent;
  let fixture: ComponentFixture<DynamicGridComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DynamicGridComponent]
    });
    fixture = TestBed.createComponent(DynamicGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
