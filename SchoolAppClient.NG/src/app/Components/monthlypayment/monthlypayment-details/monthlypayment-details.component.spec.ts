import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MonthlypaymentDetailsComponent } from './monthlypayment-details.component';

describe('MonthlypaymentDetailsComponent', () => {
  let component: MonthlypaymentDetailsComponent;
  let fixture: ComponentFixture<MonthlypaymentDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MonthlypaymentDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MonthlypaymentDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
