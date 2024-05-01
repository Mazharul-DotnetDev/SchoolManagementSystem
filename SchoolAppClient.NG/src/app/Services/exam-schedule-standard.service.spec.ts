import { TestBed } from '@angular/core/testing';

import { ExamScheduleStandardService } from './exam-schedule-standard.service';

describe('ExamScheduleStandardService', () => {
  let service: ExamScheduleStandardService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExamScheduleStandardService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
