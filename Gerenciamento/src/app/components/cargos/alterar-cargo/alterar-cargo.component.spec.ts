import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlterarCargoComponent } from './alterar-cargo.component';

describe('AlterarCargoComponent', () => {
  let component: AlterarCargoComponent;
  let fixture: ComponentFixture<AlterarCargoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AlterarCargoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AlterarCargoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
