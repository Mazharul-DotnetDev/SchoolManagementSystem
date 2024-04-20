import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StaffCreateComponent } from './staff-create.component';

describe('StaffCreateComponent', () => {
  let component: StaffCreateComponent;
  let fixture: ComponentFixture<StaffCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StaffCreateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StaffCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
