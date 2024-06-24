import {
  Component,
  ElementRef,
  EventEmitter,
  Injectable,
  Output,
  ViewChild,
} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CitiesService } from '../services/cities.service';
import { City } from '../models/city';

@Injectable({
  providedIn: 'root',
})
@Component({
  selector: 'app-add-city',
  templateUrl: './add-city.component.html',
  styleUrl: './add-city.component.css',
})
export class AddCityComponent {
  addCityForm: FormGroup;
  @ViewChild('closeButton') closeButton?: ElementRef;
  @Output() onCityAdd = new EventEmitter<City>();

  get cityName() {
    return this.addCityForm.get('cityName');
  }

  constructor(
    private formBuilder: FormBuilder,
    private citiesService: CitiesService
  ) {
    this.addCityForm = this.formBuilder.group({
      cityName: ['', Validators.required],
    });
  }

  addCity(): void {
    this.citiesService
      .addCity(this.cityName?.value)
      .subscribe((data: City) => {
        this.onCityAdd.emit(data);
      });

    this.closeButton?.nativeElement.click();
  }
}
