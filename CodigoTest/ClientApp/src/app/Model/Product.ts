
export interface Product {
  productId: string;
  productCode: string;
  oldProductCode: string;
  customerCode: string;
  customizeDescriptions:string;
  productName: string;
  dimensions: string;
  colour: string;
  material: string;
  cartoonLWH: string;
  CartoonLWHCM: string;
  remark: string;
  length: number;
  width: number;
  height: number;
  lengthInner: number;
  widthInner: number;
  heightInner: number;
  mpn: string;
  barcode: string;
  pcsPerCtn: number;
  cbm: number;
  shape: string;
  size: string;
  productPrice: number;
  categoryID: string;
  categoryName: string;
  prodictImageURL: string;
  quantity: number;
  adjustmentPrice: number;
  customzeColourPrice: number;
  createDate: Date;
  productType: string;
  isCutomizeColour:boolean;
  quantityLeftToDeliver:number;
  unitPrice:number;
}
