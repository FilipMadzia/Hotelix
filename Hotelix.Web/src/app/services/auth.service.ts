import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AppConfigService } from '../app-config.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  apiBaseUrl: string;
  headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient, private config: AppConfigService) {
    this.apiBaseUrl = config.apiBaseUrl;
  }

  login(username: string, password: string): Observable<string> {
    return this.http
      .post(
        this.apiBaseUrl + 'Auth',
        { username, password },
        { headers: this.headers, responseType: 'text' },
      )
  }
}
