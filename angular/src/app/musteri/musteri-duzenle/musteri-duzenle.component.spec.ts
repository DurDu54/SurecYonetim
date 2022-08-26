import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MusteriDuzenleComponent } from './musteri-duzenle.component';

describe('MusteriDuzenleComponent', () => {
  let component: MusteriDuzenleComponent;
  let fixture: ComponentFixture<MusteriDuzenleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MusteriDuzenleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MusteriDuzenleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
