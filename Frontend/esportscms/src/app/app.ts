import { Component, signal } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { NavbarComponent } from './pages/navbar/navbar';
import { Footer } from './components/footer/footer';
import { SponsorsComponent } from './components/sponsors/sponsors';
import { CollegesComponent } from './components/colleges/colleges';
import { LeftSidebar } from './components/left-sidebar/left-sidebar';

import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, NavbarComponent, CollegesComponent, Footer, SponsorsComponent, LeftSidebar],
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
