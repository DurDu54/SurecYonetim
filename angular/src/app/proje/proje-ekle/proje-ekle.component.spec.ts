import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjeEkleComponent } from './proje-ekle.component';

describe('ProjeEkleComponent', () => {
  let component: ProjeEkleComponent;
  let fixture: ComponentFixture<ProjeEkleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProjeEkleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjeEkleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
