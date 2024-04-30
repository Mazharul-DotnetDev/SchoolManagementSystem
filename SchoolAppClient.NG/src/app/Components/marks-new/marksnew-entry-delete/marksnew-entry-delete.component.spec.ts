import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarksnewEntryDeleteComponent } from './marksnew-entry-delete.component';

describe('MarksnewEntryDeleteComponent', () => {
  let component: MarksnewEntryDeleteComponent;
  let fixture: ComponentFixture<MarksnewEntryDeleteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MarksnewEntryDeleteComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MarksnewEntryDeleteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
