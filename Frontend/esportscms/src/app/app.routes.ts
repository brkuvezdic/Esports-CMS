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
    canActivate: [AdminGuard]

  },
  {
    path: 'Cms/Colleges', loadComponent: () => import('./components/features/cms/colleges.cms.component').then((m) => m.CollegesCms),
    canActivate: [AdminGuard]
  },
  {
    path: 'Cms/Students', loadComponent: () => import('./components/features/cms/students/students.component').then((m) => m.StudentsComponent),
    canActivate: [AdminGuard]
  },
  {
    path: 'UpcomingMatches', loadComponent: () => import('./components/pandascore/pandascore.component/pandascore.component').then((m) => m.PandascoreComponent),
  },
  {
    path: 'forbidden',
    loadComponent: () => import('./pages/about/about').then(m => m.AboutComponent)
  }
];