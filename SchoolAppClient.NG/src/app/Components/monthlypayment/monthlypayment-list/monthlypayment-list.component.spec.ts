import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MonthlypaymentListComponent } from './monthlypayment-list.component';

describe('MonthlypaymentListComponent', () => {
  let component: MonthlypaymentListComponent;
  let fixture: ComponentFixture<MonthlypaymentListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MonthlypaymentListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MonthlypaymentListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
