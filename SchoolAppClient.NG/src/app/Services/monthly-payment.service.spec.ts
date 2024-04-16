import { TestBed } from '@angular/core/testing';

import { MonthlyPaymentService } from './monthly-payment.service';

describe('MonthlyPaymentService', () => {
  let service: MonthlyPaymentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MonthlyPaymentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
