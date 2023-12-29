import { TestBed } from '@angular/core/testing';

import { SenhaService } from './senha.service';

describe('SenhaService', () => {
  let service: SenhaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SenhaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
