import { Routes } from '@angular/router';
import { AboutComponent } from './pages/about/about';

export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'About', component: AboutComponent },
  { path: '**', redirectTo: 'home' },

];
