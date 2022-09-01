import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import {catchError, retry} from "rxjs/operators";

@Injectable() 
export class BeverageService {

    private _urlBase = 'http://localhost:5000/api/beverages/'
    constructor (private http: HttpClient) {}
    
    getBeverageSizeCost() {
        return this.http.post<any>(this._urlBase + 'getbeveragesizecost', {})
    }
    
    getBeverages(){
        return this.http.post<any>(this._urlBase + 'getbeverageprices', {})
    }

    getBeverageSizes() {
        return this.http.post<any> (this._urlBase + 'GetBeverageSize', {})
    }
}