import { Component, OnInit  } from "@angular/core";
import { Product } from './dtos/product';
import { OrderItem } from './dtos/order-item';
import { ProductCategory } from './dtos/product-category';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app',
    moduleId: module.id,
    templateUrl: './app.component.html'
})
export class AppComponent implements OnInit{
    categories: ProductCategory[];
    orderItems: OrderItem[];
    currentProducts: Product[];

    currentCategory: number;

    constructor(private http: HttpClient) {
        this.currentCategory = null;
    }

    ngOnInit() {
        let currentCategory = this.currentCategory.toString();
        this.http.get('/api/productCategories').subscribe((data: ProductCategory[]) => this.categories = data);

        if (this.currentCategory) {
            this.http.get('/api/products',
                {
                    params: {
                        currentCategory
                    }
                }).subscribe((data: Product[]) => this.currentProducts = data);
        } else {
            this.http.get('/api/products').subscribe((data: Product[]) => this.currentProducts = data);
        }


        this.http.get('/api/orderItems').subscribe((data: OrderItem[]) => this.orderItems = data);
    }
}