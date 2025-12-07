import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface CreateCollegeDto {
  title: string;
  description?: string;
}

export interface CollegeDto {
  collegeId: number;
  title: string;
  description: string;
  createdBy: number;
  createdOn: string;
  sequence: number;
}

@Injectable({
  providedIn: 'root'
})
export class addCollege {

  private apiUrl = '/api/colleges';

  constructor(private http: HttpClient) {}

  createCollege(dto: CreateCollegeDto): Observable<CollegeDto> {
    return this.http.post<CollegeDto>(this.apiUrl, dto);
  }

}
