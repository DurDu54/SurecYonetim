import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MusteriTalepDuzenleComponent } from './musteri-talep-duzenle.component';

describe('MusteriTalepDuzenleComponent', () => {
  let component: MusteriTalepDuzenleComponent;
  let fixture: ComponentFixture<MusteriTalepDuzenleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MusteriTalepDuzenleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MusteriTalepDuzenleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
