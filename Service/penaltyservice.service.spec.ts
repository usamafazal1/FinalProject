import { TestBed } from '@angular/core/testing';

import { PenaltyserviceService } from './penaltyservice.service';

describe('PenaltyserviceService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PenaltyserviceService = TestBed.get(PenaltyserviceService);
    expect(service).toBeTruthy();
  });
});
