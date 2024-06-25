import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CityTableComponent } from './city-table.component';

describe('CityTableComponent', () => {
  let component: CityTableComponent;
  let fixture: ComponentFixture<CityTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CityTableComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CityTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
