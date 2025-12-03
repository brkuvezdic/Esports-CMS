import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface UserDto {
  username: string;
  password: string;
}

export interface TokenResponseDto {
  accessToken: string;
  refreshToken: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7147/api/Auth';

  constructor(private http: HttpClient) {}

  login(data: UserDto): Observable<TokenResponseDto> {
    return this.http.post<TokenResponseDto>(`${this.apiUrl}/login`, data);
  }

  register(data: UserDto): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, data);
  }
}
