import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamScheduleStandardsCreateComponent } from './exam-schedule-standards-create.component';

describe('ExamScheduleStandardsCreateComponent', () => {
  let component: ExamScheduleStandardsCreateComponent;
  let fixture: ComponentFixture<ExamScheduleStandardsCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExamScheduleStandardsCreateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExamScheduleStandardsCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
