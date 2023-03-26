import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { AddComponent } from './components/restaurant/add/add.component';
import { ListComponent } from './components/restaurant/list/list.component';

const routes: Routes = [
  {path: '', redirectTo: 'restaurants', pathMatch: 'full'},
  {path: 'restaurants', component: ListComponent},
  {path: 'restaurants/add', component: AddComponent},
  {path: 'login', component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
