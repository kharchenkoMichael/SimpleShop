import { Input, Component, EventEmitter, Output } from '@angular/core';
import { Product } from "../dtos/product";

@Component({
    selector: 'prod',
    templateUrl: './product-list-item.component.html'
})
export class ProductComponent {
    @Input() withAmount: boolean;
    @Input() product: Product;
    @Output() onBuy = new EventEmitter<Product>();
    @Output() onOrder = new EventEmitter<number>();

    amount: number;
    buy() {
        this.onBuy.emit(this.product);
    }

    order() {
        this.onOrder.emit(this.amount);
    }
}