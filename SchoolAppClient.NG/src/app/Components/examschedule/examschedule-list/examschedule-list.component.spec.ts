import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamscheduleListComponent } from './examschedule-list.component';

describe('ExamscheduleListComponent', () => {
  let component: ExamscheduleListComponent;
  let fixture: ComponentFixture<ExamscheduleListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExamscheduleListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExamscheduleListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
