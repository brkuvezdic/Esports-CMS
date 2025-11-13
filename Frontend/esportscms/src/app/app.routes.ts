import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {
    path: 'About', loadComponent: () => import('./pages/about/about').then((m) => m.AboutComponent),
  },
  { path: '**', redirectTo: 'home' },
];
