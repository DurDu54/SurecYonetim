import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeveloperDuzenleComponent } from './developer-duzenle.component';

describe('DeveloperDuzenleComponent', () => {
  let component: DeveloperDuzenleComponent;
  let fixture: ComponentFixture<DeveloperDuzenleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeveloperDuzenleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeveloperDuzenleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
