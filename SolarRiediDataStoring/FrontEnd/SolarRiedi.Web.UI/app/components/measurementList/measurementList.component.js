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
var MeasurementListComponent = (function () {
    function MeasurementListComponent() {
        var _this = this;
        this.measurementSelected = new core_1.EventEmitter();
        this.measurementDeleted = new core_1.EventEmitter();
        this.setMeasurementItemForEdit = function (measurementItem) {
            _this.measurementSelected.emit(measurementItem);
        };
        this.deleteMeasurement = function (measurementItem) {
            _this.measurementDeleted.emit(measurementItem);
        };
    }
    __decorate([
        core_1.Input(), 
        __metadata('design:type', Array)
    ], MeasurementListComponent.prototype, "measurements", void 0);
    __decorate([
        core_1.Output(), 
        __metadata('design:type', Object)
    ], MeasurementListComponent.prototype, "measurementSelected", void 0);
    __decorate([
        core_1.Output(), 
        __metadata('design:type', Object)
    ], MeasurementListComponent.prototype, "measurementDeleted", void 0);
    MeasurementListComponent = __decorate([
        core_1.Component({
            selector: 'measurementList',
            templateUrl: 'app/components/measurementList/measurementList.component.html'
        }), 
        __metadata('design:paramtypes', [])
    ], MeasurementListComponent);
    return MeasurementListComponent;
}());
exports.MeasurementListComponent = MeasurementListComponent;
//# sourceMappingURL=measurementList.component.js.map