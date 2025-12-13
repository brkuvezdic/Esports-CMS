import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PandascoreComponent } from './pandascore.component';

describe('PandascoreComponent', () => {
  let component: PandascoreComponent;
  let fixture: ComponentFixture<PandascoreComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PandascoreComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PandascoreComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
