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
import { CityAdd } from '../models/city.add';

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
  @Output() onCityAdd = new EventEmitter<CityAdd>();

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
      .subscribe((data: CityAdd) => {
        this.onCityAdd.emit(data);
      });

    this.closeButton?.nativeElement.click();
  }
}
