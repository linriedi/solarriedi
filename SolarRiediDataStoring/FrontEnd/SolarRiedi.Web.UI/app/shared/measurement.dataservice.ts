import { Injectable, EventEmitter, Output } from '@angular/core';
import { Http, Response, Headers, RequestOptions, RequestOptionsArgs} from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { MeasurementItem } from '../models/MeasurementItem';
import { Configuration } from '../shared/app.configuration';

@Injectable()
export class MeasurementDataService {

    private actionUrl: string;

    @Output() measurementAdded: EventEmitter<any> = new EventEmitter();
    @Output() measurementDeleted: EventEmitter<any> = new EventEmitter();

    constructor(private _http: Http, private _configuration: Configuration) {
        this.actionUrl = _configuration.baseUrl + 'measurement/';
    }

    public GetAllMeasurement = (): Observable<MeasurementItem[]> => {
        return this._http.get(this.actionUrl)
            .map((response: Response) => <MeasurementItem[]>response.json())
            .catch(this.handleError);
    }

    public GetSingleMeasurement = (id: number): Observable<MeasurementItem> => {
        return this._http.get(this.actionUrl + id)
            .map((response: Response) => <MeasurementItem>response.json())
            .catch(this.handleError);
    }

    public AddMeasurement = (measurementItem: MeasurementItem): Observable<MeasurementItem> => {
        let toAdd: string = JSON.stringify(
            {
                time: measurementItem.time,
            });

        let options = this.prepareOptions(null);

        return this._http.post(this.actionUrl, toAdd, options)
            .map((response: Response) => <MeasurementItem>response.json())
            .do(() => this.measurementAdded.emit(null))
            .catch(this.handleError);
    }

    public UpdateMeasurement = (id: number, measurementToUpdate: MeasurementItem): Observable<MeasurementItem> => {
        let options = this.prepareOptions(null);

        return this._http.put(this.actionUrl + id, JSON.stringify(measurementToUpdate), options)
            .map((response: Response) => <MeasurementItem>response.json())
            .catch(this.handleError);
    }

    public DeleteMeasurement = (id: number): Observable<Response> => {
        return this._http.delete(this.actionUrl + id)
            .do(() => this.measurementDeleted.emit(null))
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }
    
    private prepareOptions = (options: RequestOptionsArgs): RequestOptionsArgs => {
        options = options || {};

        if (!options.headers) {
            options.headers = new Headers();
        }

        options.headers.append('Content-Type', 'application/json');

        return options;
    }
}
