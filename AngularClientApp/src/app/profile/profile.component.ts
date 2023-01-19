import { Component, OnInit } from '@angular/core';
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
}
