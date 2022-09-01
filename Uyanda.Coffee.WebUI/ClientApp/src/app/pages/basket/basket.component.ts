import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CartService } from 'src/app/services/cart.services';
import { DataShareService } from 'src/app/services/dataShare.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {
  
  cart: any = [];

  order: any = [];

  orderResult: any;

  constructor(private _dataShareService: DataShareService, private _cartService: CartService, private route: Router) { }

  ngOnInit(): void {
    
    this.cart = this._dataShareService.getCart().slice();
  }

  ngAfterViewInit(): void {
    this.cart = this._dataShareService.getCart().slice();

    this.order = this.cart.map(({id , quantity}:{id: number , quantity:number}) => ({id, quantity}));

    // this.order = this.order.map( (e: any) => { return {beverageSizeId : e.beverageSizeId, count : e.quantity}});
    this.order = this.order.map( (e: any) => { return {beverageSizeCostId : e.id, count : e.quantity}});

  }

  placeOrder(): void {
    
    this._cartService.placeOrder(this.order, 1, false, "USD")
    .subscribe((data) => {
      this.orderResult = data;
      console.log(this.orderResult);
      this._dataShareService.addInvoice(this.orderResult);
      this.route.navigate(['/checkout']);     
    }, (error: any) => console.log(error)
    );

    
  }

}
