import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuditoriaUsuarioComponent } from './auditoria-usuario.component';

describe('AuditoriaUsuarioComponent', () => {
  let component: AuditoriaUsuarioComponent;
  let fixture: ComponentFixture<AuditoriaUsuarioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AuditoriaUsuarioComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AuditoriaUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
