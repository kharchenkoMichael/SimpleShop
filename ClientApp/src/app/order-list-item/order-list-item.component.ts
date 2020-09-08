import { Input, Component } from '@angular/core';
import { OrderItem } from "../dtos/order-item";

@Component({
    selector: 'order',
    templateUrl: './order-list-item.component.html'
})
export class OrderComponent {
    @Input() order: OrderItem;
}