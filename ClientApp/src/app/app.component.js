var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { Component } from "@angular/core";
import { OrderItem } from './dtos/order-item';
let AppComponent = class AppComponent {
    constructor(http) {
        this.http = http;
    }
    onBuy(product) {
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
    addToOrder(amount) {
        let count = Number(amount);
        console.log(count);
        if (!Number.isInteger(count)) {
            this.error = "введите целое число";
            return;
        }
        if (count > this.currentProduct.numberOfItemsInStock) {
            this.error = "вы выбрали количество, которое превышает количество продуктов на складе";
        }
        let orderItem = this.orderItems.find(item => item.productId === this.currentProduct.id);
        if (!orderItem) {
            orderItem = new OrderItem();
            orderItem.productId = this.currentProduct.id;
            orderItem.count = count;
            this.http.post('/api/orderItems', orderItem).subscribe(() => {
                this.ngOnInit();
            });
        }
        else {
            if (orderItem.count + count > this.currentProduct.numberOfItemsInStock) {
                this.error = "у вас уже есть " +
                    orderItem.count +
                    " этих продуктов в корзине. Если добавить ещё " +
                    count +
                    ", то количество будет больше количества на складе";
                return;
            }
            orderItem.count = orderItem.count + count;
            this.http.put('/api/orderItems/' + orderItem.productId, orderItem).subscribe(() => {
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
        this.http.get('/api/productCategories').subscribe((data) => {
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
            this.http.get('/api/products', {
                params: {
                    categoryId
                }
            }).subscribe((data) => {
                this.currentProducts = data;
                console.log("updatedProducts");
            });
        }
        else {
            this.http.get('/api/products').subscribe((data) => {
                this.currentProducts = data;
                console.log("updatedProducts");
            });
        }
    }
    updateOrderItems() {
        this.http.get('/api/orderItems').subscribe((data) => {
            this.orderItems = data;
            this.orderCount = this.orderItems.length;
            this.fullPrice = 0;
            for (let order of this.orderItems) {
                this.fullPrice = this.fullPrice + order.count * order.product.price;
            }
        });
    }
    setCategory(category) {
        console.log(category.name);
        this.currentProduct = null;
        this.currentCategory = category;
        this.updateCategories();
        this.updateProducts();
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