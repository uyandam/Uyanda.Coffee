import { Component, OnInit } from '@angular/core';
import { ClientService } from '../services/client.service';
import { DataShareService } from '../services/dataShare.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  public beverages: any = [];

  public cart: any = [];

  beverageSizeCost: any = {};

  constructor(private _clientService: ClientService, private _dataShareService: DataShareService) { }

  ngOnInit() {

    // this._clientService.beverage.getBeverages()
    // .subscribe((data) => {
    //   this.beverages = data.prices;
    // });
    
    this._clientService.beverage.getBeverageSizeCost()
    .subscribe((data) => {
      this.beverages = data.beverageSizeCost;
      console.log(this.beverages);
      this._dataShareService.addBeverageSizeCost(data);

      console.log('beverage size cost service start');
      
      console.log(this._dataShareService.getBeverageSizeCost());
      

      console.log('beverage size cost service end');

    });

  }

  ngOnMenu(){

    this.beverages.forEach((element: any) => {
      // console.log(element);
    });
  }

  ngCart(element: any, quantity: any) {

    var val = parseInt(quantity)

    if(isNaN(val)) {
      val = 0;
    }
    //deep copy

    var copiedElement = JSON.parse(JSON.stringify(element));

    copiedElement.quantity = val

    var indexValue = this.cart.findIndex((x: any) => x.id === copiedElement.id);
    
    if (indexValue === -1 && copiedElement.quantity > 0){

      this.cart.push(copiedElement);

      for (var entry of this.cart){
        console.log(entry);
      }

    } else if (indexValue >= 0 && copiedElement.quantity > 0) {
      
      this.cart[indexValue].quantity = copiedElement.quantity;

      for (var entry of this.cart){
        console.log(entry);
      }

    }

    //testing the service DataShareService class
    // this._dataShareService.clearCart();

    this._dataShareService.addCart(this.cart);
    
  }

 

}
