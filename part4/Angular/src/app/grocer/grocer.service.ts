import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Grocer } from "./grocer.model";

@Injectable({
    providedIn: 'root'
})

export class GrocerService{
    basicUrl = 'https://localhost:7041/api/Grocer';
    $source: Observable<number> = new Observable<number>((observer) => {
        observer.next(1) 
        observer.complete(); 
        observer.error('error'); 
    })
    constructor(private _httpClient: HttpClient) { }

    logIn(grocer: Grocer): Observable<any>{
        return this._httpClient.post<any>(`${this.basicUrl}/login`, grocer);
    }
}