import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StandardCreateComponent } from './standard-create.component';

describe('StandardCreateComponent', () => {
  let component: StandardCreateComponent;
  let fixture: ComponentFixture<StandardCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StandardCreateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StandardCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
