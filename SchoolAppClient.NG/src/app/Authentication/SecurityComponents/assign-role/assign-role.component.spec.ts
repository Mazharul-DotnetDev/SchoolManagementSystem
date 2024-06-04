import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignRoleComponent } from './assign-role.component';

describe('AssignRoleComponent', () => {
  let component: AssignRoleComponent;
  let fixture: ComponentFixture<AssignRoleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AssignRoleComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AssignRoleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
