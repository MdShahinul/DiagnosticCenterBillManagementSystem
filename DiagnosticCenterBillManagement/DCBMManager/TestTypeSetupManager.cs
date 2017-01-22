using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagement.DCBMGateway;
using DiagnosticCenterBillManagement.DCBMModelClass;

namespace DiagnosticCenterBillManagement.DCBMManager
{
    public class TestTypeSetupManager
    {
        TestTypeSetupGateway testTypeSetupGateway = new TestTypeSetupGateway();
        TestSetupGateway testSetupGateway = new TestSetupGateway();
        public string SaveType(TestTypeSetupClass testTypeSetupClass)
        {
            bool rowExits = testTypeSetupGateway.CheckInsertType(testTypeSetupClass);
            if (rowExits)
            {
                return "Type Name already exists!";
            }
            int rowAffected = testTypeSetupGateway.InsertType(testTypeSetupClass);
            if (rowAffected > 0)
            {
                return "Saved Successfully!";
            }
            else
            {
                return "Insertion Failed!";
            }
        }
        public List<TestTypeSetupClass> GetAllType()
        {
            return testTypeSetupGateway.GetAllType();
        }
    }
}