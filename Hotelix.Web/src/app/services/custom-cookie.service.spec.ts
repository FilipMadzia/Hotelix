import { TestBed } from '@angular/core/testing';

import { CustomCookieService } from './custom-cookie.service';

describe('CustomCookieService', () => {
  let service: CustomCookieService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CustomCookieService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
