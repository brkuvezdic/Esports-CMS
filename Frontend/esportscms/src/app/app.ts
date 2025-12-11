import { Component, signal } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { NavbarComponent } from './components/navbar/navbar';
import { Footer } from './components/footer/footer';
import { SponsorsComponent } from './components/sponsors/sponsors';
import { CollegesComponent } from './components/colleges/colleges';
import { LeftSidebar } from './components/left-sidebar/left-sidebar';
import { CollegesReorder } from './components/features/colleges-cms/colleges-reorder/colleges-reorder';
import { Hero } from './components/features/features/hero/hero';
import { Students } from './components/features/colleges-cms/students/students';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent, CollegesComponent, Footer, SponsorsComponent, LeftSidebar, CollegesReorder, Hero, Students],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  protected readonly title = signal('esportscms');

  hiddenRoutes = ['/Login', '/Cms/Colleges'];

  constructor(public router: Router) {}

  get hideExtraSections(): boolean {
    return this.hiddenRoutes.includes(this.router.url);
  }
}
