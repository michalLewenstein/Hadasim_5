import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Product } from "./product.model";

@Injectable({
    providedIn: 'root'
})

export class ProductService{
    basicUrl = 'https://localhost:7041/api/Product';
    $source: Observable<number> = new Observable<number>((observer) => {
        observer.next(1) 
        observer.complete(); 
        observer.error('error'); 
    })
    constructor(private _httpClient: HttpClient) { }

    getProducts(): Observable<Product[]>{
        return this._httpClient.get<Product[]>(this.basicUrl);
    }
}