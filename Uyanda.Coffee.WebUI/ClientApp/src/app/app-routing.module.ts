import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MenuComponent } from './pages/menu/menu.component';


const appRoutes: Routes = [
  { path: '', redirectTo: '/menu', pathMatch: 'full' },
  {path: 'menu', component: MenuComponent}
]

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
