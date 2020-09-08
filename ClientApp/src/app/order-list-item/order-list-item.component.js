var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Input, Component } from '@angular/core';
let OrderComponent = class OrderComponent {
};
__decorate([
    Input()
], OrderComponent.prototype, "order", void 0);
OrderComponent = __decorate([
    Component({
        selector: 'order',
        templateUrl: './order-list-item.component.html'
    })
], OrderComponent);
export { OrderComponent };
//# sourceMappingURL=order-list-item.component.js.map