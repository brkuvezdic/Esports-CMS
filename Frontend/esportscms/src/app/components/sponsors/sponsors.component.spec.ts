import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SponsorsComponent } from './sponsors.component';

describe('Sponsors', () => {
  let component: SponsorsComponent;
  let fixture: ComponentFixture<SponsorsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SponsorsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SponsorsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
