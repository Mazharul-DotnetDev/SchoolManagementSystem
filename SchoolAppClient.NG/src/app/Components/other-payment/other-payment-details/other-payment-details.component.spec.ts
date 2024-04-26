import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OtherPaymentDetailsComponent } from './other-payment-details.component';

describe('OtherPaymentDetailsComponent', () => {
  let component: OtherPaymentDetailsComponent;
  let fixture: ComponentFixture<OtherPaymentDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OtherPaymentDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(OtherPaymentDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
