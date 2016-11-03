import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { MeasurementDataService } from '../../shared/measurement.dataservice';
import { MeasurementItem } from '../../models/measurementItem';

@Component({
    selector: 'measurementList',
    templateUrl: 'app/components/measurementList/measurementList.component.html'
})

export class MeasurementListComponent {
    public measurementItem: MeasurementItem;

    @Input() measurements: MeasurementItem[];
    @Output() measurementSelected = new EventEmitter<MeasurementItem>();
    @Output() measurementDeleted = new EventEmitter<MeasurementItem>();

    public setMeasurementItemForEdit = (measurementItem: MeasurementItem): void => {
        this.measurementSelected.emit(measurementItem);
    }

    public deleteMeasurement = (measurementItem: MeasurementItem): void => {
        this.measurementDeleted.emit(measurementItem);
    };
}