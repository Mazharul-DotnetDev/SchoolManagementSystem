import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamScheduleStandardsListComponent } from './exam-schedule-standards-list.component';

describe('ExamScheduleStandardsListComponent', () => {
  let component: ExamScheduleStandardsListComponent;
  let fixture: ComponentFixture<ExamScheduleStandardsListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExamScheduleStandardsListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExamScheduleStandardsListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
