import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MusteriDashboardComponent } from './musteri-dashboard.component';

describe('MusteriDashboardComponent', () => {
  let component: MusteriDashboardComponent;
  let fixture: ComponentFixture<MusteriDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MusteriDashboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MusteriDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
