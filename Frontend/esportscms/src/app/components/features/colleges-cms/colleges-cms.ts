import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-colleges-cms',
  imports: [CommonModule],
  templateUrl: './colleges-cms.html',
  styleUrl: './colleges-cms.css',
})
export class CollegesCms {
  constructor(private router: Router
  ) {}


  get isHidden(): boolean {
    return this.router.url != '/Cms/Colleges';
  }
}
