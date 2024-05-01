import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamscheduleEditComponent } from './examschedule-edit.component';

describe('ExamscheduleEditComponent', () => {
  let component: ExamscheduleEditComponent;
  let fixture: ComponentFixture<ExamscheduleEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExamscheduleEditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExamscheduleEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
