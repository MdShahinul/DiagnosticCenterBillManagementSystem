using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagement.DCBMModelClass
{
    public class PaymentClass
    {
        public string BillNumber { get; set; }
        public string BillDate { get; set; }
        public string TotalFee { get; set; }
        public string PaidAnount { get; set; }
        public string DueAmount { get; set; }
        public string Amount { get; set; }

        public PaymentClass(string billDate, string amount, string paidAmount, string dueAmount)
        {
            BillDate = billDate;
            Amount = amount;
            PaidAnount = paidAmount;
            DueAmount = dueAmount;
        }
        public PaymentClass(string billNumber)
        {
            BillNumber = billNumber;
        }

        public PaymentClass()
        {
            
        }
    }
}