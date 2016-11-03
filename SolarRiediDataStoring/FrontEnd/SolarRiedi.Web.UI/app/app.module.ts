import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent }  from './app.component';
import { RouterModule } from '@angular/router';
import { Configuration } from './shared/app.configuration';
import { AppRoutes } from './app.routes';
import { HttpModule, JsonpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { SharedModule } from './modules/shared.module';

import { HomeComponent } from  './components/home/home.component';
import { MainFoodComponent } from  './components/mainFood/mainFood.component';
import { FoodDetailsComponent } from './components/foodDetails/foodDetails.component';
import { FoodListComponent } from './components/foodList/foodList.component';
import { FoodFormComponent } from './components/foodForm/foodForm.component';
import { MainMeasurementComponent } from  './components/mainMeasurement/mainMeasurement.component';
import { MeasurementDetailsComponent } from './components/measurementDetails/measurementDetails.component';
import { MeasurementListComponent } from './components/measurementList/measurementList.component';
import { MeasurementFormComponent } from './components/measurementForm/measurementForm.component';
import { NavigationComponent } from './components/navigation/navigation.component';

import { FoodDataService } from './shared/food.dataservice';
import { MeasurementDataService } from './shared/measurement.dataservice';

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
        HomeComponent,
        MainFoodComponent,
        FoodDetailsComponent,
        FoodListComponent,
        FoodFormComponent,
        MainMeasurementComponent,
        MeasurementDetailsComponent,
        MeasurementListComponent,
        MeasurementFormComponent,
        NavigationComponent
    ],

    providers: [
        Configuration,
        FoodDataService,
        MeasurementDataService,
    ],

    bootstrap: [AppComponent]
})

export class AppModule { }