import { Component } from '@angular/core';
import { CustomCookieService } from './services/custom-cookie.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  loggedIn: boolean = false;

  constructor(private cookieService: CustomCookieService) {
    if(this.cookieService.token != null) {
      this.loggedIn = true;
    }
  }

  onLoginSuccess(): void {
    this.loggedIn = true;
  }

  onLogout(): void {
    this.loggedIn = false;
  }
}
