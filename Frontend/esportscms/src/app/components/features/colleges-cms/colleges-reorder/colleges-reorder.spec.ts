import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CollegesReorder } from './colleges-reorder';

describe('CollegesReorder', () => {
  let component: CollegesReorder;
  let fixture: ComponentFixture<CollegesReorder>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CollegesReorder]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CollegesReorder);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
