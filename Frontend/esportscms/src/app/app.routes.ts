import { Routes } from '@angular/router';
import { AdminGuard } from './/services/admin.guard';

export const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  {
    path: 'About', loadComponent: () => import('./pages/about/about').then((m) => m.AboutComponent),
  },
  { path: '**', redirectTo: 'home' },
  {
    path: 'Login', loadComponent: () => import('./pages/login-register-page/login-register-page').then((m) => m.LoginRegisterPage),
  },
  {
    path: 'Cms', loadComponent: () => import('./pages/cms/cms').then((m) => m.CMS),
  },
  {
    path: 'Cms/Colleges', loadComponent: () => import('./components/features/colleges-cms/colleges-cms').then((m) => m.CollegesCms),
        canActivate: [AdminGuard]

  },
    {
    path: 'forbidden',
    loadComponent: () => import('./pages/about/about').then(m => m.AboutComponent)
  }
];
