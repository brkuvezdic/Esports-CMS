import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { College } from '../models/college';

@Injectable({
  providedIn: 'root',
})
export class CollegesService {
  private baseUrl = 'https://localhost:7147/';

  constructor(private http: HttpClient) {}

  getColleges(): Observable<College[]> {
  return this.http.get<College[]>(`${this.baseUrl}api/Colleges`);
  }
}
