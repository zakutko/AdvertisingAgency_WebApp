import { TestBed } from '@angular/core/testing';

import { AdvertisementsService } from './advertisements.service';

describe('AdvertisementsService', () => {
  let service: AdvertisementsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdvertisementsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
