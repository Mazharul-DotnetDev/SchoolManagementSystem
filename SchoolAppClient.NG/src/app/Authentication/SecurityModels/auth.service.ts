import { HttpClient } from "@angular/common/http";
import { Injectable, inject } from "@angular/core";
import { Router } from "@angular/router";
import { BehaviorSubject, Observable, tap } from "rxjs";
import { AuthRequest } from "./auth-request";
import { AuthResponse } from "./auth-response";
import { jwtDecode } from "jwt-decode";

const api: string = "https://localhost:7225/api/users/";

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly JWT_TOKEN = 'JWT_TOKEN';
  private readonly JWT_USER = 'JWT_USER';
  private loggedUser?: string;
  private isAuthenticatedSubject = new BehaviorSubject<boolean>(false);
  private router = inject(Router);
  private http = inject(HttpClient);

  constructor() { }

  login(user: AuthRequest): Observable<AuthResponse> {
    return this.http
      .post<AuthResponse>(api + 'login', user)
      .pipe(
        tap((response: AuthResponse) => {
          console.info(response);
          this.doLoginUser(response);
          this.router.navigate(['/']);
        })
      );
  }

  private doLoginUser(data: AuthResponse) {
    this.loggedUser = data.email;
    this.storeJwtToken(data.token);
    this.storeUser(data);
    this.isAuthenticatedSubject.next(true);
  }
  private storeUser(user: AuthResponse) {
    localStorage.setItem(this.JWT_USER, JSON.stringify(user));
  }
  private storeJwtToken(jwt: string) {
    localStorage.setItem(this.JWT_TOKEN, jwt);
  }

  logout() {
    localStorage.removeItem(this.JWT_TOKEN);
    localStorage.removeItem(this.JWT_USER);
    this.isAuthenticatedSubject.next(false);
    this.router.navigate(['/']);
  }

  getCurrentAuthUser(): AuthResponse {
    var user!: AuthResponse;
    if (localStorage.getItem(this.JWT_USER))
     user= JSON.parse(localStorage.getItem(this.JWT_USER) ?? "");
    return user;
  }

  isLoggedIn() {
    return !!localStorage.getItem(this.JWT_TOKEN);
  }

  isTokenExpired() {
    const tokens = localStorage.getItem(this.JWT_TOKEN);
    if (!tokens) return true;
    const token = JSON.parse(tokens).access_token;
    const decoded = jwtDecode(token);
    if (!decoded.exp) return true;
    const expirationDate = decoded.exp * 1000;
    const now = new Date().getTime();

    return expirationDate < now;
  }

  refreshToken() {
    let tokens: any = localStorage.getItem(this.JWT_TOKEN);
    if (!tokens) return;
    tokens = JSON.parse(tokens);
    let refreshToken = tokens.refresh_token;
    return this.http
      .post<any>('https://api.escuelajs.co/api/v1/auth/refresh-token', {
        refreshToken,
      })
      .pipe(tap((tokens: any) => this.storeJwtToken(JSON.stringify(tokens))));
  }
}
