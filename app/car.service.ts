import { Car } from "./car";
import { Injectable } from "@angular/core";
import { Http, Response, Headers, RequestOptions } from "@angular/http";
import { Observable } from "rxjs/Observable";
import "rxjs/Rx";

@Injectable()
export class CarService {
    private headers: Headers;
    private _apiUrl: string = "http://localhost:5000/api/";
    constructor(private _http: Http) {
        this.headers = new Headers({ 'Content-Type': 'application/json' });
    }


    getCars() {
        return this._http.get(this._apiUrl + "cars")
            .map(res => res.json())
            .catch(this.throwError);
    }


    getCar(id: number) {
        return this._http.get(this._apiUrl + "cars/:id".replace(":id", id.toString()))
            .map(res => res.json())
            .catch(this.throwError);
    }

    update(id: number, car: Car) {
        let body = JSON.stringify(car);
        let options = new RequestOptions({ headers: this.headers });
        let url = this._apiUrl + "cars/:id".replace(":id", id.toString())

        return this._http.put(url, body, options)
            .catch(this.throwError);;
    }

    private throwError(response) {
        return Observable.throw(response.json().error || "Server error")
    }
}