import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SponsorModel } from '../models/sponsors';

@Injectable({
  providedIn: 'root',
})
export class SponsorsService {
  private baseUrl = 'https://localhost:7147/api/Sponsors';

  constructor(private http: HttpClient) {}

  getSponsors(): Observable<SponsorModel[]> {
    return this.http.get<SponsorModel[]>(this.baseUrl);
  }

  addSponsor(sponsor: SponsorModel): Observable<SponsorModel> {
    return this.http.post<SponsorModel>(this.baseUrl, sponsor);
  }

  updateSponsor(sponsor: SponsorModel): Observable<any> {
    return this.http.put(`${this.baseUrl}/${sponsor.sponsorId}`, sponsor);
  }

  deleteSponsor(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }
}
