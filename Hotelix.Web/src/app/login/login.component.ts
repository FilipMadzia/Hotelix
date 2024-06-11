import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { CookieService } from 'ngx-cookie-service';
import { Router } from '@angular/router';

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

  constructor(private formBuilder: FormBuilder, private service: AuthService, private cookieService: CookieService, private router: Router) {
    if(this.cookieService.get('token') != null) {
      this.router.navigate(['/admin-panel']);
    }

    this.loginForm = this.formBuilder.group({
      login: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit(): void {
    this.service.login(this.login?.value, this.password?.value).subscribe({
      next: (response) => {
        this.error401 = false;

        const expireDate: Date = new Date();
        expireDate.setDate(expireDate.getDate() + 3);

        this.cookieService.set('token', response, expireDate);

        this.router.navigate(['/admin-panel']);
      },
      error: (error) => {
        this.error401 = true;
      },
    });
  }
}
