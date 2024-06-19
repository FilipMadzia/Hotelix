import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { AppConfigService } from './app-config.service';

@Injectable({
  providedIn: 'root'
})
export class CustomCookieService {
  constructor(private cookieService: CookieService, private config: AppConfigService) { }

  get token(): string | null {
    var token = this.cookieService.get('token');

    if(token == '')
      return null;
    else
      return token;
  }

  set token(value: string) {
    var expireDate = new Date();
    expireDate.setMinutes(expireDate.getMinutes() + this.config.tokenExpireTime);

    this.cookieService.set('token', value, expireDate);
  }
}
