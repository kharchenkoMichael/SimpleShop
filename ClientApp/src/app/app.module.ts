import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { ProductComponent } from "./product-list-item/product-list-item.component";
import { OrderComponent } from "./order-list-item/order-list-item.component";

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule],
    declarations: [AppComponent, ProductComponent, OrderComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }