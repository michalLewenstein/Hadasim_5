import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Supplier, SupplierLogin } from "./supplier.model";

@Injectable({
    providedIn: 'root'
})

export class SupplierService{
    basicUrl = 'https://localhost:7041/api/Supplier';
    $source: Observable<number> = new Observable<number>((observer) => {
        observer.next(1) //on succeed
        observer.complete(); //on ending
        observer.error('error'); //on error
    })
    constructor(private _httpClient: HttpClient) { }

    signUp(supplier: Supplier): Observable<any> {
        return this._httpClient.post<any>(this.basicUrl, supplier);
    }

    logIn(supplier: SupplierLogin): Observable<number>{
        return this._httpClient.post<number>(`${this.basicUrl}/login`, supplier);
    }

    getSuppliers(): Observable<Supplier[]>{
        return this._httpClient.get<Supplier[]>(this.basicUrl);
    }
}