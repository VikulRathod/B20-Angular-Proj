import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';

import { User } from '../models/user';
import { Login } from '../models/login';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';
import { SignUp } from '../models/signup';
import { AUTH_ID } from '../app.constant';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  user: User | undefined;
  httpHeaders: HttpHeaders;
  constructor(private httpClient: HttpClient) {
    this.httpHeaders = new HttpHeaders({ 'content-type': 'application/json' });
    this.loadUser();
  }
  private loadUser() {
    const data = localStorage.getItem(AUTH_ID);
    if (data != undefined) {
      this.user = JSON.parse(data);
    }
    else {
      this.user = undefined;
    }
  }
  ValidateUser(model: Login): Observable<HttpResponse<User>> {
    return this.httpClient.post<User>(environment.apiAddress + "/auth/validateuser", JSON.stringify(model), { headers: this.httpHeaders, observe: 'response' });
  }

  UserSignUp(model: SignUp): Observable<HttpResponse<User>> {
    return this.httpClient.post<User>(environment.apiAddress + "/auth/createuser", JSON.stringify(model), { headers: this.httpHeaders, observe: 'response' });
  }
  SetAuthUser(user: User) {
    localStorage.setItem(AUTH_ID, JSON.stringify(user));
    this.loadUser();
  }
  RemoveAuthUser() {
    const data = localStorage.getItem(AUTH_ID);
    if (data != undefined) {
      localStorage.removeItem(AUTH_ID);
    }
    this.loadUser();
  }
}
