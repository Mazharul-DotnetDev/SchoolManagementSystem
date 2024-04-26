import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OtherPaymentCreateComponent } from './other-payment-create.component';

describe('OtherPaymentCreateComponent', () => {
  let component: OtherPaymentCreateComponent;
  let fixture: ComponentFixture<OtherPaymentCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OtherPaymentCreateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(OtherPaymentCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
