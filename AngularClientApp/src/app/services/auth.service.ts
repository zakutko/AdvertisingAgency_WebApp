import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginCredentials } from '../credentials/login-credentials';
import { User } from '../models/user';

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
}
