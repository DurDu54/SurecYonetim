import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeveloperEkleComponent } from './developer-ekle.component';

describe('DeveloperEkleComponent', () => {
  let component: DeveloperEkleComponent;
  let fixture: ComponentFixture<DeveloperEkleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeveloperEkleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeveloperEkleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
