import { order } from './Order';
import { Orderdetail } from './Orderdetail';
export interface PuchaseOrder {
  order: order;
  orderDetails: Orderdetail[];
}
