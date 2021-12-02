import { HttpClient } from '@angular/common/http';
import { analyzeAndValidateNgModules } from '@angular/compiler';
import { Component, Input, OnInit } from '@angular/core';
import { forkJoin, Observable, observable, throwError } from 'rxjs';
import {catchError, retry} from 'rxjs/operators';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html'
})
export class MenuComponent implements OnInit {

  baseUrl: string = 'http://localhost:5000/api/beverages/'
  beveragePrices: string = 'getbeverageprices'
  beverageSizes: string = 'getbeveragesize'
  beverages: any;
  sizeOfDrinks: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  async ngOnMenu(): Promise<void> {
    
    const beverageObservable = this.http.post<any>(this.baseUrl + this.beveragePrices, {}); // observable. We must now subscribe. It emits information that it gets.
    beverageObservable.subscribe((sauce) => {
      this.beverages = sauce.prices;
    })

    const beverageSizeObservable = this.http.post<any>(this.baseUrl + this.beverageSizes, {});
    beverageSizeObservable.subscribe((sauce) => {
      this.sizeOfDrinks = sauce.size;
    })
  }
  

  findDrinkSize(element: any): any {
    
    var result = this.sizeOfDrinks.find((val:any) => val.id === element);

    return result.name;
  }

  @Input() elementClicked: any;

  onClick(e: any) {
    console.log(this.beverages.find((i:any) => i.id === e));
    
  }

}
