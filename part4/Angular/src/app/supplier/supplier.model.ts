import { Order } from "../order/order.model"
import { Product } from "../product/product.model"

export class Supplier {
    id!: number
    companyName!: string
    phone!: string
    representativeName!: string
    products!: Product[]
    orders!: Order[]
}

export class SupplierLogin{
    phone!: string
    representativeName!: string
}