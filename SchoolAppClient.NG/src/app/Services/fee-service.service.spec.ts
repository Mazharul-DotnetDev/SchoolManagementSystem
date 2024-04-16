import { TestBed } from '@angular/core/testing';

import { FeeServiceService } from './fee-service.service';

describe('FeeServiceService', () => {
  let service: FeeServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FeeServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
