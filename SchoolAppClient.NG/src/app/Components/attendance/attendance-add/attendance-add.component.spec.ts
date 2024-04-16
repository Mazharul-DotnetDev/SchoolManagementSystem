import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendanceAddComponent } from './attendance-add.component';

describe('AttendanceAddComponent', () => {
  let component: AttendanceAddComponent;
  let fixture: ComponentFixture<AttendanceAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AttendanceAddComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AttendanceAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
