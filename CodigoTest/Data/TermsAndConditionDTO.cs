using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace template.Data
{
    public class TermsAndConditionDTO
    {
        #region For TERMS AND CONDITIONS
        
        public string orderId { get; set; }
        public string quality { get; set; }
        public string colour { get; set; }
        public string packing { get; set; }
        public string payment { get; set; }
        public string paymentMethod { get; set; }
        public string shipment { get; set; }
        public string portOfDischarge { get; set; }
        public string finalDestination { get; set; }
        public string deliveryTime { get; set; }
        public string swiftCode { get; set; }
        public string beneficiaryBankName { get; set; }
        public string beneficiaryBankAddress { get; set; }
        public string bankBranchCode { get; set; }
        public string beneficiaryAccountNumber { get; set; }
        public string currency { get; set; }
        public string beneficiaryName { get; set; }
        public string beneficiaryAddress { get; set; }
        #endregion
    }
}