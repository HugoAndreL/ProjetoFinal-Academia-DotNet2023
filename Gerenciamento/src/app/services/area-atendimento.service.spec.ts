import { TestBed } from '@angular/core/testing';

import { AreaAtendimentoService } from './area-atendimento.service';

describe('AreaAtendimentoService', () => {
  let service: AreaAtendimentoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AreaAtendimentoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
