import { TestBed } from '@angular/core/testing';

import { ProductReportService } from './product-report.service';

describe('ProductReportService', () => {
  let service: ProductReportService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ProductReportService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
