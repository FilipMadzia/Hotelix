import { Component } from '@angular/core';
import { City } from '../../models/city';
import { CitiesService } from '../../services/cities.service';

@Component({
  selector: 'app-city-table',
  templateUrl: './city-table.component.html',
  styleUrl: './city-table.component.css',
})
export class CityTableComponent {
  cities: City[] = [];

  constructor(private citiesService: CitiesService) {}

  ngOnInit() {
    this.citiesService
      .getCities()
      .subscribe((data: City[]) => (this.cities = data));
  }

  onCityAdd(city: City) {
    var newCity: City = {
      id: city.id,
      name: city.name,
    };

    this.cities.push(newCity);
  }

  onCityDelete(deletedCity: City) {
    this.cities = this.cities.filter((city) => city.id != deletedCity.id);
  }
}
