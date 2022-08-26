import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YoneticiProjeAtaComponent } from './yonetici-proje-ata.component';

describe('YoneticiProjeAtaComponent', () => {
  let component: YoneticiProjeAtaComponent;
  let fixture: ComponentFixture<YoneticiProjeAtaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ YoneticiProjeAtaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(YoneticiProjeAtaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
