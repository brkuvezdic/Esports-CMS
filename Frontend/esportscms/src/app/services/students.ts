import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { StudentModel } from '../models/student';

@Injectable({
  providedIn: 'root',
})
export class StudentsService {
  private baseUrl = 'https://localhost:7147/';

  constructor(private http: HttpClient) {}

  getStudents(): Observable<StudentModel[]> {
    return this.http.get<StudentModel[]>(`${this.baseUrl}api/Students`);
  }

}
