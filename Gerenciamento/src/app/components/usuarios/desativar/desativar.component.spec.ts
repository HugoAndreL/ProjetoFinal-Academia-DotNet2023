import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DesativarComponent } from './desativar.component';

describe('DesativarComponent', () => {
  let component: DesativarComponent;
  let fixture: ComponentFixture<DesativarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DesativarComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DesativarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
