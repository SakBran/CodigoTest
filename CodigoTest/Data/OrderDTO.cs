using System;

namespace template.Data
{
    public class OrderDTO
    {
        
        public string OrderId { get; set; }
        public DateTime OrderApplicationDate { get; set; }
        public  DateTime OrderApproveDate {get;set;}
        public bool IsApproveOrder { get; set; }
        public DateTime OfficeCompleteDate { get; set; }
        public bool IsApproveOffice { get; set; }
        public DateTime FactoryCompleteDate { get; set; }
        public bool IsApproveFactory { get; set; }
        public string Customer { get; set; }
        public decimal OrderDiscount { get; set; }
        public int OrderStep { get; set; }
        
        public string OrderStatus { get; set; }
        public string OrderConfirmedUserId { get; set; }
        public string OrderOfficeUserId { get; set; }
        public string OrderFactoryUserId { get; set; }
        public string OrderNo { get; set; }
    }
}