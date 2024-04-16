import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeetypeListComponent } from './feetype-list.component';

describe('FeetypeListComponent', () => {
  let component: FeetypeListComponent;
  let fixture: ComponentFixture<FeetypeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FeetypeListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FeetypeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
