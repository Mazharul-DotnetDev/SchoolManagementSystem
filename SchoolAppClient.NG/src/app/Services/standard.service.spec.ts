import { TestBed } from '@angular/core/testing';

import { StandardService } from './standard.service';

describe('StandardService', () => {
  let service: StandardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StandardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
