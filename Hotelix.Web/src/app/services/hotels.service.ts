import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Hotel } from '../models/hotel';
import { Observable, catchError, map, retry, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HotelsService {
  baseUrl = 'http://localhost:5000/api';
  coverImagesUrl = 'http://localhost:5000/Images/Covers/';
  headers = new HttpHeaders({'Content-Type': 'application/json'});

  constructor(private http: HttpClient) { }

  getHotels(): Observable<Hotel[]> {
    return this.http
      .get<Hotel[]>(this.baseUrl + '/Hotels', { headers: this.headers })
      .pipe(
        retry(1),
        catchError(this.handleError),
        map((hotels: Hotel[]) => 
          hotels.map(hotel => {
            hotel.coverImage = this.coverImagesUrl + hotel.coverImage;

            return hotel;
          })
        ));
  }

  getHotel(id: number | string): Observable<Hotel> {
    return this.http
      .get<Hotel>(this.baseUrl + '/Hotels/' + id, { headers: this.headers })
      .pipe(
        retry(1),
        catchError(this.handleError),
        map((hotel: Hotel) => {
          hotel.coverImage = this.coverImagesUrl + hotel.coverImage;

          return hotel;
        })
      );
  }

  handleError(error: any) {
    let errorMessage = '';

    if(error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    }
    else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    
    window.alert(errorMessage);

    return throwError(() => {
      return errorMessage;
    });
  }
}
