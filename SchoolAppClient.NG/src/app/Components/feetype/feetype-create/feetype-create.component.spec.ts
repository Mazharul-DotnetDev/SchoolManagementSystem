import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeetypeCreateComponent } from './feetype-create.component';

describe('FeetypeCreateComponent', () => {
  let component: FeetypeCreateComponent;
  let fixture: ComponentFixture<FeetypeCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FeetypeCreateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FeetypeCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
