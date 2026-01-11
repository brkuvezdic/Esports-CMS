
import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-left-sidebar',
  imports: [RouterModule],
  templateUrl: './left.sidebar.component.html',
  styleUrl: './left.sidebar.component.css',
  standalone: true,
})
export class LeftSidebar {
  constructor(private router: Router
  ) {}


  get isHidden(): boolean {
    return !this.router.url.includes('/Cms');
  }
}
