import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppConfigService } from './app-config.service';
import { City } from '../models/city';
import { Observable } from 'rxjs';
import { CustomCookieService } from './custom-cookie.service';

@Injectable({
  providedIn: 'root'
})
export class CitiesService {
  baseUrl: string;
  headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(
    private http: HttpClient,
    private config: AppConfigService,
    private cookieService: CustomCookieService
  ) {
    this.baseUrl = this.config.apiBaseUrl;
  }

  getCities(): Observable<City[]> {
    return this.http.get<City[]>(this.baseUrl + 'Cities', {
      headers: this.headers
    });
  }

  getCity(id: number | string): Observable<City> {
    return this.http.get<City>(this.baseUrl + 'Cities/' + id, {
      headers: this.headers
    });
  }

  addCity(name: string): Observable<any> {
    return this.http.post<City>(
      this.baseUrl + 'Cities',
      { name },
      {
        headers: new HttpHeaders().set(
          'Authorization',
          'Bearer ' + this.cookieService.token
        ),
      }
    );
  }

  deleteCity(id: number | string): Observable<any> {
    return this.http.delete<City>(this.baseUrl + 'Cities/' + id, {
      headers: new HttpHeaders().set(
        'Authorization',
        'Bearer ' + this.cookieService.token
      ),
    });
  }

  updateCity(id: number | string, name: string): Observable<any> {
    return this.http.put<City>(this.baseUrl + 'Cities/' + id,
      { name },
      {
        headers: new HttpHeaders().set(
          'Authorization',
          'Bearer ' + this.cookieService.token
        )
      }
    );
  }
}
