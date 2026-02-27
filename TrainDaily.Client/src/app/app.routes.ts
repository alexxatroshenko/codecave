import { Routes } from '@angular/router';
import { Calendar } from './components/calendar/calendar';

export const routes: Routes = [{ path: '', pathMatch: 'full', component: Calendar }];
