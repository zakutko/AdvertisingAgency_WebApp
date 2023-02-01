import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { LoginCredentials } from '../credentials/login-credentials';
import { User } from '../models/user';
import { RegisterCredentials } from '../credentials/register-credentials';
import { UserInfo } from '../models/user-info';
import { Exist } from '../models/exist';
import { UpdateRoleCredentials } from '../credentials/update-role-credentials';
import { UpdateRoleResponse } from '../models/update-role-response';
import { RoleRequest } from '../models/role-request';
import { Advertisement } from '../models/advertisement';
import { DeleteUserCredentials } from '../credentials/delete-user-credentials';
import { Username } from '../models/username';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseUrl = 'https://localhost:57720/api';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
  };

  constructor(private http: HttpClient) {}

  login(credentials: LoginCredentials) {
    return this.http.post<User>(
      this.baseUrl + '/Identity/login',
      credentials,
      this.httpOptions
    );
  }

  register(credentials: RegisterCredentials) {
    return this.http.post<User>(
      this.baseUrl + '/Identity/register',
      credentials,
      this.httpOptions
    );
  }

  logout() {
    localStorage.clear();
  }

  getCurrentUser(token: string) {
    return this.http.get<UserInfo>(
      this.baseUrl + `/Identity/currentUser?token=${token}`
    );
  }

  isUserExistByEmailOrUsername(requestValue: string) {
    return this.http.get<Exist>(
      this.baseUrl + `/Identity/isExistByEmail?requestValue=${requestValue}`
    );
  }

  updateRoleRequest(credentials: UpdateRoleCredentials) {
    return this.http.post<UpdateRoleResponse>(
      this.baseUrl + '/Identity/updateRole',
      credentials,
      this.httpOptions
    );
  }

  getAllUsers(token: string) {
    return this.http.get<UserInfo[]>(
      this.baseUrl + `/Identity/getAllUsers?token=${token}`
    );
  }

  getAllRoleRequests(token: string) {
    return this.http.get<RoleRequest[]>(
      this.baseUrl + `/Identity/getAllRoleRequests?token=${token}`
    );
  }

  getAllAdvertisements(token: string) {
    return this.http.get<Advertisement[]>(
      this.baseUrl + `/Identity/getAllAdvertisements?token=${token}`
    );
  }

  deleteUser(credentials: DeleteUserCredentials) {
    return this.http.delete(
      this.baseUrl +
        `/Identity/deleteUserByUsernameAndEmail?username=${credentials.username}&&email=${credentials.email}`,
      this.httpOptions
    );
  }

  rejectRoleRequest(userId: string) {
    return this.http.get(
      this.baseUrl + `/Identity/rejectRoleRequest?userId=${userId}`
    );
  }

  acceptRoleRequest(userId: string) {
    return this.http.get(
      this.baseUrl + `/Identity/acceptRoleRequest?userId=${userId}`
    );
  }

  getUsername(userId: string) {
    return this.http.get<Username>(
      this.baseUrl + `/Identity/getUsername?userId=${userId}`
    );
  }
}
