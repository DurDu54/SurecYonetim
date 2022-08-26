import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeveloperAlanEkleComponent } from './developer-alan-ekle.component';

describe('DeveloperAlanEkleComponent', () => {
  let component: DeveloperAlanEkleComponent;
  let fixture: ComponentFixture<DeveloperAlanEkleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeveloperAlanEkleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeveloperAlanEkleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
