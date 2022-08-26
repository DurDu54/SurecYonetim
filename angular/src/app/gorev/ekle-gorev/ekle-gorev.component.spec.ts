import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EkleGorevComponent } from './ekle-gorev.component';

describe('EkleGorevComponent', () => {
  let component: EkleGorevComponent;
  let fixture: ComponentFixture<EkleGorevComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EkleGorevComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EkleGorevComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
