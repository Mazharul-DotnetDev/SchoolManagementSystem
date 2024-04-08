import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarksAddComponent } from './marks-add.component';

describe('MarksAddComponent', () => {
  let component: MarksAddComponent;
  let fixture: ComponentFixture<MarksAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MarksAddComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MarksAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
