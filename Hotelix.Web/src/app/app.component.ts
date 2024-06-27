import { Component, Injectable } from '@angular/core';
import { CustomCookieService } from './services/custom-cookie.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  loggedIn: boolean = false;

  constructor(private cookieService: CustomCookieService, private router: Router) {
    if(this.cookieService.token != null) {
      this.loggedIn = true;
    }
  }

  onLoginSuccess(): void {
    this.loggedIn = true;
  }

  onLogout(): void {
    this.cookieService.token = '';
    this.loggedIn = false;
    this.router.navigate(['/login']);
  }
}
