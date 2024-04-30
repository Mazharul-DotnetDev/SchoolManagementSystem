import { TestBed } from '@angular/core/testing';

import { ExamtypeServiceService } from './examtype.service.service';

describe('ExamtypeServiceService', () => {
  let service: ExamtypeServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExamtypeServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
