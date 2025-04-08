import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { GrocerService } from '../grocer.service';

@Component({
  selector: 'app-grocer-log-in',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
  ],
  templateUrl: './grocer-log-in.component.html',
  styleUrl: './grocer-log-in.component.scss',
})
export class GrocerLogInComponent implements OnInit{
  public addForm!: FormGroup
  public errorMes: string = '';

  constructor(private _grocerService: GrocerService, private _router: Router) { }

  ngOnInit(): void {
    this.addForm = new FormGroup
    ({
      name: new FormControl('', Validators.required),
      phone: new FormControl('', [ Validators.required, Validators.pattern(/^[0-9]{9,10}$/)]),
    })
  }
  login(){
    this._grocerService.logIn(this.addForm.value).subscribe({
      next: (res)=>{
        console.log("התחברות עברה בהצלחה", res);
        localStorage.setItem('manager',"manager");
        this._router.navigate(['/order']);
      },
      error: (err)=>{
        console.log("שגיאההה", err);
        
      }
    })
  }
}





 



