import {Component, OnInit} from "@angular/core";
import { Car } from "./car";
import { CarDetailComponent } from "./car-detail.component";
import { Router } from "@angular/router-deprecated";
import { CarService } from "./car.service";

@Component({
    templateUrl: "app/car-master.component.html",
    directives: [CarDetailComponent],
})

export class CarMasterComponent implements OnInit {
    public title: string = "Cadastro de veículos";
    public brans = [];
    public car: Car = {
        Id: 0,
        Brand: "",
        Name: ""
    };

    public cars: Car[] = [];

    constructor(private _carService: CarService, private _router: Router) { }

    ngOnInit() {
        this._carService.getCars()
            .subscribe(data => this.cars = data, error => console.log(error));
    }

    public onSelect(car: Car): void {
        this._router.navigate(["CarDetail", { id: car.Id }]);
    }

}