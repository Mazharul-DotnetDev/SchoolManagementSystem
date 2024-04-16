import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MonthlypaymentEditComponent } from './monthlypayment-edit.component';

describe('MonthlypaymentEditComponent', () => {
  let component: MonthlypaymentEditComponent;
  let fixture: ComponentFixture<MonthlypaymentEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MonthlypaymentEditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MonthlypaymentEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
