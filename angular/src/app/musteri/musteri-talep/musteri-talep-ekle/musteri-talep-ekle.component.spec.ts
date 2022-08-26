import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MusteriTalepEkleComponent } from './musteri-talep-ekle.component';

describe('MusteriTalepEkleComponent', () => {
  let component: MusteriTalepEkleComponent;
  let fixture: ComponentFixture<MusteriTalepEkleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MusteriTalepEkleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MusteriTalepEkleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
