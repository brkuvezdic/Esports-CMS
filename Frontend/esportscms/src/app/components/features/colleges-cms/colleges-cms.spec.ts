import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CollegesCms } from './colleges-cms';

describe('CollegesCms', () => {
  let component: CollegesCms;
  let fixture: ComponentFixture<CollegesCms>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CollegesCms]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CollegesCms);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
