import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoverComponent } from './remover.component';

describe('RemoverComponent', () => {
  let component: RemoverComponent;
  let fixture: ComponentFixture<RemoverComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RemoverComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RemoverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
