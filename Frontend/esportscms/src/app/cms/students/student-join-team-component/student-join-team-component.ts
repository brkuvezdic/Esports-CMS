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

  selectedTeamId: number | null = null;

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
    const user = this.auth.getUserId();

    if (!user) {
      return;
    }

    this.loading = true;

    this.teamService.getTeamsForUser(user).subscribe({
      next: (teams) => {
        this.teams = teams;

        if (teams.length === 1) {
          this.selectedTeamId = teams[0].teamId;
        }

        this.loading = false;
        this.cdr.detectChanges();
      },
      error: (err) => {
        console.error(err);
        this.loading = false;
      },
    });
  }

  joinTeam(teamId: number): void {
    const user = this.auth.getUserId();
    if (!user) {
  return;
}
    this.studentsService
      .joinTeam(user, teamId)
      .subscribe({
        next: () => {
          this.selectedTeamId = teamId;

          this.teams = this.teams.filter(
            (x) => x.teamId === teamId
          );

          this.cdr.detectChanges();
        },
        error: (err) => {
          console.error(err);
        },
      });
  }

    leaveTeam(): void {
    const user = this.auth.getUserId();
if (!user) {
  return;
}
    this.studentsService.leaveTeam(user)
      .subscribe({
        next: () => {
          this.selectedTeamId = null;
          this.loadTeams();
        },
        error: (err) => {
          console.error(err);
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