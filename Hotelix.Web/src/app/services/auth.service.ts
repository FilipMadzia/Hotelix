import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, retry, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = 'http://localhost:5000/api';
  headers = new HttpHeaders({'Content-Type': 'application/json'});

  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<string> {   
    return this.http
      .post(this.baseUrl + '/Auth',
        { username, password },
        { headers: this.headers, responseType: 'text' });
  }
}
