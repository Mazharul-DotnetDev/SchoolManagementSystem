import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StaffSalaryEditComponent } from './staff-salary-edit.component';

describe('StaffSalaryEditComponent', () => {
  let component: StaffSalaryEditComponent;
  let fixture: ComponentFixture<StaffSalaryEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StaffSalaryEditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StaffSalaryEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
