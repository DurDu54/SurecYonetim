import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeveloperAlanComponent } from './developer-alan.component';

describe('DeveloperAlanComponent', () => {
  let component: DeveloperAlanComponent;
  let fixture: ComponentFixture<DeveloperAlanComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeveloperAlanComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeveloperAlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
