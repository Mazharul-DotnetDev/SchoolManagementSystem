import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StaffDeleteComponent } from './staff-delete.component';

describe('StaffDeleteComponent', () => {
  let component: StaffDeleteComponent;
  let fixture: ComponentFixture<StaffDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StaffDeleteComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StaffDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
