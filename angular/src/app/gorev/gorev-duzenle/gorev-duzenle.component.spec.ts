import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GorevDuzenleComponent } from './gorev-duzenle.component';

describe('GorevDuzenleComponent', () => {
  let component: GorevDuzenleComponent;
  let fixture: ComponentFixture<GorevDuzenleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GorevDuzenleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GorevDuzenleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
