"use strict";
var mainMeasurement_component_1 = require('./components/mainMeasurement/mainMeasurement.component');
var measurementDetails_component_1 = require('./components/measurementDetails/measurementDetails.component');
var graf_component_1 = require('./components/graf/graf.component');
exports.AppRoutes = [
    { path: 'measurement', component: mainMeasurement_component_1.MainMeasurementComponent },
    { path: 'measurement/:measurementId', component: measurementDetails_component_1.MeasurementDetailsComponent },
    { path: 'graf', component: graf_component_1.GrafComponent }
];
//# sourceMappingURL=app.routes.js.map