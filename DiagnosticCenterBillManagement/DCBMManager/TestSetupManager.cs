using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagement.DCBMGateway;
using DiagnosticCenterBillManagement.DCBMModelClass;

namespace DiagnosticCenterBillManagement.DCBMManager
{
    public class TestSetupManager
    {
        TestSetupGateway testSetupGateway = new TestSetupGateway();
        TestTypeSetupGateway testTypeSetupGateway = new TestTypeSetupGateway();
        public string SaveTestName(TestSetupClass testSetupClass)
        {
            if (!testSetupGateway.IsNumber(testSetupClass))
            {
                return "Fee Must Be a Number.";
            }
            if (testSetupGateway.IsTestNameExists(testSetupClass))
            {
                return "Test Name Allready Listed";
            }
            int rowAffected = testSetupGateway.InserTypeName(testSetupClass);
            if (rowAffected > 0)
            {
                return "Saved Successfully!";
            }
            else
            {
                return "Insertion Failed!";
            }

        }

        public List<TestSetupClass> GetAllTestName()
        {
            return testSetupGateway.GetAllTestNames();
        }
        public List<TestTypeSetupClass> GetAllTestType()
        {
            return testTypeSetupGateway.GetAllType();
        }
    }
}