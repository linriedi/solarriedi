import { Routes } from '@angular/router';
import { HomeComponent } from  './components/home/home.component';
import { MainFoodComponent } from  './components/mainFood/mainFood.component';
import { MainMeasurementComponent } from  './components/mainMeasurement/mainMeasurement.component';
import { Configuration } from  './shared/app.configuration';
import { FoodDetailsComponent } from './components/foodDetails/foodDetails.component';
import { MeasurementDetailsComponent } from './components/measurementDetails/measurementDetails.component';

export const AppRoutes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'food', component: MainFoodComponent },
  { path: 'food/:foodId', component: FoodDetailsComponent },
  { path: 'measurement', component: MainMeasurementComponent },
  { path: 'measurement/:measurementId', component: MeasurementDetailsComponent }
];