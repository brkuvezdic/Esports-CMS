import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { CollegesService } from '../../../../services/colleges';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-students',
  imports: [CommonModule],
  templateUrl: './students.component.html',
  styleUrl: './students.component.css',
})
export class Students {
  constructor(private collegeService: CollegesService
    ,private router: Router
  ) {}


  get isHidden(): boolean {
    return this.router.url !== '/Cms/Students';
  }

}
