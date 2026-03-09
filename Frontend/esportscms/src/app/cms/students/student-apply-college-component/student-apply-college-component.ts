import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CollegesService } from '../../../services/colleges';
import { StudentsService } from '../../../services/students';
import { CollegeModel } from '../../../models/college';
import { AuthService } from '../../../services/auth';
import { StudentModel } from '../../../models/student';
import { Router } from '@angular/router';

@Component({
  selector: 'app-student-apply-college',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './student-apply-college-component.html',
  styleUrls: ['./student-apply-college-component.css']
})
export class StudentApplyCollegeComponent implements OnInit {
get ShowComponent(): boolean {
  const isCmsRoute = this.router.url.toLowerCase().includes('/cms');
  const isAuthenticated = !!this.auth.getToken();

  return !(isCmsRoute && isAuthenticated);
}
  colleges: CollegeModel[] = [];
  applying = false;
  currentUser?: StudentModel;

  constructor(
    private collegesService: CollegesService,
    private studentsService: StudentsService,
    private auth: AuthService,
    private cdr: ChangeDetectorRef,
    private router: Router
  ) { }

  ngOnInit() {
        this.loadCurrentUser();

    this.loadColleges();
  }

  get hasCollege(): boolean {
    return !!this.currentUser?.collegeId;
  }

  loadColleges() {
    this.collegesService.getColleges().subscribe(res => {
      this.colleges = res;
    });
  }

loadCurrentUser() {
    const userId = this.auth.getUserId();
    if (!userId) return;

    this.studentsService.getStudents().subscribe(users => {
      this.currentUser = users.find(x => x.id === userId);
      
      if (!this.currentUser) {
        console.error("Current user not found in users list! ID:", userId);
      }
      
      this.cdr.detectChanges();
    });
  }



  apply(collegeId: number) {

    const userId = this.auth.getUserId();

    if (!userId) {
      console.error("No userId in token");
      return;
    }

    this.applying = true;

    this.studentsService
      .assignStudentToCollege(userId, collegeId)
      .subscribe({
        next: () => {
          alert("Application sent successfully!");
          this.loadCurrentUser();
        },
        error: () => {
          alert("Failed to apply.");
        },
        complete: () => {
          this.applying = false;
        }
      });
  }

  removeFromCollege() {

    const userId = this.auth.getUserId();

    if (!userId) {
      alert("User not logged in");
      return;
    }

    this.studentsService
      .removeStudentFromCollege(userId)
      .subscribe({
        next: () => {
          alert("You left the college.");
          this.loadCurrentUser();
        },
        error: () => {
          alert("Failed to leave college.");
        }
      });
  }
}