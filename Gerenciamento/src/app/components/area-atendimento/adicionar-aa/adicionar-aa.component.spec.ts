import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdicionarAaComponent } from './adicionar-aa.component';

describe('AdicionarAaComponent', () => {
  let component: AdicionarAaComponent;
  let fixture: ComponentFixture<AdicionarAaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AdicionarAaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdicionarAaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
