"use strict";
var mainMeasurement_component_1 = require('./components/mainMeasurement/mainMeasurement.component');
var measurementDetails_component_1 = require('./components/measurementDetails/measurementDetails.component');
exports.AppRoutes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'measurement', component: mainMeasurement_component_1.MainMeasurementComponent },
    { path: 'measurement/:measurementId', component: measurementDetails_component_1.MeasurementDetailsComponent }
];
//# sourceMappingURL=app.routes.js.map