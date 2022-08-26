import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YoneticiEkleComponent } from './yonetici-ekle.component';

describe('YoneticiEkleComponent', () => {
  let component: YoneticiEkleComponent;
  let fixture: ComponentFixture<YoneticiEkleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ YoneticiEkleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(YoneticiEkleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
