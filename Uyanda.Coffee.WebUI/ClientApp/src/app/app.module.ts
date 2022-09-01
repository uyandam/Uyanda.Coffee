import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { HeaderComponent } from './pages/header/header.component';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { PagesComponent } from './pages/pages.component';
import { MenuComponent } from './menu/menu.component';
import { ClientService } from './services/client.service';
import { BasketComponent } from './pages/basket/basket.component';
import { DataShareService } from './services/dataShare.service';
import { CheckoutComponent } from './pages/checkout/checkout.component';
import { CartService } from './services/cart.services';
import { BeverageService } from './services/beverage.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    PagesComponent,
    MenuComponent,
    BasketComponent,
    CheckoutComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [ClientService, DataShareService, CartService, BeverageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
