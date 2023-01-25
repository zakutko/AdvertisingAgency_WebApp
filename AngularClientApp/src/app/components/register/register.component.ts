import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { EmailValidators } from '../../common/validators/email-validators';
import { PasswordValidators } from '../../common/validators/password-validators';
import { UsernameValidators } from '../../common/validators/username-validators';
import { RegisterCredentials } from '../../credentials/register-credentials';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit
{
  invalidRegister: boolean = false;
  isExist!: boolean;

  form = new FormGroup({
    email: new FormControl('', [
      Validators.required,
      Validators.email
    ],
    [
      EmailValidators.shouldBeUnique(this.authService)
    ]),
    username: new FormControl('', [
      Validators.required,
      Validators.minLength(4),
      UsernameValidators.cannotContainSpace
    ],
    [
      UsernameValidators.shouldBeUnique(this.authService)
    ]),
    birthday: new FormControl('', [
      Validators.required
    ]),
    aboutInfo: new FormControl('', [
      Validators.required
    ]),
    password: new FormControl('', [
      Validators.required,
      PasswordValidators.cannotContainSpace, 
      PasswordValidators.passwordShouldHaveNumbers,
      PasswordValidators.passwordShouldHaveCapitalCase,
      PasswordValidators.passwordShouldHaveSpecialCharacter
    ])
  });

  constructor(private authService: AuthService, private router: Router) { }

  get email() {
    return this.form.get('email');
  }

  get username() {
    return this.form.get('username');
  }

  get birthday() {
    return this.form.get('birthday');
  }

  get aboutInfo() {
    return this.form.get('aboutInfo')
  }

  get password() {
    return this.form.get('password');
  }

  register(credentials: RegisterCredentials) {
    this.authService.register(credentials)
      .subscribe(result => {
        if(result.errorMessage == null) {
          localStorage.setItem('token', result.token);
          this.router.navigate(['']);
        }
        else {
          this.invalidRegister = true;
        }
      })
  }

  ngOnInit(): void
  {
  }

}
