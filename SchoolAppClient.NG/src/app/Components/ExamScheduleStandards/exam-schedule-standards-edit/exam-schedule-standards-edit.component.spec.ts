import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamScheduleStandardsEditComponent } from './exam-schedule-standards-edit.component';

describe('ExamScheduleStandardsEditComponent', () => {
  let component: ExamScheduleStandardsEditComponent;
  let fixture: ComponentFixture<ExamScheduleStandardsEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExamScheduleStandardsEditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExamScheduleStandardsEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
