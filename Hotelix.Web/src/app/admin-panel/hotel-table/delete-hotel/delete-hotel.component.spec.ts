import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteHotelComponent } from './delete-hotel.component';

describe('DeleteHotelComponent', () => {
  let component: DeleteHotelComponent;
  let fixture: ComponentFixture<DeleteHotelComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DeleteHotelComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DeleteHotelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
