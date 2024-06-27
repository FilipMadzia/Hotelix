import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HotelDetailsComponent } from './hotel-details/hotel-details.component';
import { HotelsComponent } from './hotels/hotels.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { LoginComponent } from './login/login.component';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';
import { CityDetailsComponent } from './admin-panel/city-table/city-details/city-details.component';

const routes: Routes = [
  { path: 'hotel-details/:id', component: HotelDetailsComponent },
  { path: 'hotels', component: HotelsComponent },
  { path: 'login', component: LoginComponent },
  { path: 'admin-panel', component: AdminPanelComponent },
  { path: 'admin-panel/city-details/:id', component: CityDetailsComponent },
  { path: '', redirectTo: '/hotels', pathMatch: 'full' },
  { path: '**', component: PageNotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
