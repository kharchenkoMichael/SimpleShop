var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from "@angular/core";
let AppComponent = class AppComponent {
    constructor(http) {
        this.http = http;
        this.currentCategory = null;
    }
    ngOnInit() {
        let currentCategory = this.currentCategory.toString();
        this.http.get('/api/productCategories').subscribe((data) => this.categories = data);
        if (this.currentCategory) {
            this.http.get('/api/products', {
                params: {
                    currentCategory
                }
            }).subscribe((data) => this.currentProducts = data);
        }
        else {
            this.http.get('/api/products').subscribe((data) => this.currentProducts = data);
        }
        this.http.get('/api/orderItems').subscribe((data) => this.orderItems = data);
    }
};
AppComponent = __decorate([
    Component({
        selector: 'app',
        moduleId: module.id,
        templateUrl: './app.component.html'
    })
], AppComponent);
export { AppComponent };
//# sourceMappingURL=app.component.js.map