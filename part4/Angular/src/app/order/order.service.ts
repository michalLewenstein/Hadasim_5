import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ProductOrder } from "./order.model";

@Injectable({
    providedIn: 'root'
})

export class OrderService{
    basicUrl = 'https://localhost:7041/api/Order';
    $source: Observable<number> = new Observable<number>((observer) => {
        observer.next(1) 
        observer.complete(); 
        observer.error('error'); 
    })
    constructor(private _httpClient: HttpClient) { }

    getOrder(): Observable<any> {
        return this._httpClient.get<any>(this.basicUrl);
    }
    orderConfirmation(orderId: number): Observable<any>{
        return this._httpClient.put<any>(`${this.basicUrl}/${orderId}`, null);
    }

    completedOrder(orderId: number): Observable<any>{
        return this._httpClient.put<any>(`${this.basicUrl}/${orderId}/complet`,null);
    }

    orderProduct( supplierId: number, productOrder: ProductOrder,):Observable<any>{
        
        return this._httpClient.post<any>(`${this.basicUrl}/${supplierId}`, productOrder);
    }
}