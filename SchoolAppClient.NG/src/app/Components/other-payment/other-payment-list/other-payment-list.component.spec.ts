import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OtherPaymentListComponent } from './other-payment-list.component';

describe('OtherPaymentListComponent', () => {
  let component: OtherPaymentListComponent;
  let fixture: ComponentFixture<OtherPaymentListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OtherPaymentListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(OtherPaymentListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
