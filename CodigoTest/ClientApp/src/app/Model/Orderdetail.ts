import { Product } from './Product';
export interface Orderdetail extends Product {
  orderDetailID: string;
  productID: string;
  productOriginalPrice: number;
  productAdjustmentPrice: number;
  productQty: number;
  ttlctn: number;
  grossWeight: number;
  quotationVersion: number;
  orderID: string;
  orderNo: string;
  itemNo:number;
}
