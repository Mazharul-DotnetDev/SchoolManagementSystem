import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MonthlypaymentCreateComponent } from './monthlypayment-create.component';

describe('MonthlypaymentCreateComponent', () => {
  let component: MonthlypaymentCreateComponent;
  let fixture: ComponentFixture<MonthlypaymentCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MonthlypaymentCreateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MonthlypaymentCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
