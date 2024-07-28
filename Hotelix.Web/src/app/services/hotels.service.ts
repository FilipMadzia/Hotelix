import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Hotel } from '../models/hotel';
import { Observable, catchError, map, retry, throwError } from 'rxjs';
import { AppConfigService } from './app-config.service';
import { CustomCookieService } from './custom-cookie.service';
import { HotelAdd } from '../models/hotelAdd';

@Injectable({
  providedIn: 'root'
})
export class HotelsService {
  baseUrl: string;
  coverImagesUrl: string;
  headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(
    private http: HttpClient,
    private config: AppConfigService,
    private cookieService: CustomCookieService
  ) {
    this.baseUrl = this.config.apiBaseUrl;
    this.coverImagesUrl = this.config.coverImagesBaseUrl;
  }

  getHotels(): Observable<Hotel[]> {
    return this.http
      .get<Hotel[]>(this.baseUrl + 'Hotels', { headers: this.headers })
      .pipe(
        map((hotels: Hotel[]) =>
          hotels.map((hotel) => {
            hotel.coverImage = this.coverImagesUrl + hotel.coverImage;

            return hotel;
          })
        )
      );
  }

  getHotel(id: number | string): Observable<Hotel> {
    return this.http
      .get<Hotel>(this.baseUrl + 'Hotels/' + id, { headers: this.headers })
      .pipe(
        map((hotel: Hotel) => {
          hotel.coverImage = this.coverImagesUrl + hotel.coverImage;

          return hotel;
        })
      );
  }

  addHotel(hotel: HotelAdd) : Observable<any> {
    return this.http.post<Hotel>(
      this.baseUrl + 'Hotels/',
      hotel,
      {
        headers: new HttpHeaders().set(
          'Authorization',
          'Bearer ' + this.cookieService.token
        )
      }
    );
  }

  deleteHotel(id: number | string): Observable<any> {
    return this.http.delete<Hotel>(this.baseUrl + 'Hotels/' + id, {
      headers: new HttpHeaders().set(
        'Authorization',
        'Bearer ' + this.cookieService.token
      ),
    });
  }
}
