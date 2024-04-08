import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarksDeleteComponent } from './marks-delete.component';

describe('MarksDeleteComponent', () => {
  let component: MarksDeleteComponent;
  let fixture: ComponentFixture<MarksDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MarksDeleteComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MarksDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
