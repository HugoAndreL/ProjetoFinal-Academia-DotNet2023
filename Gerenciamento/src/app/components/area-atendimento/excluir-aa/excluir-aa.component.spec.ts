import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExcluirAaComponent } from './excluir-aa.component';

describe('ExcluirAaComponent', () => {
  let component: ExcluirAaComponent;
  let fixture: ComponentFixture<ExcluirAaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExcluirAaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExcluirAaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
