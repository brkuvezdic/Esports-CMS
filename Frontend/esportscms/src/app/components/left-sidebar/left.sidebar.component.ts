import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-left-sidebar',
  imports: [RouterModule],
  templateUrl: './left.sidebar.component.html',
  styleUrl: './left.sidebar.component.css',
  standalone: true,
})
export class LeftSidebar {

  constructor(
    private router: Router,
    private auth: AuthService
  ) {}

  get isHidden(): boolean {
    return !this.router.url.includes('/Cms');
  }

  get isAdmin(): boolean {
    return this.auth.getUserRole() === 'Admin';
  }

  get isStudent(): boolean {
    return this.auth.getUserRole() === 'Student';
  }
}