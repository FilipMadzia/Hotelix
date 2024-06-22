import { Component, ElementRef, Injectable, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CitiesService } from '../services/cities.service';

@Injectable({
  providedIn: 'root'
})
@Component({
  selector: 'app-add-city',
  templateUrl: './add-city.component.html',
  styleUrl: './add-city.component.css',
})
export class AddCityComponent {
  addCityForm: FormGroup;
  @ViewChild('closeButton') closeButton?: ElementRef;
  
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
    this.citiesService.addCity(this.cityName?.value).subscribe(() => {});

    this.closeButton?.nativeElement.click();
  }
}
