import { Component, signal } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { NavbarComponent } from './pages/navbar/navbar';
import { Footer } from './components/footer/footer';
import { SponsorsComponent } from './components/sponsors/sponsors';
import { CollegesComponent } from './components/colleges/colleges';
import { LeftSidebar } from './components/shared/left-sidebar/left-sidebar';
import { CollegesCms } from './components/features/colleges-cms/colleges-cms';


import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, NavbarComponent, CollegesComponent, Footer, SponsorsComponent, LeftSidebar, CollegesCms],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  protected readonly title = signal('esportscms');

  hiddenRoutes = ['/Login'];

  constructor(public router: Router) {}

  get hideExtraSections(): boolean {
    return this.hiddenRoutes.includes(this.router.url);
  }
}
