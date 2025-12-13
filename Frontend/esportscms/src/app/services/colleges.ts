import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CollegeModel } from '../models/college';  // Keep this

@Injectable({
  providedIn: 'root',
})
export class CollegesService {
  private baseUrl = 'https://localhost:7147/';

  constructor(private http: HttpClient) {}

  getColleges(): Observable<CollegeModel[]> {
    return this.http.get<CollegeModel[]>(`${this.baseUrl}api/Colleges`);
  }

  addCollege(college: CollegeModel): Observable<CollegeModel> {
    return this.http.post<CollegeModel>(`${this.baseUrl}api/Colleges`, college);
  }
  reorderColleges(data: any): Observable<any> {
  return this.http.post(`${this.baseUrl}api/Colleges/reorder`, data);
}
}

