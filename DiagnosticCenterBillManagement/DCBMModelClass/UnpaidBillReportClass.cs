using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagement.DCBMModelClass
{
    public class UnpaidBillReportClass
    {
        public string InvoiceNumber { get; set; }
        public string PatientName { get; set; }
        public string MobileNumber { get; set; }
        public string DueBill { get; set; }
    }
}