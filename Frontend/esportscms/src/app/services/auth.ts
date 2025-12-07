import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, tap } from 'rxjs';

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
  private tokenKey = 'accessToken';

  constructor(private http: HttpClient) {}


  login(data: UserDto): Observable<TokenResponseDto> {
    return this.http.post<TokenResponseDto>(`${this.apiUrl}/login`, data)
      .pipe(
        tap(response => {
          this.saveToken(response.accessToken);
        })
      );
  }

  register(data: UserDto): Observable<any> {
    return this.http.post(`${this.apiUrl}/register`, data);
  }

  saveToken(token: string) {
    localStorage.setItem(this.tokenKey, token);
  }

  getToken(): string | null {
    return localStorage.getItem(this.tokenKey);
  }

  getUserRole(): string | null {
    const token = this.getToken();
    if (!token) return null;

    const payload = JSON.parse(atob(token.split('.')[1]));
    return payload['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] || payload['role'] || null;
  }

  isAdmin(): boolean {
    return this.getUserRole() === 'Admin';
  }

  logout() {
    localStorage.removeItem(this.tokenKey);
  }
}
