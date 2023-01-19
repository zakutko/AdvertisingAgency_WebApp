import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit
{
  constructor(private router: Router, private authService: AuthService) { }

  ngOnInit(): void
  {
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

  onMyPublicationsClick() {
    this.router.navigate(['publications']);
  }
}