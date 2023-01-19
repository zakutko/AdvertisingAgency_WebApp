import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginCredentials } from '../credentials/login-credentials';
import { User } from '../models/user';
import { RegisterCredentials } from '../credentials/register-credentials';
import { UserInfo } from '../models/user-info';
import { Exist } from '../models/exist';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = "https://localhost:58566/api";

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'})
  }

  constructor(private http: HttpClient) { }

  login(credentials: LoginCredentials) {
    return this.http.post<User>(this.baseUrl + '/Identity/login', 
      credentials, this.httpOptions);
  }

  register(credentials: RegisterCredentials) {
    return this.http.post<User>(this.baseUrl + '/Identity/register',
      credentials, this.httpOptions);
  }

  logout() {
    localStorage.clear();
  }

  getCurrentUser(token: string) {
    return this.http.get<UserInfo>(this.baseUrl + `/Identity/currentUser?token=${token}`);
  }

  isUserExistByEmailOrUsername(requestValue: string) {
    return this.http.get<Exist>(this.baseUrl + `/Identity/isExistByEmail?requestValue=${requestValue}`);
  }
}
