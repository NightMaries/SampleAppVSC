import { Routes } from '@angular/router';
import { HeaderComponent } from '../Componetns/header/header.component';
import { UsersComponent } from '../Componetns/users/users.component';
import { HomeComponent } from '../Componetns/home/home.component';

export const routes: Routes = [
    { path: 'header', component: HeaderComponent},
    { path: 'users', component: UsersComponent},
    { path: 'home', component: HomeComponent},
    { path: '', component: HomeComponent}
    

];
