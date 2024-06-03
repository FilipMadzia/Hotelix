import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginForm = this.formBuilder.group({
    login: ['test', Validators.required],
    password: ['test', Validators.required]
  });

  get login() {
    return this.loginForm.get('login')?.value;
  }

  get password() {
    return this.loginForm.get('password')?.value;
  }

  constructor(private formBuilder: FormBuilder) { }
}
