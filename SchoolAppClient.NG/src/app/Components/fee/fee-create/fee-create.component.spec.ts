import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeeCreateComponent } from './fee-create.component';

describe('FeeCreateComponent', () => {
  let component: FeeCreateComponent;
  let fixture: ComponentFixture<FeeCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FeeCreateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FeeCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
