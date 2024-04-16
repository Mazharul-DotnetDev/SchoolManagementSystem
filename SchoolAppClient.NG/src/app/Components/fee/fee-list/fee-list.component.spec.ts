import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FeeListComponent } from './fee-list.component';

describe('FeeListComponent', () => {
  let component: FeeListComponent;
  let fixture: ComponentFixture<FeeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FeeListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FeeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
