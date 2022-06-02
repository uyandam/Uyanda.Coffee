import { Component, OnInit } from '@angular/core';
import { DataShareService } from 'src/app/services/dataShare.service';

@Component({
  selector: 'app-basket',
  templateUrl: './basket.component.html',
  styleUrls: ['./basket.component.css']
})
export class BasketComponent implements OnInit {
  cart: any = [];
  constructor(private _dataShareService: DataShareService) { }

  ngOnInit(): void {
    
    this.cart = this._dataShareService.getCart().slice();
  }

  ngAfterViewInit(): void {
    this.cart = this._dataShareService.getCart().slice();
  }

}
