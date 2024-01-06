import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdicionarCargoComponent } from './adicionar-cargo.component';

describe('AdicionarCargoComponent', () => {
  let component: AdicionarCargoComponent;
  let fixture: ComponentFixture<AdicionarCargoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AdicionarCargoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdicionarCargoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
