import { Routes } from '@angular/router';
import { LogInComponent } from './supplier/components/log-in/log-in.component';
import { GetOrderComponent } from './order/order/order.component';
import { SignUpComponent } from './supplier/components/sign-up/sign-up.component';
import { GetProductComponent } from './product/get-product/get-product.component';
import { GrocerLogInComponent } from './grocer/grocer-log-in/grocer-log-in.component';

export const routes: Routes = [
{ path: "", redirectTo: '/login', pathMatch: "full"},
{ path: 'login', component: LogInComponent },
{ path: 'grocer', component: GrocerLogInComponent},
{ path: 'signup', component: SignUpComponent},
{ path: 'order', component: GetOrderComponent},
{path: 'product', component: GetProductComponent}

];
