import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavbarComponent } from './pages/navbar/navbar';
import { Footer } from './components/footer/footer';
import { SponsorsComponent } from './components/sponsors/sponsors';
import { CollegesComponent } from './components/colleges/colleges';
 

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavbarComponent,CollegesComponent, Footer, SponsorsComponent],
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  protected readonly title = signal('esportscms');
}
