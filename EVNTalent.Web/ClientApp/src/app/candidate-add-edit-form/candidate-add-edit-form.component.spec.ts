import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CandidateAddEditFormComponent } from './candidate-add-edit-form.component';

describe('CandidateAddEditFormComponent', () => {
  let component: CandidateAddEditFormComponent;
  let fixture: ComponentFixture<CandidateAddEditFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CandidateAddEditFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CandidateAddEditFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
