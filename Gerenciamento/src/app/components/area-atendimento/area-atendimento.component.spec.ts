import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AreaAtendimentoComponent } from './area-atendimento.component';

describe('AreaAtendimentoComponent', () => {
  let component: AreaAtendimentoComponent;
  let fixture: ComponentFixture<AreaAtendimentoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AreaAtendimentoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AreaAtendimentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
