import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TeamModel } from '../models/team';

@Injectable({
  providedIn: 'root',
})
export class TeamService {
  private baseUrl = 'https://localhost:7147/';

  constructor(private http: HttpClient) {}

  getAllTeams(): Observable<TeamModel[]> {
    return this.http.get<TeamModel[]>(
      `${this.baseUrl}api/Team`
    );
  }

  getTeamsForUser(userId: string): Observable<TeamModel[]> {
    return this.http.get<TeamModel[]>(
      `${this.baseUrl}api/Team/user/${userId}`
    );
  }
}