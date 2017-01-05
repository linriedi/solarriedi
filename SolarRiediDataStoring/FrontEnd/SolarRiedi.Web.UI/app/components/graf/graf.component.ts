import { Inject, Component, Input, OnInit } from '@angular/core';
import { DataSvc } from '../../shared/graf.dataservice';

@Component({
    selector: 'grafComponent',
    templateUrl: 'app/components/graf/graf.component.html'
})

export class GrafComponent implements OnInit {
    countries = 'US,Germany,UK,Japan,Italy,Greece'.split(',');
    data: { country: string, downloads: number, sales: number, expenses: number }[];
    protected dataSvc: DataSvc;

    public someText: string;

    constructor( @Inject(DataSvc) dataSvc: DataSvc) {
        // data for FlexChart
        this.dataSvc = dataSvc;
        this.data = this.dataSvc.getData(this.countries);

        this.someText = this.dataSvc.getSomeText();
    }

    ngOnInit() {
    }
}