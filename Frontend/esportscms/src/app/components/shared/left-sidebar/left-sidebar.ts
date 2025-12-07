import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-left-sidebar',
  imports: [CommonModule, RouterModule],
  templateUrl: './left-sidebar.html',
  styleUrl: './left-sidebar.css',
  standalone: true,
})
export class LeftSidebar {
  constructor(private router: Router
  ) {}


  get isHidden(): boolean {
    return this.router.url != '/Cms';
  }
}
