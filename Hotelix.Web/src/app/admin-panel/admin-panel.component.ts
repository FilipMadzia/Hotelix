import { Component, ElementRef, ViewChild } from '@angular/core';
import { CustomCookieService } from '../services/custom-cookie.service';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';
import { Token } from '../models/token';
import { CitiesService } from '../services/cities.service';
import { City } from '../models/city';
import { Hotel } from '../models/hotel';
import { HotelsService } from '../services/hotels.service';
import { AppComponent } from '../app.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-admin-panel',
  templateUrl: './admin-panel.component.html',
  styleUrl: './admin-panel.component.css',
})
export class AdminPanelComponent {
  decodedToken: Token;
  username: string;
  addCityForm: FormGroup;
  @ViewChild('closeButton') closeButton?: ElementRef;

  cities: City[] = [];
  hotels: Hotel[] = [];

  constructor(
    private cookieService: CustomCookieService,
    private router: Router,
    private citiesService: CitiesService,
    private hotelsService: HotelsService,
    private appComponent: AppComponent,
    private formBuilder: FormBuilder
  ) {
    if (this.cookieService.token == null) {
      this.router.navigate(['/login']);
    }

    this.decodedToken = jwtDecode(this.cookieService.token ?? '');
    this.username = this.decodedToken.sub;

    // add city form
    this.addCityForm = this.formBuilder.group({
      cityName: ['', Validators.required],
    });
  }

  get cityName() {
    return this.addCityForm.get('cityName');
  }

  ngOnInit() {
    this.citiesService
      .getCities()
      .subscribe((data: City[]) => (this.cities = data));
    this.hotelsService
      .getHotels()
      .subscribe((data: Hotel[]) => (this.hotels = data));
  }

  logout(): void {
    this.cookieService.token = '';
    this.appComponent.onLogout();
    this.router.navigate(['/login']);
  }

  addCity(): void {
    this.citiesService.addCity(this.cityName?.value).subscribe(() => {
      var newCity: City = {
        id: this.cities[this.cities.length - 1].id + 1,
        name: this.cityName?.value
      };

      this.cities.push(newCity);
    });

    this.closeButton?.nativeElement.click();
  }

  deleteCity(id: number | string): void {
    this.citiesService.deleteCity(id).subscribe(() => {
      this.cities = this.cities.filter((city) => city.id != id);
      this.hotels = this.hotels.filter((hotel) => hotel.address.city.id != id);
    });
  }

  addHotel(): void {
    console.log('add hotel');
  }

  deleteHotel(id: number | string): void {
    this.hotelsService.deleteHotel(id).subscribe(() => {
      this.hotels = this.hotels.filter((hotel) => hotel.id != id);
    });
  }
}
