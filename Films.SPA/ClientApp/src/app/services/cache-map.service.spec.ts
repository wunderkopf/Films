import { TestBed } from '@angular/core/testing';

import { CacheMapService } from './cache-map.service';

describe('CacheMapService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CacheMapService = TestBed.get(CacheMapService);
    expect(service).toBeTruthy();
  });
});
