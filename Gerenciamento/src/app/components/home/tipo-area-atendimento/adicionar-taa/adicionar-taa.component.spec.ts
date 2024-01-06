import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdicionarTaaComponent } from './adicionar-taa.component';

describe('AdicionarTaaComponent', () => {
  let component: AdicionarTaaComponent;
  let fixture: ComponentFixture<AdicionarTaaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AdicionarTaaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdicionarTaaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
