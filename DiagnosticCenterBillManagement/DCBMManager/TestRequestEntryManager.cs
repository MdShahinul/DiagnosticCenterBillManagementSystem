using DiagnosticCenterBillManagement.DCBMModelClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagement.DCBMGateway;

namespace DiagnosticCenterBillManagement.DCBMManager
{
    public class TestRequestEntryManager
    {
        TestRequestEntryGateway testRequestEntryGateway = new TestRequestEntryGateway();

        public string InsertPatientInformation(TestRequestEntryClass testRequestEntryClass)
        {
            int rowAffectedPi = testRequestEntryGateway.InsertPatientInformation(testRequestEntryClass);

            if (rowAffectedPi > 0)
            {
                return "Saved Successfully!";
            }
            else
            {
                return "Insertion Failed!";
            }
        }
        public string InsertPatientTest(TestRequestEntryClass testRequestEntryClass)
        {
            int rowAffectedPd = testRequestEntryGateway.InsertPatientTest(testRequestEntryClass);

            if (rowAffectedPd > 0)
            {
                return "Saved Successfully!";
            }
            else
            {
                return "Insertion Failed!";
            }
        }

        public string InsertPatientBill(TestRequestEntryClass testRequestEntryClass)
        {
            int rowAffected = testRequestEntryGateway.InsertPatientBil(testRequestEntryClass);

            if (rowAffected > 0)
            {
                return "Saved Successfully!";
            }
            else
            {
                return "Insertion Failed!";
            }
        }
    }
}