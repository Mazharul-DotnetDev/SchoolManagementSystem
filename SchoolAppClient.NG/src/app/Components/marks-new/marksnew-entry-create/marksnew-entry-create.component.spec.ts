import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarksnewEntryCreateComponent } from './marksnew-entry-create.component';

describe('MarksnewEntryCreateComponent', () => {
  let component: MarksnewEntryCreateComponent;
  let fixture: ComponentFixture<MarksnewEntryCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MarksnewEntryCreateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MarksnewEntryCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
