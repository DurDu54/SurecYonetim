import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MusteriEkleComponent } from './musteri-ekle.component';

describe('MusteriEkleComponent', () => {
  let component: MusteriEkleComponent;
  let fixture: ComponentFixture<MusteriEkleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MusteriEkleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MusteriEkleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
