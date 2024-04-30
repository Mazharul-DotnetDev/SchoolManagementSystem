import { TestBed } from '@angular/core/testing';

import { MarksEntryService } from './marks-entry.service';

describe('MarksEntryService', () => {
  let service: MarksEntryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MarksEntryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
