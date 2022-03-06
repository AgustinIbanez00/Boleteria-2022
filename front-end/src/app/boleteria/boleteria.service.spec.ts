import { TestBed } from '@angular/core/testing';

import { BoleteriaService } from './boleteria.service';

describe('BoleteriaService', () => {
  let service: BoleteriaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BoleteriaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
