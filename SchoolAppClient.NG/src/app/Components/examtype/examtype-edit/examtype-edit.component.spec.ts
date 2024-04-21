import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamtypeEditComponent } from './examtype-edit.component';

describe('ExamtypeEditComponent', () => {
  let component: ExamtypeEditComponent;
  let fixture: ComponentFixture<ExamtypeEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExamtypeEditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExamtypeEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
