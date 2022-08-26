import { ComponentFixture, TestBed } from '@angular/core/testing';

import { YoneticiDeveloperListComponent } from './yonetici-developer-list.component';

describe('YoneticiDeveloperListComponent', () => {
  let component: YoneticiDeveloperListComponent;
  let fixture: ComponentFixture<YoneticiDeveloperListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ YoneticiDeveloperListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(YoneticiDeveloperListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
