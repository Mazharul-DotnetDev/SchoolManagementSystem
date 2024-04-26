import { TestBed } from '@angular/core/testing';

import { OtherPaymentService } from './other-payment.service';

describe('OtherPaymentService', () => {
  let service: OtherPaymentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OtherPaymentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
