import { Injectable } from "@angular/core";

@Injectable()
export class DataShareService {
    private cart: any = [];

    private invoice: any = {};

    private beverageSizeCost: any = {};

    // cart
    getCart(): any  {
        return this.cart;
    }

    clearCart(): void {
        this.cart.length = 0;
    }

    addCart(arr:any = []): void {
        this.cart = arr.slice();
    }

    // invoice

    addInvoice(invoice: any = {}): void {
        this.invoice = invoice;
    }

    getInvoice(): any {
        return this.invoice.invoice;
    }


    // beverage size cost

    addBeverageSizeCost(beverageSizeCost: any = {}): void {
        this.beverageSizeCost = beverageSizeCost;
    }

    getBeverageSizeCost(): any {
        return this.beverageSizeCost;
    }


}