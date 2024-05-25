import { Component } from '@angular/core';
import { HotelsService } from '../services/hotels.service';
import { NgFor } from '@angular/common';
import { Hotel } from '../models/hotel';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-hotels',
  standalone: true,
  imports: [NgFor, RouterLink],
  templateUrl: './hotels.component.html',
  styleUrl: './hotels.component.css'
})
export class HotelsComponent {
  hotels: Hotel[] = [];

  constructor(private service: HotelsService) {}

  ngOnInit() {
    this.service.getHotels().subscribe((data: Hotel[]) =>
      this.hotels = data
    );
  }
}
