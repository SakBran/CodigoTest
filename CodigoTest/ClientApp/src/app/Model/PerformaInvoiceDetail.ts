import { Product } from 'src/app/Model/Product';
export interface PerformaInvoiceDetails extends Product {
  orderDetailID: string;
  productID: string;
  productAdjustmentPrice: number;
  productQty: number;
  performaInvoiceNo:number;
  orderID: string;
  colour:string;
}
