import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent }  from './app.component';
import { RouterModule } from '@angular/router';
import { Configuration } from './shared/app.configuration';
import { AppRoutes } from './app.routes';
import { HttpModule, JsonpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { SharedModule } from './modules/shared.module';

import { MainMeasurementComponent } from  './components/mainMeasurement/mainMeasurement.component';
import { MeasurementDetailsComponent } from './components/measurementDetails/measurementDetails.component';
import { MeasurementListComponent } from './components/measurementList/measurementList.component';
import { MeasurementFormComponent } from './components/measurementForm/measurementForm.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { GrafComponent } from './components/graf/graf.component';

import { MeasurementDataService } from './shared/measurement.dataservice';
import { DataSvc } from './shared/graf.dataservice';

@NgModule({
    imports: [
        BrowserModule,
        RouterModule.forRoot(AppRoutes),
        HttpModule,
        JsonpModule,
        FormsModule,
        SharedModule
    ],

    declarations: [
        AppComponent,
        MainMeasurementComponent,
        MeasurementDetailsComponent,
        MeasurementListComponent,
        MeasurementFormComponent,
        NavigationComponent,
        GrafComponent
    ],

    providers: [
        Configuration,
        MeasurementDataService,
        DataSvc
    ],

    bootstrap: [AppComponent]
})

export class AppModule { }