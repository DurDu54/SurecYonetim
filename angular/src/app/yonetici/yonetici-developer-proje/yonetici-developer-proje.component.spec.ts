import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YoneticiDeveloperProjeComponent } from './yonetici-developer-proje.component';

describe('YoneticiDeveloperProjeComponent', () => {
  let component: YoneticiDeveloperProjeComponent;
  let fixture: ComponentFixture<YoneticiDeveloperProjeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ YoneticiDeveloperProjeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(YoneticiDeveloperProjeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
