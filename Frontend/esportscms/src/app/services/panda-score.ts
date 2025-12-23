import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PandaScoreModel } from '../models/pandaScore';

@Injectable({
  providedIn: 'root',
})
export class PandaScoreService {
  private baseUrl = 'https://localhost:7147/api/pandascore';

  constructor(private http: HttpClient) {}

  getPandaScoreUpcommingMatches(): Observable<PandaScoreModel[]> {
    return this.http.get<PandaScoreModel[]>(`${this.baseUrl}/upcoming`);
  }
}
