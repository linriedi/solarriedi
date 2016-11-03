"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var measurement_dataservice_1 = require('../../shared/measurement.dataservice');
var MeasurementItem_1 = require('../../models/MeasurementItem');
var router_1 = require('@angular/router');
var MeasurementDetailsComponent = (function () {
    function MeasurementDetailsComponent(_route, _measurementDataService) {
        this._route = _route;
        this._measurementDataService = _measurementDataService;
        this.selectedMeasurementItem = new MeasurementItem_1.MeasurementItem();
    }
    MeasurementDetailsComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._route.params.forEach(function (params) {
            var id = _this._route.snapshot.params['measurementId'];
            //let foodId = +params['foodId']; // (+) converts string 'id' to a number
            _this._measurementDataService
                .GetSingleMeasurement(id)
                .subscribe(function (measurementItem) {
                _this.selectedMeasurementItem = measurementItem;
            }, function (error) { return console.log(error); });
        });
    };
    MeasurementDetailsComponent = __decorate([
        core_1.Component({
            selector: 'measurementDetails-component',
            templateUrl: 'app/components/measurementDetails/measurementDetails.component.html'
        }), 
        __metadata('design:paramtypes', [router_1.ActivatedRoute, measurement_dataservice_1.MeasurementDataService])
    ], MeasurementDetailsComponent);
    return MeasurementDetailsComponent;
}());
exports.MeasurementDetailsComponent = MeasurementDetailsComponent;
//# sourceMappingURL=measurementDetails.component.js.map