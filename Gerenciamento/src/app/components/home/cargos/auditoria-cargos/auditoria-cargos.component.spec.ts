import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuditoriaCargosComponent } from './auditoria-cargos.component';

describe('AuditoriaCargosComponent', () => {
  let component: AuditoriaCargosComponent;
  let fixture: ComponentFixture<AuditoriaCargosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AuditoriaCargosComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AuditoriaCargosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
