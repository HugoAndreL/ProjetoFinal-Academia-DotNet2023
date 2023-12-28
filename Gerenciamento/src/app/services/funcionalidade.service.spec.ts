import { TestBed } from '@angular/core/testing';

import { FuncionalidadeService } from './funcionalidade.service';

describe('FuncionalidadeService', () => {
  let service: FuncionalidadeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FuncionalidadeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
