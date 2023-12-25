import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoAreaAtendimentoComponent } from './tipo-area-atendimento.component';

describe('TipoAreaAtendimentoComponent', () => {
  let component: TipoAreaAtendimentoComponent;
  let fixture: ComponentFixture<TipoAreaAtendimentoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TipoAreaAtendimentoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TipoAreaAtendimentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
