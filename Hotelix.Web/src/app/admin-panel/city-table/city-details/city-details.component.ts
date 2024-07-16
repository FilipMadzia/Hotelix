import { Component } from '@angular/core';
import { CustomCookieService } from '../../../services/custom-cookie.service';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { AppComponent } from '../../../app.component';
import { City } from '../../../models/city';
import { Observable, switchMap } from 'rxjs';
import { CitiesService } from '../../../services/cities.service';

@Component({
  selector: 'app-city-details',
  templateUrl: './city-details.component.html',
  styleUrl: './city-details.component.css',
})
export class CityDetailsComponent {
  city: Observable<City> | undefined;

  constructor(
    private citiesService: CitiesService,
    private cookieService: CustomCookieService,
    private route: ActivatedRoute,
    private router: Router,
    private appComponent: AppComponent,
  ) {
    if (this.cookieService.token == null) {
      this.logout();
    }
  }

  ngOnInit() {
    this.city = this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
      this.citiesService.getCity(params.get('id')!))
    );
  }

  onCityDelete(city: City) {
    this.router.navigate(['/admin-panel']);
  }

  onCityUpdate(city: City) {
    this.city?.subscribe(x => x.name = city.name);
  }

  logout(): void {
    this.cookieService.token = '';
    this.appComponent.onLogout();
    this.router.navigate(['/login']);
  }
}
