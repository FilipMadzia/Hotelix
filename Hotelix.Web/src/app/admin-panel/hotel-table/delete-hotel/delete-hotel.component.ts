import { Component, ElementRef, EventEmitter, Input, Output, ViewChild } from '@angular/core';
import { City } from '../../../models/city';
import { Hotel } from '../../../models/hotel';
import { HotelsService } from '../../../services/hotels.service';

@Component({
  selector: 'app-delete-hotel',
  templateUrl: './delete-hotel.component.html',
  styleUrl: './delete-hotel.component.css'
})
export class DeleteHotelComponent {
  @ViewChild('closeButton') closeButton?: ElementRef;
  @Input() hotel: Hotel | undefined;
  @Output() onHotelDelete = new EventEmitter<Hotel>();

  constructor(private hotelsService: HotelsService) {}

  deleteHotel(): void {
    this.hotelsService.deleteHotel(this.hotel?.id ?? -1).subscribe(() => {
      this.onHotelDelete.emit(this.hotel);
    });

    this.closeButton?.nativeElement.click();
  }
}
