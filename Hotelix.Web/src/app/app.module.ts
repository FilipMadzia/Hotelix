import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { HotelsComponent } from './hotels/hotels.component';
import { HotelDetailsComponent } from './hotel-details/hotel-details.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { LoginComponent } from './login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { CityTableComponent } from './admin-panel/city-table/city-table.component';
import { AddCityComponent } from './admin-panel/city-table/add-city/add-city.component';
import { DeleteCityComponent } from './admin-panel/city-table/delete-city/delete-city.component';
import { CityDetailsComponent } from './admin-panel/city-table/city-details/city-details.component';
import { UpdateCityComponent } from './admin-panel/city-table/update-city/update-city.component';
import { HotelTableComponent } from './admin-panel/hotel-table/hotel-table.component';
import { HotelDetailsComponent as HotelDetailsComponentAdmin } from './admin-panel/hotel-table/hotel-details/hotel-details.component';
import { DeleteHotelComponent } from './admin-panel/hotel-table/delete-hotel/delete-hotel.component';

@NgModule({
  declarations: [
    AppComponent,
    PageNotFoundComponent,
    LoginComponent,
    AddCityComponent,
    AdminPanelComponent,
    CityTableComponent,
    DeleteCityComponent,
    CityDetailsComponent,
    UpdateCityComponent,
    HotelTableComponent,
    HotelDetailsComponentAdmin,
    DeleteHotelComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    HotelsComponent,
    HotelDetailsComponent,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  providers: [CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
