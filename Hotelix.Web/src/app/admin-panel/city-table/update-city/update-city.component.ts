import { Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { Observable, switchMap } from 'rxjs';
import { City } from '../../../models/city';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { CitiesService } from '../../../services/cities.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-update-city',
  templateUrl: './update-city.component.html',
  styleUrl: './update-city.component.css'
})
export class UpdateCityComponent {
  cityForm!: FormGroup;
  @ViewChild('closeButton') closeButton!: ElementRef;
  @ViewChild('cityNameInput') cityNameInput!: ElementRef;
  @Input() city: City | undefined;
  @Output() onCityUpdate = new EventEmitter<City>();

  get cityName() {
    return this.cityForm.get('cityName');
  }

  constructor(
    private citiesService: CitiesService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    this.cityForm = this.formBuilder.group({
      cityName: [this.city?.name, Validators.required],
    });
  }

  ngAfterViewInit() {
    document.getElementById('updateCityModal')!.addEventListener('shown.bs.modal', () => {
      this.cityNameInput.nativeElement.focus();
    });
  }

  updateCity() {
    this.citiesService.updateCity(this.city?.id ?? -1, this.cityName?.value).subscribe(() => {
      this.city!.name = this.cityName?.value;
      this.onCityUpdate.emit(this.city);
    });
    this.closeButton.nativeElement.click();
  }
}
