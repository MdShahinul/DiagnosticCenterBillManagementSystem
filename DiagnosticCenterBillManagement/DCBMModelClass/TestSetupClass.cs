using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagement.DCBMModelClass
{
    public class TestSetupClass
    {
        public string TestName { get; set; }
        public string Fee { get; set; }
        public int TestTypeId { get; set; }

        public TestSetupClass(string testName, string fee, int testTypeId)
        {
            TestName = testName;
            Fee = fee;
            TestTypeId = testTypeId;
        }
        public TestSetupClass(string testName, string fee)
        {
            TestName = testName;
            Fee = fee;
        }
    }
}