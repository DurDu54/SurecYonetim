import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YoneticiGorevEkleComponent } from './yonetici-gorev-ekle.component';

describe('YoneticiGorevEkleComponent', () => {
  let component: YoneticiGorevEkleComponent;
  let fixture: ComponentFixture<YoneticiGorevEkleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ YoneticiGorevEkleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(YoneticiGorevEkleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
