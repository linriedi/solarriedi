import { Injectable } from '@angular/core';

@Injectable()
export class Configuration {
    baseUrl: string = "http://backendservicesolarriediactual.azurewebsites.net/api/";
    //baseUrl: string = "http://localhost:29775/api/";
    title: string = "SolarRiedi";
}