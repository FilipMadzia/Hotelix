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
import { AppComponent } from '../../../app.component';
import { HttpErrorResponse } from '@angular/common/http';

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
    private citiesService: CitiesService,
    private appComponent: AppComponent
  ) {
    this.addCityForm = this.formBuilder.group({
      cityName: ['', Validators.required],
    });
  }

  addCity(): void {
    this.citiesService.addCity(this.cityName?.value).subscribe({
      next: (data: City) => {
        this.onCityAdd.emit(data);
      },
      error: (error: HttpErrorResponse) => {
        if(error.status === 401) {
          this.appComponent.onLogout();
        }
      }
    });

    this.closeButton.nativeElement.click();
  }
}
