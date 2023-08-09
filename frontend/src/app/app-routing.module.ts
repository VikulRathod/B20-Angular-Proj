import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PublicModule } from './modules/public/public.module';
import { AdminAuthGuard } from './admin-auth.guard';
import { UserAuthGuard } from './user-auth.guard';

const routes: Routes = [
  { path: 'admin', canActivate: [AdminAuthGuard], loadChildren: () => import('./modules/admin/admin.module').then(m => m.AdminModule) },
  { path: 'user', canActivate: [UserAuthGuard], loadChildren: () => import('./modules/user/user.module').then(m => m.UserModule) },
  { path: '', loadChildren: () => PublicModule }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
