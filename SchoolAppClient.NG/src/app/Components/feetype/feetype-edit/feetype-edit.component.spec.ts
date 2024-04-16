import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeetypeEditComponent } from './feetype-edit.component';

describe('FeetypeEditComponent', () => {
  let component: FeetypeEditComponent;
  let fixture: ComponentFixture<FeetypeEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FeetypeEditComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FeetypeEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
