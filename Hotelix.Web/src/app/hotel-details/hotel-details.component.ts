import { Component } from '@angular/core';
import { ActivatedRoute, ParamMap, Router, RouterLink } from '@angular/router';
import { HotelsService } from '../services/hotels.service';
import { Hotel } from '../models/hotel';
import { Observable, switchMap } from 'rxjs';
import { AsyncPipe, NgIf } from '@angular/common';

@Component({
  selector: 'app-hotel-details',
  standalone: true,
  imports: [AsyncPipe, NgIf, RouterLink],
  templateUrl: './hotel-details.component.html',
  styleUrl: './hotel-details.component.css',
})
export class HotelDetailsComponent {
  hotel: Observable<Hotel> | undefined;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private hotelsService: HotelsService
  ) {}

  ngOnInit() {
    this.hotel = this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
        this.hotelsService.getHotel(params.get('id')!)
      )
    );
  }
}
