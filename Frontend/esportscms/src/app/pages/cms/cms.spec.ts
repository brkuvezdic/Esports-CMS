import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CMS } from './cms';

describe('CMS', () => {
  let component: CMS;
  let fixture: ComponentFixture<CMS>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CMS]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CMS);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
