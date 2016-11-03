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
var measurementItem_1 = require('../../models/measurementItem');
var MainMeasurementComponent = (function () {
    function MainMeasurementComponent(_measurementDataService) {
        var _this = this;
        this._measurementDataService = _measurementDataService;
        this.addMeasurement = function (measurementItem) {
            _this._measurementDataService
                .AddMeasurement(measurementItem)
                .subscribe(function (response) {
                console.log("added measurement");
                _this.getMeasurement();
            }, function (error) { return console.log(error); });
        };
        this.updateMeasurement = function (measurementItem) {
            _this._measurementDataService
                .UpdateMeasurement(measurementItem.id, measurementItem)
                .subscribe(function (response) {
                console.log("updated measurement");
                _this.getMeasurement();
            }, function (error) { return console.log(error); });
        };
        this.getMeasurement = function () {
            _this._measurementDataService
                .GetAllMeasurement()
                .subscribe(function (response) {
                _this.measurements = response;
            }, function (error) { return console.log(error); }, function () { return console.log(_this.measurements); });
        };
        this.setCurrentlySelectedMeasurement(new measurementItem_1.MeasurementItem());
        this._measurementDataService.measurementAdded.subscribe(function () { return _this.getMeasurement(); });
        this._measurementDataService.measurementDeleted.subscribe(function () { return _this.getMeasurement(); });
    }
    MainMeasurementComponent.prototype.ngOnInit = function () {
        this.getMeasurement();
    };
    MainMeasurementComponent.prototype.setCurrentlySelectedMeasurement = function (measurementItem) {
        this.measurementSelectedFromList = measurementItem;
    };
    MainMeasurementComponent.prototype.deleteMeasurement = function (measurementItem) {
        var _this = this;
        this._measurementDataService
            .DeleteMeasurement(measurementItem.id)
            .subscribe(function () {
            console.log('Measurement deleted');
            _this.getMeasurement();
        }, function (error) { return console.log(error); });
    };
    MainMeasurementComponent = __decorate([
        core_1.Component({
            selector: 'mainMeasurement-component',
            templateUrl: 'app/components/mainMeasurement/mainMeasurement.component.html'
        }), 
        __metadata('design:paramtypes', [measurement_dataservice_1.MeasurementDataService])
    ], MainMeasurementComponent);
    return MainMeasurementComponent;
}());
exports.MainMeasurementComponent = MainMeasurementComponent;
//# sourceMappingURL=mainMeasurement.component.js.map