import { TestBed } from '@angular/core/testing';

import { FeetypeService } from './feetype.service';

describe('FeetypeService', () => {
  let service: FeetypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FeetypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
