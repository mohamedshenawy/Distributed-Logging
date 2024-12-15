import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AddlogComponent } from './addlog/addlog.component';

export const routes: Routes = [
    {path : '' , component : HomeComponent ,title :"home" },
    {path : 'home' , component : HomeComponent ,title :"home" },
    {path : 'addlog' , component : AddlogComponent ,title :"add log" },
];
