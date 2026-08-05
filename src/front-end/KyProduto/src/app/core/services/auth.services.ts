import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { LoginRequest } from '../../models/login-request';
import { LoginResponse } from '../../models/login-response';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private http = inject(HttpClient);

  // Altere para a URL da sua API
  private apiUrl = 'https://localhost:7020/api/login';

  login(request: LoginRequest): Observable<LoginResponse> {

    return this.http.post<LoginResponse>(this.apiUrl, request);

  }

  salvarToken(token: string): void {

    localStorage.setItem('token', token);

  }

  obterToken(): string | null {

    return localStorage.getItem('token');

  }

  logout(): void {

    localStorage.removeItem('token');

  }

  estaAutenticado(): boolean {

    return this.obterToken() !== null;

  }

}