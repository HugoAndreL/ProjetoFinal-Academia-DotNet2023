import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExcluirTaaComponent } from './excluir-taa.component';

describe('ExcluirTaaComponent', () => {
  let component: ExcluirTaaComponent;
  let fixture: ComponentFixture<ExcluirTaaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExcluirTaaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExcluirTaaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
