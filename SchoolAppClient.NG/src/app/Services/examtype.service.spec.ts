import { TestBed } from '@angular/core/testing';

import { ExamtypeService } from './examtype.service';

describe('ExamtypeService', () => {
  let service: ExamtypeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExamtypeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
