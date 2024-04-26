import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OtherPaymentEditComponent } from './other-payment-edit.component';

describe('OtherPaymentEditComponent', () => {
  let component: OtherPaymentEditComponent;
  let fixture: ComponentFixture<OtherPaymentEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OtherPaymentEditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(OtherPaymentEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
