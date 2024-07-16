import { Component } from '@angular/core';
import { Hotel } from '../../models/hotel';
import { HotelsService } from '../../services/hotels.service';

@Component({
  selector: 'app-hotel-table',
  templateUrl: './hotel-table.component.html',
  styleUrl: './hotel-table.component.css'
})
export class HotelTableComponent {
  hotels: Hotel[] = [];

  constructor(private hotelsService: HotelsService) { }
  
  ngOnInit() {
    this.hotelsService
      .getHotels()
      .subscribe((data: Hotel[]) => this.hotels = data);
  }

  onHotelAdd(hotel: Hotel) {
    var newHotel: Hotel = {
      id: hotel.id,
      name: hotel.name,
      description: hotel.description,
      pricePerNight: hotel.pricePerNight,
      hasInternet: hotel.hasInternet,
      hasTelevision: hotel.hasTelevision,
      hasParking: hotel.hasParking,
      hasCafeteria: hotel.hasCafeteria,
      coverImage: hotel.coverImage,
      address: hotel.address,
      contact: hotel.contact
    }

    this.hotels.push(newHotel);
  }
}
