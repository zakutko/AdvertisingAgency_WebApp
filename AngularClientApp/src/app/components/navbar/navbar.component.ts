import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserInfo } from '../../models/user-info';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit
{
  userInfo!: UserInfo;
  
  constructor(private router: Router, private authService: AuthService) { }

  ngOnInit(): void
  {
    let token = localStorage.getItem('token');
    if (token != null) {
      this.authService.getCurrentUser(token)
        .subscribe(result => {
          this.userInfo = result;
        });
    }
  }

  isLoggedIn() {
    if (localStorage.getItem('token') === null) {
      return false;
    }
    else {
      return true;
    }
  }

  onLoginClick()
  {
    this.router.navigate(['login']);
  }

  onRegisterClick()
  {
    this.router.navigate(['register']);
  }

  onAboutClick() {
    this.router.navigate(['about']);
  }

  onLogoutClick() {
    this.authService.logout();
    this.router.navigate(['/']);
  }

  onProfileClick() {
    this.router.navigate(['profile']);
  }

  onAddAdvertisementClick() {
    this.router.navigate(['add-advertisement']);
  }

  onMyAdvertisementsClick() {
    this.router.navigate(['my-advertisements']);
  }

  onAdminPanelClick() {
    this.router.navigate(['admin-panel']);
  }

  onEditorPanelClick() {
    this.router.navigate(['editor-panel']);
  }

  onApproverPanelClick() {
    this.router.navigate(['approver-panel']);
  }
}