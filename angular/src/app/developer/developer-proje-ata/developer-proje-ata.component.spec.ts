import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeveloperProjeAtaComponent } from './developer-proje-ata.component';

describe('DeveloperProjeAtaComponent', () => {
  let component: DeveloperProjeAtaComponent;
  let fixture: ComponentFixture<DeveloperProjeAtaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeveloperProjeAtaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeveloperProjeAtaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
