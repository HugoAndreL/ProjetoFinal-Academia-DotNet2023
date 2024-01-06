import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssoicarFuncComponent } from './assoicar-func.component';

describe('AssoicarFuncComponent', () => {
  let component: AssoicarFuncComponent;
  let fixture: ComponentFixture<AssoicarFuncComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AssoicarFuncComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AssoicarFuncComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
