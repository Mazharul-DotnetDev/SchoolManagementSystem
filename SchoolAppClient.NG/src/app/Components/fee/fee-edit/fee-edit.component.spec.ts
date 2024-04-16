import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeeEditComponent } from './fee-edit.component';

describe('FeeEditComponent', () => {
  let component: FeeEditComponent;
  let fixture: ComponentFixture<FeeEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FeeEditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FeeEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
