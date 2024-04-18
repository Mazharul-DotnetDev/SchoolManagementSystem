import { TestBed } from '@angular/core/testing';

import { StaffSalaryService } from './staff-salary.service';

describe('StaffSalaryService', () => {
  let service: StaffSalaryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StaffSalaryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
