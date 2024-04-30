import { TestBed } from '@angular/core/testing';

import { ExamScheduleService } from './exam-schedule.service';

describe('ExamScheduleService', () => {
  let service: ExamScheduleService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExamScheduleService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
