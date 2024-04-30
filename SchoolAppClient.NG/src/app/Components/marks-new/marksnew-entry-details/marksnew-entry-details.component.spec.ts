import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarksnewEntryDetailsComponent } from './marksnew-entry-details.component';

describe('MarksnewEntryDetailsComponent', () => {
  let component: MarksnewEntryDetailsComponent;
  let fixture: ComponentFixture<MarksnewEntryDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MarksnewEntryDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MarksnewEntryDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
