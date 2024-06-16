import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  loggedIn: boolean = false;

  constructor() { }

  onLoginSuccess(): void {
    this.loggedIn = true;
  }

  onLogout(): void {
    this.loggedIn = false;
  }
}
