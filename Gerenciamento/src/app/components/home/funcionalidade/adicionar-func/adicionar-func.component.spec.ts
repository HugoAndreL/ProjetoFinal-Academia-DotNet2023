import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdicionarFuncComponent } from './adicionar-func.component';

describe('AdicionarFuncComponent', () => {
  let component: AdicionarFuncComponent;
  let fixture: ComponentFixture<AdicionarFuncComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AdicionarFuncComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdicionarFuncComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
