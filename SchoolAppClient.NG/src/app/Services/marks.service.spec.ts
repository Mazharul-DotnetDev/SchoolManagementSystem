import { TestBed } from '@angular/core/testing';

import { MarksService } from './marks.service';

describe('MarksService', () => {
  let service: MarksService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MarksService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
