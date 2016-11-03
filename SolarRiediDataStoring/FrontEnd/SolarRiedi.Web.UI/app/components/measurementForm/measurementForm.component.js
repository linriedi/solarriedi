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
var MeasurementItem_1 = require('../../models/MeasurementItem');
var MeasurementFormComponent = (function () {
    function MeasurementFormComponent() {
        var _this = this;
        this.measurementUpdated = new core_1.EventEmitter();
        this.measurementAdded = new core_1.EventEmitter();
        this.AddOrUpdateFood = function () {
            if (_this.measurementItem.id) {
                console.log("update");
                _this.measurementUpdated.emit(_this.currentMeasurement);
            }
            else {
                console.log("add");
                _this.measurementAdded.emit(_this.currentMeasurement);
            }
        };
    }
    MeasurementFormComponent.prototype.ngOnChanges = function (changes) {
        this.currentMeasurement = Object.assign(new MeasurementItem_1.MeasurementItem(), changes.measurementItem.currentValue);
        console.log(this.currentMeasurement);
    };
    __decorate([
        core_1.Input(), 
        __metadata('design:type', MeasurementItem_1.MeasurementItem)
    ], MeasurementFormComponent.prototype, "measurementItem", void 0);
    __decorate([
        core_1.Output(), 
        __metadata('design:type', Object)
    ], MeasurementFormComponent.prototype, "measurementUpdated", void 0);
    __decorate([
        core_1.Output(), 
        __metadata('design:type', Object)
    ], MeasurementFormComponent.prototype, "measurementAdded", void 0);
    MeasurementFormComponent = __decorate([
        core_1.Component({
            selector: 'measurementForm',
            templateUrl: 'app/components/MeasurementForm/MeasurementForm.component.html'
        }), 
        __metadata('design:paramtypes', [])
    ], MeasurementFormComponent);
    return MeasurementFormComponent;
}());
exports.MeasurementFormComponent = MeasurementFormComponent;
//# sourceMappingURL=measurementForm.component.js.map