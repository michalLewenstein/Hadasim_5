import { Component, OnInit } from '@angular/core';
import { Product } from '../product.model';
import { OrderService } from '../../order/order.service';
import { ProductOrder } from '../../order/order.model';
import { ProductService } from '../product.service';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-get-product',
  templateUrl: './get-product.component.html',
  styleUrls: ['./get-product.component.scss'], 
  imports:[
    FormsModule
  ]
})
export class GetProductComponent implements OnInit {
  products: Product[] = [];

  quantities: { [key: number]: number } = {}; 

  constructor(
    private _productService: ProductService,
    private _orderService: OrderService,
  ) {}

  ngOnInit(): void {
    this._productService.getProducts().subscribe({
      next: (res) => {
        this.products = res;
        console.log("res", res);
        
        this.products.forEach(product => {
          this.quantities[product.id] = product.minQuantityOrder;
        });
        this.products.sort((a, b) =>
        a.supplier.companyName.localeCompare(b.supplier.companyName, 'he') 
      );
      },
      error: (err) => {
        console.log('שגיאה בהבאת המוצרים', err);
      }
    });
  }

  orderProduct(product: Product) {
    const quantity = this.quantities[product.id];
    if (quantity < product.minQuantityOrder) {
      alert(`הכמות המינימלית להזמנה היא ${product.minQuantityOrder}`);
      return;
    }
console.log("product", product);

    const productOrder: ProductOrder = {
      productId: product.id,
      quantityOrder: quantity,
      supplierId: product.supplier.id
    };


console.log("הזמנה", productOrder);

    this._orderService.orderProduct( product.supplierId , productOrder).subscribe({
      next: (res) => {
        console.log('הזמנה בוצעה בהצלחה', res);
        alert('ההזמנה נשלחה בהצלחה!');
      },
      error: (err) => {
        console.log('שגיאה בהזמנה', err);
        alert('שגיאה בביצוע ההזמנה');
      }
    });
  }
}

