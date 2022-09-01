import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, throwError } from "rxjs";
import {catchError, retry} from "rxjs/operators";

@Injectable()
export class CartService {
    private _urlBase = 'http://localhost:5000/api/beverages/'
    constructor (private http: HttpClient) {}
    
    placeOrder (lineItems: [], customer: number, IsRedeemingPoints: boolean, currency: string) {
        let order = {
            lineItems : lineItems,
            Customer: {Id : customer},
            IsRedeemingPoints: IsRedeemingPoints,
            Currency:currency
        }


        return this.http.post<any>(this._urlBase + 'placeorder', order, )        
    }

    getBeverageSizeCost(): any {
        return this.http.post<any>(this._urlBase + 'getbeveragesizecost', {});
    }
    
    pay(amount: number, invoiceId: BigInteger): any {
        let payment = {
            Payment: {
                Amount: amount,
                InvoiceId: invoiceId
            }
        }
        return this.http.post<any>(this._urlBase + 'pay', payment ).subscribe(data => data, err =>console.log(err));
       
    }

}