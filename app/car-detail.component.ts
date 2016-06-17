
import { Component, OnInit } from "@angular/core";
import { CarService } from "./car.service";
import { RouteParams } from "@angular/router-deprecated";
import { Car } from "./car";
import { Router } from "@angular/router-deprecated";

@Component({
    templateUrl: "app/car-detail.component.html",
})

export class CarDetailComponent implements OnInit {
    constructor(private _routeParams: RouteParams, private _carService: CarService, private _router: Router) { }

    public car: Car;
    
    private _idCar: number;

    ngOnInit() {
        this._idCar = <number><any>this._routeParams.get("id");
        this._carService.getCar(this._idCar).subscribe(data => this.car = data, error => console.log(error));
    }

    update(): void {
        this._carService.update(this._idCar, this.car).subscribe(x => this.goHome());
    }

    private goHome(): void {
        this._router.navigate(["Cars"]);
    }
}