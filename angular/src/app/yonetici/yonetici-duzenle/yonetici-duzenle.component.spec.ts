import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YoneticiDuzenleComponent } from './yonetici-duzenle.component';

describe('YoneticiDuzenleComponent', () => {
  let component: YoneticiDuzenleComponent;
  let fixture: ComponentFixture<YoneticiDuzenleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ YoneticiDuzenleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(YoneticiDuzenleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
