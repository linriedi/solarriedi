import { Component, Input, OnInit } from '@angular/core';
import { MeasurementFormComponent } from '../measurementForm/measurementForm.component';
import { MeasurementListComponent } from '../measurementList/measurementList.component';
import { MeasurementDetailsComponent } from '../measurementDetails/measurementDetails.component';
import { MeasurementDataService } from '../../shared/measurement.dataservice';
import { MeasurementItem } from '../../models/measurementItem';

@Component({
    selector: 'mainMeasurement-component',
    templateUrl: 'app/components/mainMeasurement/mainMeasurement.component.html'
})

export class MainMeasurementComponent implements OnInit {
    public measurementSelectedFromList: MeasurementItem;
    public measurements: MeasurementItem[];

    constructor(private _measurementDataService: MeasurementDataService) {
        this.setCurrentlySelectedMeasurement(new MeasurementItem());
        this._measurementDataService.measurementAdded.subscribe(() => this.getMeasurement());
        this._measurementDataService.measurementDeleted.subscribe(() => this.getMeasurement());
    }

    ngOnInit() {
        this.getMeasurement();
    }

    public setCurrentlySelectedMeasurement(measurementItem: MeasurementItem) {
        this.measurementSelectedFromList = measurementItem;
    }

    public addMeasurement = (measurementItem: MeasurementItem): void => {
        this._measurementDataService
            .AddMeasurement(measurementItem)
            .subscribe((response: MeasurementItem) => {
                console.log("added measurement");
                this.getMeasurement();
            },
            error => console.log(error));
    }

    public updateMeasurement = (measurementItem: MeasurementItem): void => {
        this._measurementDataService
            .UpdateMeasurement(measurementItem.id, measurementItem)
            .subscribe((response: MeasurementItem) => {
                console.log("updated measurement");
                this.getMeasurement();
            },
            error => console.log(error));
    }

    public deleteMeasurement(measurementItem: MeasurementItem) {
        this._measurementDataService
            .DeleteMeasurement(measurementItem.id)
            .subscribe(() => {
                console.log('Measurement deleted');
                this.getMeasurement();
            },
            error => console.log(error));
    }

    private getMeasurement = (): void => {
        this._measurementDataService
            .GetAllMeasurement()
            .subscribe((response: MeasurementItem[]) => {
                this.measurements = response;
            },
            error => console.log(error),
            () => console.log(this.measurements));
    }
}