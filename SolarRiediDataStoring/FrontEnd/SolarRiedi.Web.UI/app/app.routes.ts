import { Routes } from '@angular/router';
import { MainMeasurementComponent } from  './components/mainMeasurement/mainMeasurement.component';
import { Configuration } from  './shared/app.configuration';
import { MeasurementDetailsComponent } from './components/measurementDetails/measurementDetails.component';
import { GrafComponent } from './components/graf/graf.component';

export const AppRoutes: Routes = [
  { path: 'measurement', component: MainMeasurementComponent },
  { path: 'measurement/:measurementId', component: MeasurementDetailsComponent },
  { path: 'graf', component: GrafComponent }
];