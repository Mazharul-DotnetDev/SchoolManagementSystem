import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamtypeAddComponent } from './examtype-add.component';

describe('ExamtypeAddComponent', () => {
  let component: ExamtypeAddComponent;
  let fixture: ComponentFixture<ExamtypeAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExamtypeAddComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExamtypeAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
