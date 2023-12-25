import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlterarTaaComponent } from './alterar-taa.component';

describe('AlterarTaaComponent', () => {
  let component: AlterarTaaComponent;
  let fixture: ComponentFixture<AlterarTaaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AlterarTaaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AlterarTaaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
