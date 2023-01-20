import { Component, OnInit } from '@angular/core';
import { UpdateRoleCredentials } from '../credentials/update-role-credentials';
import { UserInfo } from '../models/user-info';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  userInfo!: UserInfo;
  thisIsOldUser!: boolean;
  numberOfPublications!: number;
  getRoleRequestMessage!: string | null;

  constructor(private authService: AuthService) { }

  ngOnInit(): void {
    let token = localStorage.getItem('token');
    if (token != null) {
      this.authService.getCurrentUser(token)
        .subscribe(result => {
          this.userInfo = result;
          if(result.isOldUser == null){
            this.thisIsOldUser = false;
          }
          else{
            this.thisIsOldUser = result.isOldUser;
          }
          if(result.numberOfPublications == null){
            this.numberOfPublications = 0;
          }
          else {
            this.numberOfPublications = result.numberOfPublications;
          }
        });
    }
  }

  onUpdateRoleRequestClick(roleName: string) {
    let token = localStorage.getItem('token');
    if(token != null){
      let updateRoleCredentials: UpdateRoleCredentials = {token: token, roleName: roleName};
      this.authService.updateRoleRequest(updateRoleCredentials)
        .subscribe(result => {
          this.getRoleRequestMessage = result.message;
          setTimeout(() => {
            this.getRoleRequestMessage = null;
          }, 4000);
        })
    }
  }
}
