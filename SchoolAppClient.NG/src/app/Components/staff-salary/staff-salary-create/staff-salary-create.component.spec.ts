import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StaffSalaryCreateComponent } from './staff-salary-create.component';

describe('StaffSalaryCreateComponent', () => {
  let component: StaffSalaryCreateComponent;
  let fixture: ComponentFixture<StaffSalaryCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StaffSalaryCreateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StaffSalaryCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
