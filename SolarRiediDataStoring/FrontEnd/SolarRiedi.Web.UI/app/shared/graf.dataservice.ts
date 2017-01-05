﻿import { Injectable } from '@angular/core';

@Injectable()
export class DataSvc {
    getData(countries: string[]): any[] {
        var data = [];
        for (let i = 0; i < countries.length; i++) {
            data.push({
                country: countries[i],
                downloads: Math.round(Math.random() * 20000),
                sales: Math.random() * 10000,
                expenses: Math.random() * 5000
            });
        }
        return data;
    }

    public getSomeText() {
        return 'hallo from dataservice';
    }
}