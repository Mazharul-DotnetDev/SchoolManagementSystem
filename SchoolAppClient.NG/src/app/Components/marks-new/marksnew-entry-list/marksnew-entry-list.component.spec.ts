import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarksnewEntryListComponent } from './marksnew-entry-list.component';

describe('MarksnewEntryListComponent', () => {
  let component: MarksnewEntryListComponent;
  let fixture: ComponentFixture<MarksnewEntryListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MarksnewEntryListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MarksnewEntryListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
