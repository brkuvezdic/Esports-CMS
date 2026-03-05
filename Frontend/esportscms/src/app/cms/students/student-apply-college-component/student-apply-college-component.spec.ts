import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentApplyCollegeComponent } from './student-apply-college-component';

describe('StudentApplyCollegeComponent', () => {
  let component: StudentApplyCollegeComponent;
  let fixture: ComponentFixture<StudentApplyCollegeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StudentApplyCollegeComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StudentApplyCollegeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
