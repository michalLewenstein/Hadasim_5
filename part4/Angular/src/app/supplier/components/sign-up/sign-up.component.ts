import { Component, OnInit } from '@angular/core';
import {FormArray, FormControl, FormGroup, Validators} from '@angular/forms';
import { SupplierService } from '../../supplier.service';
import { Router } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";

@Component({
  selector: 'app-sign-up',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
],
  templateUrl: './sign-up.component.html',
  styleUrl: './sign-up.component.scss',
  
})
export class SignUpComponent implements OnInit {
  public addForm!: FormGroup;
  public errorMes: string = '';

  constructor(private _supplierService: SupplierService, private _router: Router) { }

  ngOnInit(): void {
    this.addForm = new FormGroup({
      companyName: new FormControl('', Validators.required),
      representativeName: new FormControl('', Validators.required),
      phone: new FormControl('', [ Validators.required, Validators.pattern(/^[0-9]{9,10}$/)]),
      products: new FormArray([]),
    })
  }
  get products(): FormArray {
    return this.addForm.get('products') as FormArray;
  }

  addProduct(): void {
    const productForm = new FormGroup({
      productName: new FormControl('', Validators.required),
      productPrice: new FormControl('', [Validators.required, Validators.min(0)]),
      minQuantityOrder: new FormControl('', [Validators.required, Validators.min(1)])
    });
    this.products.push(productForm);
  }

  removeProduct(index: number): void {
    this.products.removeAt(index);
  }
  
  signUp(){
    console.log(this.addForm.value);
    this._supplierService.signUp(this.addForm.value).subscribe({
      next: (res)=>{
        console.log("הספק הצליח להירשם", res);
        this._router.navigate([''])
      },
      error: (err) => {
        console.log(err);
        this.errorMes =err.status === 409? "שם משתמש זה כבר קיים במערכת!" :  "שגיאת מערכת";
      }
    })
  }
}
