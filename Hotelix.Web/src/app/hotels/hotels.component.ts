import { Component } from '@angular/core';
import { HotelsService } from '../services/hotels.service';
import { NgFor } from '@angular/common';

@Component({
  selector: 'app-hotels',
  standalone: true,
  imports: [NgFor],
  templateUrl: './hotels.component.html',
  styleUrl: './hotels.component.css'
})
export class HotelsComponent {
  hotels: any = [];

  constructor(public service: HotelsService) {}

  ngOnInit() {
    this.service.getHotels().subscribe((data: {}) => {
      this.hotels = data;
    })
  }
}
