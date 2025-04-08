import { Product } from "../product/product.model"
import { Supplier } from "../supplier/supplier.model"

export class Order {
    id!: number
    date!: Date
    supplierId!: number
    supplier!: Supplier
    status!: Estatus
    productId!: number
    product!: Product
    quantityOrder!:number
}
export enum Estatus
{
    PendingApproval=0, 
    InProgress=1,      
    Completed=2       
}

export class ProductOrder{
    productId!: number
    quantityOrder!: number
    supplierId!: number
}
