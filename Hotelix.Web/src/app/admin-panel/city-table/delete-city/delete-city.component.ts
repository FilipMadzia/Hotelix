import { Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { City } from '../../../models/city';
import { CitiesService } from '../../../services/cities.service';
import { HttpErrorResponse } from '@angular/common/http';
import { AppComponent } from '../../../app.component';

@Component({
  selector: 'app-delete-city',
  templateUrl: './delete-city.component.html',
  styleUrl: './delete-city.component.css'
})
export class DeleteCityComponent {
  @ViewChild('closeButton') closeButton?: ElementRef;
  @Input() city: City | undefined;
  @Output() onCityDelete = new EventEmitter<City>();

  constructor(private citiesService: CitiesService, private appComponent: AppComponent) {}

  deleteCity(): void {
    this.citiesService.deleteCity(this.city?.id ?? -1).subscribe({
      next: () => {
        this.onCityDelete.emit(this.city);
      },
      error: (error: HttpErrorResponse) => {
        if(error.status === 401) {
          this.appComponent.onLogout();
        }
      }
    });

    this.closeButton?.nativeElement.click();
  }
}
