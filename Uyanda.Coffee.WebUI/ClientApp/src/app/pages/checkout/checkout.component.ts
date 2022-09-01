import { Component, OnInit } from '@angular/core';
import { BeverageService } from 'src/app/services/beverage.service';
import { CartService } from 'src/app/services/cart.services';
import { DataShareService } from 'src/app/services/dataShare.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {

  invoice: any = {};

  beverageSizeCost: any = {};

  cartService: any; 

  constructor(private _dataShareService: DataShareService, private _cartService: CartService) { }

  ngOnInit(): void {
    
    this.invoice = this._dataShareService.getInvoice();

    this.beverageSizeCost = this._dataShareService.getBeverageSizeCost()
    
    
    if (Object.keys(this.invoice).length === null){
      console.log('start loop');

      for(let i = 0; i < this.invoice.lineItems.length; i++){
        console.log(this.invoice.lineItems[i]);
        
      }
      console.log('end loop');
    }
  }

  ngPlaceOrder(amount: any){
    console.log("place order");
    console.log(amount);
    this.cartService = this._cartService.pay(amount, this.invoice.id);
    console.log(this.cartService);
     
  }

}
