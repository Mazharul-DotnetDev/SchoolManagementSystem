import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamscheduleAddComponent } from './examschedule-add.component';

describe('ExamscheduleAddComponent', () => {
  let component: ExamscheduleAddComponent;
  let fixture: ComponentFixture<ExamscheduleAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExamscheduleAddComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExamscheduleAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
