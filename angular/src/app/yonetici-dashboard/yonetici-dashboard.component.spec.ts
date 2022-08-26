import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YoneticiDashboardComponent } from './yonetici-dashboard.component';

describe('YoneticiDashboardComponent', () => {
  let component: YoneticiDashboardComponent;
  let fixture: ComponentFixture<YoneticiDashboardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ YoneticiDashboardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(YoneticiDashboardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
