import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DesativarCargoComponent } from './desativar-cargo.component';

describe('DesativarCargoComponent', () => {
  let component: DesativarCargoComponent;
  let fixture: ComponentFixture<DesativarCargoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DesativarCargoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DesativarCargoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
