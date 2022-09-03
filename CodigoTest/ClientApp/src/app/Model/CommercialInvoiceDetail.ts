export class CommercialInvoiceDetails {
  commercialInvoiceDetailId: string;
  commercialInvoiceId: string;
  itemNo: number;
  proformaInvoiceId: string;
  proformaInvoiceNo: string;
  purchaseOrderNo: string;
  productId: string;
  productCode: string;
  biCode: string;
  productName: string;
  colour: string;
  unitPrice: number;
  cartoonLWHCM: string;
  productprice: number;
  mpn: string;
  quantity: number;
  pcsPerCtn: number;
  pcsPerCtnInner: number;
  totalQuantity: number;
  //Just for packing List
  netWeightPerCarton: number;
  //Just for packing List
  totalNetWeight: number;
  //Just for packing List
  grossWeightPerCarton: number;
  //Just for packing List
  totalGrossWeight: number;
  length: number;
  width: number;
  height: number;
  lengthInner: number;
  widthInner: number;
  heightInner: number;
  cbmPerCtn: number;
  TotalCBM: number;
}
