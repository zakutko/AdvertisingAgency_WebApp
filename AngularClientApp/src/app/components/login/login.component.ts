import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginCredentials } from '../../credentials/login-credentials';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  invalidLogin: boolean = false;

  constructor(private authService: AuthService, private router: Router) {}

  form = new FormGroup({
    usernameOrEmail: new FormControl('', [Validators.required]),
    password: new FormControl('', [Validators.required]),
  });

  get usernameOrEmail() {
    return this.form.get('usernameOrEmail');
  }

  get password() {
    return this.form.get('password');
  }

  login(credentials: LoginCredentials) {
    this.authService.login(credentials).subscribe((result) => {
      if (result.errorMessage == null) {
        localStorage.setItem('token', result.token);
        this.router.navigate(['']);
      } else {
        this.invalidLogin = true;
      }
    });
  }

  ngOnInit(): void {}
}
