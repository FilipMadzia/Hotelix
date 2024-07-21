import { Component, ElementRef, EventEmitter, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Hotel } from '../../../models/hotel';
import { HotelsService } from '../../../services/hotels.service';

@Component({
  selector: 'app-add-hotel',
  templateUrl: './add-hotel.component.html',
  styleUrl: './add-hotel.component.css'
})
export class AddHotelComponent {
  addHotelForm: FormGroup;
  @ViewChild('closeButton') closeButton!: ElementRef;
  @ViewChild('hotelNameInput') hotelNameInput!: ElementRef;
  @Output() onHotelAdd = new EventEmitter<Hotel>();

  ngAfterViewInit() {
    document.getElementById('addHotelModal')!.addEventListener('shown.bs.modal', () => {
      this.hotelNameInput.nativeElement.focus();
    });
  }

  get hotelName() {
    return this.addHotelForm.get('hotelName');
  }

  constructor(
    private formBuilder: FormBuilder,
    private hotelsService: HotelsService
  ) {
    this.addHotelForm = this.formBuilder.group({
      hotelName: ['', Validators.required],
      description: [null],
      pricePerNight: [0, Validators.required],
      hasInternet: [false],
      hasTelevision: [false],
      hasParking: [false],
      hasCafeteria: [false],
      coverImage: [new Blob()],
      address: this.formBuilder.group({
        street: ['', Validators.required],
        houseNumber: [0, Validators.required],
        postalCode: ['', Validators.required],
        cityId: [0]
      }),
      contact: this.formBuilder.group({
        phoneNumber: [null],
        email: [null]
      })
    });
  }

  addHotel() {

  }
}
