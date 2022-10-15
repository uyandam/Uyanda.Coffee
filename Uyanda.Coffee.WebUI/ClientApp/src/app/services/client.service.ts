import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import {catchError, retry} from "rxjs/operators";
import { BeverageService } from "./beverage.service";

@Injectable()
export class ClientService {

    beverage: BeverageService; 

    constructor(private http: HttpClient) {
        this.beverage = new BeverageService(http);
    }
}