import { Component, ElementRef, EventEmitter, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Hotel } from '../../../models/hotel';
import { HotelsService } from '../../../services/hotels.service';
import { HotelAdd } from '../../../models/hotelAdd';

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

  get description() {
    return this.addHotelForm.get('description');
  }

  get pricePerNight() {
    return this.addHotelForm.get('pricePerNight');
  }

  get hasInternet() {
    return this.addHotelForm.get('hasInternet');
  }

  get hasTelevision() {
    return this.addHotelForm.get('hasTelevision');
  }

  get hasParking() {
    return this.addHotelForm.get('hasParking');
  }

  get hasCafeteria() {
    return this.addHotelForm.get('hasCafeteria');
  }

  get coverImage() {
    return this.addHotelForm.get('coverImage');
  }

  constructor(
    private formBuilder: FormBuilder,
    private hotelsService: HotelsService
  ) {
    this.addHotelForm = this.formBuilder.group({
      hotelName: ['Hotel name', Validators.required],
      description: [null],
      pricePerNight: [50.00, Validators.required],
      hasInternet: [false],
      hasTelevision: [true],
      hasParking: [false],
      hasCafeteria: [true],
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
    let hotelToAdd: HotelAdd = {
      name: this.hotelName!.value,
      description: this.description?.value,
      pricePerNight: this.pricePerNight!.value,
      hasInternet: this.hasInternet!.value,
      hasTelevision: this.hasTelevision!.value,
      hasParking: this.hasParking!.value,
      hasCafeteria: this.hasCafeteria!.value,
      coverImage: new Blob(),
      address: {
        street: '',
        houseNumber: 0,
        postalCode: '',
        cityId: 0
      },
      contact: {
        phoneNumber: undefined,
        email: undefined
      }
    };

    this.hotelsService.addHotel(hotelToAdd).subscribe((data: Hotel) => {
      this.onHotelAdd.emit(data);
    });

    this.closeButton.nativeElement.click();
  }
}
