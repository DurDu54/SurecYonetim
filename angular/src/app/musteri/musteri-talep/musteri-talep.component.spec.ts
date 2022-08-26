import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MusteriTalepComponent } from './musteri-talep.component';

describe('MusteriTalepComponent', () => {
  let component: MusteriTalepComponent;
  let fixture: ComponentFixture<MusteriTalepComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MusteriTalepComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MusteriTalepComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
