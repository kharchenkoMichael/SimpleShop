var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Input, Component, EventEmitter, Output } from '@angular/core';
let ProductComponent = class ProductComponent {
    constructor() {
        this.onBuy = new EventEmitter();
        this.onOrder = new EventEmitter();
    }
    buy() {
        this.onBuy.emit(this.product);
    }
    order() {
        this.onOrder.emit(this.amount);
    }
};
__decorate([
    Input()
], ProductComponent.prototype, "withAmount", void 0);
__decorate([
    Input()
], ProductComponent.prototype, "product", void 0);
__decorate([
    Output()
], ProductComponent.prototype, "onBuy", void 0);
__decorate([
    Output()
], ProductComponent.prototype, "onOrder", void 0);
ProductComponent = __decorate([
    Component({
        selector: 'prod',
        templateUrl: './product-list-item.component.html'
    })
], ProductComponent);
export { ProductComponent };
//# sourceMappingURL=product-list-item.component.js.map