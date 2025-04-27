import { Component, OnInit } from '@angular/core';
import { Order } from '../order.model';
import { OrderService } from '../order.service';

@Component({
  selector: 'app-order',
  standalone: true,
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class GetOrderComponent implements OnInit {
  orders: Order[] = [];
  supplierId: number = 0;
  statusMap: { [key: number]: string } = {
    0: 'מחכה לאישור',
    1: 'בתהליך',
    2: 'הושלמה',
  };

  constructor(private _orderService: OrderService) {}

  ngOnInit(): void {
    this.getOrder();
    this.supplierId = JSON.parse(localStorage.getItem('supplierId') || "0");
    console.log("supplierId", this.supplierId);
  }

  getOrder() {
    this._orderService.getOrder().subscribe({
      next: (res) => {
        console.log("הזמנות", res);
        this.orders = res.filter((o: Order) => this.statusMap[o.status] !== 'הושלמה');
        this.orders.sort((a, b) =>
        a.supplier.companyName.localeCompare(b.supplier.companyName, 'he') 
      );
      },
      error: (err) => {
        console.log("שגיאה בהבאת ההזמנות", err);
      }
    });
  }

  orderConfirmation(orderId: number) {
    this._orderService.orderConfirmation(orderId).subscribe({
      next: (res) => {
        console.log("ההזמנה בתהליך", res);
        this.getOrder();
      },
      error: (err) => {
        console.log("שגיאה באישור ההזמנה", err);
      }
    });
  }

  completedOrder(orderId: number) {
    this._orderService.completedOrder(orderId).subscribe({
      next: (res) => {
        console.log("ההזמנה הושלמה", res);
        this.getOrder();
      },
      error: (err) => {
        console.log("שגיאה באישור השלמת ההזמנה", err);
      }
    });
  }

}