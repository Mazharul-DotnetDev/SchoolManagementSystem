import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StandardListComponent } from './standard-list.component';

describe('StandardListComponent', () => {
  let component: StandardListComponent;
  let fixture: ComponentFixture<StandardListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [StandardListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StandardListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
