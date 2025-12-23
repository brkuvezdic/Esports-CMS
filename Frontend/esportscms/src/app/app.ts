import { Component, signal } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { NavbarComponent } from './components/navbar/navbar.component';
import { Footer } from './components/footer/footer.component';
import { SponsorsComponent } from './components/sponsors/sponsors.component';
import { CollegesComponent } from './components/colleges/colleges.component';
import { LeftSidebar } from './components/left-sidebar/left.sidebar.component';
import { CollegesReorder } from './components/features/cms/colleges-reorder/colleges.reorder.component';
import { Hero } from './components/features/features/hero/hero.component';
import { PandascoreComponent } from './components/pandascore/pandascore.component/pandascore.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent, CollegesComponent, Footer, SponsorsComponent, LeftSidebar, CollegesReorder, Hero],
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
