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

    orderCount: number;
    fullPrice: number;
    categoriesCount: number;

    dropDown: boolean;

    currentCategory: ProductCategory;

    currentProduct: Product;

    error: string;

    constructor(private http: HttpClient) {
    }

    onBuy(product: any) {
        this.currentProduct = product;
    }

    change() {
        this.dropDown = !this.dropDown;
    }

    apply() {
        this.http.delete('/api/orderItems').subscribe(() => {
            this.ngOnInit();
            console.log("apply");
        });
    }

    addToOrder(amount: any) {
        let count = Number(amount);
        console.log(count);
        if (!Number.isInteger(count)) {
            this.error = "введите целое число";
            return;
        }
        if (count > this.currentProduct.numberOfItemsInStock) {
            this.error = "вы выбрали количество, которое превышает количество продуктов на складе";
        }

        let orderItem: OrderItem = this.orderItems.find(item => item.productId === this.currentProduct.id);
        if (!orderItem) {
            orderItem = new OrderItem();
            orderItem.productId = this.currentProduct.id;
            orderItem.count = count;
            this.http.post('/api/orderItems', orderItem).subscribe(() => {
                this.ngOnInit();
            });
        } else {
            if (orderItem.count + count > this.currentProduct.numberOfItemsInStock) {
                this.error = "у вас уже есть " +
                    orderItem.count +
                    " этих продуктов в корзине. Если добавить ещё " +
                    count +
                    ", то количество будет больше количества на складе";
                return;
            }
            orderItem.count = orderItem.count + count;
            this.http.put('/api/orderItems/'+orderItem.productId, orderItem).subscribe(() => {
                this.ngOnInit();
            });
        }
    }

    ngOnInit() {
        this.dropDown = false;
        this.error = null;
        this.currentProduct = null;
        this.currentCategory = null;
        this.updateCategories();
        this.updateProducts();
        this.updateOrderItems();

    }

    updateCategories() {

        console.log("updateCategories");
        this.http.get('/api/productCategories').subscribe((data: ProductCategory[]) => {
            this.categories = data;
            this.categoriesCount = data.length;

            console.log("updatedCategories");
        });
    }

    updateProducts() {

        console.log("updateProducts");
        if (this.currentCategory) {

            let categoryId = this.currentCategory.id.toString();
            console.log(categoryId);
            this.http.get('/api/products',
                {
                    params: {
                        categoryId
                    }
                }).subscribe((data: Product[]) => {
                    this.currentProducts = data;

                    console.log("updatedProducts");
            });
        } else {
            this.http.get('/api/products').subscribe((data: Product[]) => {
                this.currentProducts = data;

                console.log("updatedProducts");
            });
        }
    }

    updateOrderItems() {
        this.http.get('/api/orderItems').subscribe((data: OrderItem[]) => {
            this.orderItems = data;
            this.orderCount = this.orderItems.length;
            this.fullPrice = 0;
            for (let order of this.orderItems) {
                this.fullPrice = this.fullPrice + order.count * order.product.price;
            }
        });
    }

    setCategory(category: ProductCategory) {
        console.log(category.name);

        this.currentProduct = null;
        this.currentCategory = category;
        this.updateCategories();
        this.updateProducts();
    }
}