import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Hotel } from '../models/hotel';
import { Observable, map } from 'rxjs';
import { AppConfigService } from './app-config.service';
import { CustomCookieService } from './custom-cookie.service';

@Injectable({
  providedIn: 'root',
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

  deleteHotel(id: number | string): Observable<any> {
    return this.http.delete<Hotel>(this.baseUrl + 'Hotels/' + id, {
      headers: new HttpHeaders().set(
        'Authorization',
        'Bearer ' + this.cookieService.token
      ),
    })
    // .pipe(catchError(this.errorHandler));
  }

  // errorHandler(error: HttpErrorResponse) {
  //   if (error.error instanceof ErrorEvent) {
  //     // A client-side or network error occurred. Handle it accordingly.
  //     console.error('An error occurred:', error.error.message);
  //   } else if(error.status === 401) {
  //     this.appComponent.onLogout();
  //   }

  //   return throwError(() => new Error('Something else went wrong'));
  // }
}
