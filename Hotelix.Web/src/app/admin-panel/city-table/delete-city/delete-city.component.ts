import { Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { City } from '../../../models/city';
import { CitiesService } from '../../../services/cities.service';

@Component({
  selector: 'app-delete-city',
  templateUrl: './delete-city.component.html',
  styleUrl: './delete-city.component.css'
})
export class DeleteCityComponent {
  @ViewChild('closeButton') closeButton?: ElementRef;
  @Input() city: City | undefined;
  @Output() onCityDelete = new EventEmitter<City>();

  constructor(private citiesService: CitiesService) {}

  deleteCity(): void {
    this.citiesService.deleteCity(this.city?.id ?? -1).subscribe(() => {
      this.onCityDelete.emit(this.city);
    });

    this.closeButton?.nativeElement.click();
  }
}
