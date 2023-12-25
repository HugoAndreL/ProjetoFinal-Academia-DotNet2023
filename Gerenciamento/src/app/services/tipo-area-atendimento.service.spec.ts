import { TestBed } from '@angular/core/testing';

import { TipoAreaAtendimentoService } from './tipo-area-atendimento.service';

describe('TipoAreaAtendimentoService', () => {
  let service: TipoAreaAtendimentoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TipoAreaAtendimentoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
