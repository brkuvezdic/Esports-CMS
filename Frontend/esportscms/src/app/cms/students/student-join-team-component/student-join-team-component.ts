import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

import { AuthService } from '../../../services/auth';
import { StudentsService } from '../../../services/students';
import { TeamService } from '../../../services/teamService';

import { TeamModel } from '../../../models/team';

@Component({
  selector: 'app-student-join-team-component',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './student-join-team-component.html',
  styleUrl: './student-join-team-component.css',
})
export class StudentJoinTeamComponent implements OnInit {
  teams: TeamModel[] = [];
  loading = false;

  constructor(
    private studentsService: StudentsService,
    private auth: AuthService,
    private cdr: ChangeDetectorRef,
    private router: Router,
    private teamService: TeamService
  ) {}

  ngOnInit(): void {
    this.loadTeams();
  }

  loadTeams(): void {
    const userId = this.auth.getUserId();

    if (!userId) {
      return;
    }

    this.loading = true;

    this.teamService.getTeamsForUser(userId).subscribe({
      next: (teams) => {
        this.teams = teams;
        this.loading = false;
        this.cdr.detectChanges();
      },
      error: (err) => {
        console.error(err);
        this.loading = false;
      },
    });
  }

  get ShowComponent(): boolean {
    const isCmsRoute = this.router.url
      .toLowerCase()
      .includes('/cms/jointeam');

    const isAuthenticated = !!this.auth.getToken();

    return !(isCmsRoute && isAuthenticated);
  }
}