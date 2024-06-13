import { Component } from '@angular/core';
import { CustomCookieService } from '../services/custom-cookie.service';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import { Token } from '../models/token';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrl: './admin-panel.component.css'
})
export class AdminPanelComponent {
  decodedToken: Token;
  username: string;

  constructor(private cookieService: CustomCookieService, private router: Router) {
    if(this.cookieService.token == null) {
      this.router.navigate(['/login']);
    }

    this.decodedToken = jwtDecode(this.cookieService.token ?? '');
    this.username = this.decodedToken.sub;
  }
}
