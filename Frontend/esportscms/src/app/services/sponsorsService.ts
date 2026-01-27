// src/app/services/sponsors.service.ts
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SponsorModel } from '../models/sponsors';

@Injectable({
  providedIn: 'root',
})
export class SponsorsService {
  private baseUrl = 'https://localhost:7147/';

  constructor(private http: HttpClient) {}

  getSponsors(): Observable<SponsorModel[]> {
    return this.http.get<SponsorModel[]>(`${this.baseUrl}api/Sponsors`);
  }

  addSponsor(sponsor: SponsorModel): Observable<SponsorModel> {
    return this.http.post<SponsorModel>(
      `${this.baseUrl}api/Sponsors`,
      sponsor
    );
  }
}
