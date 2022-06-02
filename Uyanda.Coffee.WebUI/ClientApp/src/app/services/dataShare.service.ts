import { Injectable } from "@angular/core";

@Injectable()
export class DataShareService {
    private cart: any = [];

    getCart(): any  {
        return this.cart;
    }

    clearCart(): void {
        this.cart.length = 0;
    }

    addCart(arr:any = []): void {
        this.cart = arr.slice();
    }

}