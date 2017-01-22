using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagement.DCBMModelClass
{
    [Serializable]
    public class TestRequestEntryClass
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string DateOfBirth { get; set; }
        public string MobileNumber { get; set; }
        public string InvoiceDate { get; set; }
        public string InvoiceNumber { get; set; }
        public string TestName { get; set; }
        public decimal Fee { get; set; }
        public string TotalBil { get; set; }
        public string PaidBill { get; set; }
        public string DueBill { get; set; }
        
        public TestRequestEntryClass(string patientName, string dateOfBirth, string mobileNumber, string invoiceDate, string invoiceNnumber)
        {
            PatientName = patientName;
            DateOfBirth = dateOfBirth;
            MobileNumber = mobileNumber;
            InvoiceDate = invoiceDate;
            InvoiceNumber = invoiceNnumber;
        }

        public TestRequestEntryClass(string totalBill, string paidBill, string dueBill, string invoiceNumber)
        {
            TotalBil = totalBill;
            PaidBill = paidBill;
            DueBill = dueBill;
            InvoiceNumber = invoiceNumber;
        }
        public TestRequestEntryClass(string testName, decimal fee, string invoiceNnumber)
        {
            TestName = testName;
            Fee = fee;
            InvoiceNumber = invoiceNnumber;
        }
        public TestRequestEntryClass(string testName, decimal fee)
        {
            TestName = testName;
            Fee = fee;
        }
        public TestRequestEntryClass(string totalBill)
        {
            TotalBil = totalBill;
        }
        public TestRequestEntryClass()
        {
            
        }
    }
}