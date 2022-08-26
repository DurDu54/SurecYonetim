import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YoneticiDeveloperAtaComponent } from './yonetici-developer-ata.component';

describe('YoneticiDeveloperAtaComponent', () => {
  let component: YoneticiDeveloperAtaComponent;
  let fixture: ComponentFixture<YoneticiDeveloperAtaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ YoneticiDeveloperAtaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(YoneticiDeveloperAtaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
