import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm: FormGroup;
  error401: boolean = false;

  get login() {
    return this.loginForm.get('login');
  }

  get password() {
    return this.loginForm.get('password');
  }

  constructor(private formBuilder: FormBuilder, private service: AuthService, private cookieService: CookieService) {
    this.loginForm = this.formBuilder.group({
      login: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit(): void {
    this.service.login(this.login?.value, this.password?.value).subscribe({
      next: (response) => {
        this.error401 = false;
        this.cookieService.set('token', response);
      },
      error: (error) => {
        this.error401 = true;
      },
    });
  }
}
