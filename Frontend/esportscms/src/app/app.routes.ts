import { Routes } from '@angular/router';

export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {
    path: 'About', loadComponent: () => import('./pages/about/about').then((m) => m.AboutComponent),
  },
  { path: '**', redirectTo: 'home' },
    {
    path: 'Login', loadComponent: () => import('./pages/login-register-page/login-register-page').then((m) => m.LoginRegisterPage),
  },
];
