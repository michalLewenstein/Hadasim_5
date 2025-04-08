import { Supplier } from "../supplier/supplier.model"

export class Product {
    id!: number
    productName!: string
    productPrice!:number
    minQuantityOrder!: number
    supplierId!: number
    supplier!: Supplier
}

