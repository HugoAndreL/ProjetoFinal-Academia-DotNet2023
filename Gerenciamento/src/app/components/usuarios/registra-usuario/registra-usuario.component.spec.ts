import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistraUsuarioComponent } from './registra-usuario.component';

describe('RegistraUsuarioComponent', () => {
  let component: RegistraUsuarioComponent;
  let fixture: ComponentFixture<RegistraUsuarioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RegistraUsuarioComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RegistraUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
