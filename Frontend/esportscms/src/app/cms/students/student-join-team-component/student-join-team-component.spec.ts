import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentJoinTeamComponent } from './student-join-team-component';

describe('StudentJoinTeamComponent', () => {
  let component: StudentJoinTeamComponent;
  let fixture: ComponentFixture<StudentJoinTeamComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StudentJoinTeamComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StudentJoinTeamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
