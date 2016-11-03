import { Component } from '@angular/core';
import { Location } from '@angular/common';
import { HomeComponent } from  './components/home/home.component';
import { MainFoodComponent } from  './components/mainFood/mainFood.component';
import { Configuration } from  './shared/app.configuration';
import { FoodDetailsComponent } from './components/foodDetails/foodDetails.component';
import { MainMeasurementComponent } from  './components/mainMeasurement/mainMeasurement.component';
import { MeasurementDetailsComponent } from './components/measurementDetails/measurementDetails.component';

@Component({
    selector: 'foodChooser-app',
    templateUrl: 'app/app.component.html'
})


export class AppComponent {

    public title: string;

    constructor(private _configuration: Configuration, private _location: Location) {
        this.title = _configuration.title;
    }
} 