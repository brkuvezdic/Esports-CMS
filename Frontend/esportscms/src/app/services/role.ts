import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RoleModel } from '../models/role';

@Injectable({
  providedIn: 'root',
})
export class RoleService {
  
    private baseUrl = 'https://localhost:7147/';

  constructor(private http: HttpClient) {}

  getRoles(): Observable<RoleModel[]> {
    return this.http.get<RoleModel[]>(`${this.baseUrl}api/Roles`);
  }

  updateStudentRoles(changes: { userId: number; roleId: number }[]): Observable<any> {
  return this.http.post(`${this.baseUrl}api/Students/update-roles`, changes);
}

}
