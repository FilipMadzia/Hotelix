import { Component } from '@angular/core';
import { Observable, switchMap } from 'rxjs';
import { Hotel } from '../../../models/hotel';
import { HotelsService } from '../../../services/hotels.service';
import { CustomCookieService } from '../../../services/custom-cookie.service';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { AppComponent } from '../../../app.component';

@Component({
  selector: 'app-hotel-details',
  templateUrl: './hotel-details.component.html',
  styleUrl: './hotel-details.component.css'
})
export class HotelDetailsComponent {
  hotel: Observable<Hotel> | undefined;

  constructor(
    private hotelsService: HotelsService,
    private cookieService: CustomCookieService,
    private route: ActivatedRoute,
    private router: Router,
    private appComponent: AppComponent
  ) {
    if(this.cookieService.token == null) {
      this.logout();
    }
  }

  ngOnInit() {
    this.hotel = this.route.paramMap.pipe(
      switchMap((params: ParamMap) =>
      this.hotelsService.getHotel(params.get('id')!))
    );
  }

  logout(): void {
    this.cookieService.token = '';
    this.appComponent.onLogout();
    this.router.navigate(['/login']);
  }
}
