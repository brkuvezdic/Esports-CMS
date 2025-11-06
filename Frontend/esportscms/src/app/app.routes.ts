import { Routes } from '@angular/router';
import { AboutComponent } from './pages/about/about';

export const routes: Routes = [ 
  { path: '', redirectTo: '/', pathMatch: 'full' },
  { path: 'About', component: AboutComponent },
];
