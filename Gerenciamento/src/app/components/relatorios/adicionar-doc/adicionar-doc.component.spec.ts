import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdicionarDocComponent } from './adicionar-doc.component';

describe('AdicionarDocComponent', () => {
  let component: AdicionarDocComponent;
  let fixture: ComponentFixture<AdicionarDocComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AdicionarDocComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdicionarDocComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
