"use strict";
var home_component_1 = require('./components/home/home.component');
var mainFood_component_1 = require('./components/mainFood/mainFood.component');
var mainMeasurement_component_1 = require('./components/mainMeasurement/mainMeasurement.component');
var foodDetails_component_1 = require('./components/foodDetails/foodDetails.component');
var measurementDetails_component_1 = require('./components/measurementDetails/measurementDetails.component');
exports.AppRoutes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: home_component_1.HomeComponent },
    { path: 'food', component: mainFood_component_1.MainFoodComponent },
    { path: 'food/:foodId', component: foodDetails_component_1.FoodDetailsComponent },
    { path: 'measurement', component: mainMeasurement_component_1.MainMeasurementComponent },
    { path: 'measurement/:measurementId', component: measurementDetails_component_1.MeasurementDetailsComponent }
];
//# sourceMappingURL=app.routes.js.map