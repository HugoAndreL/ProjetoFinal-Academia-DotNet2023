import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlterarAaComponent } from './alterar-aa.component';

describe('AlterarAaComponent', () => {
  let component: AlterarAaComponent;
  let fixture: ComponentFixture<AlterarAaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AlterarAaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AlterarAaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
