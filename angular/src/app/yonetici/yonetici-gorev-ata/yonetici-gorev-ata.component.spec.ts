import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YoneticiGorevAtaComponent } from './yonetici-gorev-ata.component';

describe('YoneticiGorevAtaComponent', () => {
  let component: YoneticiGorevAtaComponent;
  let fixture: ComponentFixture<YoneticiGorevAtaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ YoneticiGorevAtaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(YoneticiGorevAtaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
