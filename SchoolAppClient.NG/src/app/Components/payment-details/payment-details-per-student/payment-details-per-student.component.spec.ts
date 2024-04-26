import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaymentDetailsPerStudentComponent } from './payment-details-per-student.component';

describe('PaymentDetailsPerStudentComponent', () => {
  let component: PaymentDetailsPerStudentComponent;
  let fixture: ComponentFixture<PaymentDetailsPerStudentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PaymentDetailsPerStudentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PaymentDetailsPerStudentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
