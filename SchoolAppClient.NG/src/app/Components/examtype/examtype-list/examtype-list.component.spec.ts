import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamtypeListComponent } from './examtype-list.component';

describe('ExamtypeListComponent', () => {
  let component: ExamtypeListComponent;
  let fixture: ComponentFixture<ExamtypeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExamtypeListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExamtypeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
