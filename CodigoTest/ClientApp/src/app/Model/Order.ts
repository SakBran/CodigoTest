import { Customer } from 'src/app/Model/Customer';


export class order {
  orderId: string;
  orderApplicationDate:Date;
  orderApproveDate: Date;
  isApproveOrder: true;
  officeCompleteDate: Date;
  isApproveOffice: true;
  factoryCompleteDate: Date;
  isApproveFactory: true;
  customer: String;
  orderDiscount: number;
  orderStep: number;
  orderStatus: string;
  orderConfirmedUserId: string;
  orderOfficeUserId: string;
  orderFactoryUserId: string;
  orderNo: number;
  quotationFocalperson: string;
  quotationFocalpersonEmail: string;
  poFocalperson: string;
  poFocalpersonEmail: string;
  //Terms and Condition
  quality: string;
  colour: string;
  packing: string;
  payment: string;
  paymentMethod: string;
  shipment: string;
  portOfDischarge: string;
  finalDestination: string;
  deliveryTime: string;
  swiftCode: string;
  beneficiaryBankName: string;
  beneficiaryBankAddress: string;
  bankBranchCode: string;
  beneficiaryAccountNumber: string;
  currency: string;
  beneficiaryName: string;
  beneficiaryAddress: string;
 //Terms and Condition
}
