import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';
import { CustomCookieService } from '../services/custom-cookie.service';
import { AppComponent } from '../app.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
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

  constructor(
    private formBuilder: FormBuilder,
    private service: AuthService,
    private cookieService: CustomCookieService,
    private router: Router,
    private appComponent: AppComponent
  ) {
    if (this.cookieService.token != null) {
      this.router.navigate(['/admin-panel']);
    }

    this.loginForm = this.formBuilder.group({
      login: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  onSubmit(): void {
    this.service.login(this.login?.value, this.password?.value).subscribe({
      next: (response) => {
        this.cookieService.token = response;
        this.appComponent.onLoginSuccess();

        this.router.navigate(['/admin-panel']);
      },
      error: (error) => {
        if (error.status === 401) {
          this.error401 = true;
        } else {
          throw new Error(`${error.status} - ${error.message}`);
        }
      },
    });
  }
}
