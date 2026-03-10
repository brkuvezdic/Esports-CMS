import { ChangeDetectorRef, Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth';
import { StudentsService } from '../../../services/students';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-student-join-team-component',
  imports: [CommonModule],
  templateUrl: './student-join-team-component.html',
  styleUrl: './student-join-team-component.css',
})
export class StudentJoinTeamComponent {
    constructor(
    private studentsService: StudentsService,
    private auth: AuthService,
    private cdr: ChangeDetectorRef,
    private router: Router
  ) { }
get ShowComponent(): boolean {
  const isCmsRoute = this.router.url.toLowerCase().includes('/cms/jointeam');
  const isAuthenticated = !!this.auth.getToken();

  return !(isCmsRoute && isAuthenticated);
}
}
