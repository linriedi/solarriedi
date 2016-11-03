import { Component, Input, OnInit, OnChanges, Output, EventEmitter } from '@angular/core';
import { MeasurementDataService } from '../../shared/measurement.dataservice';
import { MeasurementItem } from '../../models/MeasurementItem';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'measurementForm',
    templateUrl: 'app/components/MeasurementForm/MeasurementForm.component.html'
})

export class MeasurementFormComponent implements OnChanges {
    @Input() measurementItem: MeasurementItem;

    @Output() measurementUpdated = new EventEmitter<MeasurementItem>();
    @Output() measurementAdded = new EventEmitter<MeasurementItem>();

    private currentMeasurement: MeasurementItem;

    constructor() {

    }

    ngOnChanges(changes: any) {
        this.currentMeasurement = Object.assign(new MeasurementItem(), changes.measurementItem.currentValue);
        console.log(this.currentMeasurement);
    }

    public AddOrUpdateFood = (): void => {
        if (this.measurementItem.id) {
            console.log("update");
            this.measurementUpdated.emit(this.currentMeasurement);
        } else {
            console.log("add");
            this.measurementAdded.emit(this.currentMeasurement);
        }
    }
}