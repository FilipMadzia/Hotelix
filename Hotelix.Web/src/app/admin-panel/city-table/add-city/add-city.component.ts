import {
  Component,
  ElementRef,
  EventEmitter,
  Output,
  ViewChild,
} from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { City } from '../../../models/city';
import { CitiesService } from '../../../services/cities.service';

@Component({
  selector: 'app-add-city',
  templateUrl: './add-city.component.html',
  styleUrl: './add-city.component.css',
})
export class AddCityComponent {
  addCityForm: FormGroup;
  @ViewChild('closeButton') closeButton!: ElementRef;
  @ViewChild('cityNameInput') cityNameInput!: ElementRef;
  @Output() onCityAdd = new EventEmitter<City>();

  get cityName() {
    return this.addCityForm.get('cityName');
  }

  ngAfterViewInit() {
    document.getElementById('addCityModal')!.addEventListener('shown.bs.modal', () => {
      this.cityNameInput.nativeElement.focus();
    });
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
    this.citiesService.addCity(this.cityName?.value).subscribe((data: City) => {
      this.onCityAdd.emit(data);
    });

    this.closeButton.nativeElement.click();
  }
}
