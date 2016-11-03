import { Component, OnInit } from '@angular/core';
import { MeasurementDataService } from '../../shared/measurement.dataservice';
import { MeasurementItem } from '../../models/MeasurementItem';
import { Router, ActivatedRoute, Params } from '@angular/router';

@Component({
    selector: 'measurementDetails-component',
    templateUrl: 'app/components/measurementDetails/measurementDetails.component.html'
})

export class MeasurementDetailsComponent implements OnInit {

    public selectedMeasurementItem: MeasurementItem = new MeasurementItem();

    constructor(private _route: ActivatedRoute, private _measurementDataService: MeasurementDataService) {

    }

    ngOnInit() {
        this._route.params.forEach((params: Params) => {
            let id = this._route.snapshot.params['measurementId'];
            //let foodId = +params['foodId']; // (+) converts string 'id' to a number
            this._measurementDataService
                .GetSingleMeasurement(id)
                .subscribe((measurementItem: MeasurementItem) => {
                    this.selectedMeasurementItem = measurementItem;
                }, error => console.log(error));
        });
    }
}