import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { SupplierService } from '../../supplier.service';
import { Router } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { CommonModule } from "@angular/common";
@Component({
  selector: 'app-log-in',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
],
  templateUrl: './log-in.component.html',
  styleUrl: './log-in.component.scss',
})
export class LogInComponent implements OnInit{
  public addForm!: FormGroup
  public errorMes: string = '';

  constructor(private _supplierService: SupplierService, private _router: Router) { }

  ngOnInit(): void {
  localStorage.removeItem('supplierId');
    this.addForm = new FormGroup
    ({
      representativeName: new FormControl('', Validators.required),
      phone: new FormControl('', [ Validators.required, Validators.pattern(/^[0-9]{9,10}$/)]),
    })
  }

  login(){
    this._supplierService.logIn(this.addForm.value).subscribe({
      next: (res)=>{
        console.log("התחברות עברה בהצלחה", res);
        localStorage.setItem('supplierId',JSON.stringify(res));
        localStorage.removeItem('manager')
        this._router.navigate(['/order']);
      },
      error: (err)=>{
        console.log("שגיאההה", err);
        
      }
    })
  }


}
