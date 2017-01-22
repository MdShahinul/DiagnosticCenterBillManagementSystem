using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagement.DCBMGateway;
using DiagnosticCenterBillManagement.DCBMModelClass;

namespace DiagnosticCenterBillManagement.DCBMManager
{
    public class UnpaidBillReportManager
    {
        UnpaidBillReportGateway unpaidBillReportGateway = new UnpaidBillReportGateway();
        public List<UnpaidBillReportClass> GateUnpaidBill()
        {
            return unpaidBillReportGateway.GetUnpaidBill();
        }

        public int GatTotalBill()
        {
            return unpaidBillReportGateway.TotalBillAmount();
        }
    }
}