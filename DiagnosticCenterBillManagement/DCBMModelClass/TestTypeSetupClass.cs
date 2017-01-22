using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiagnosticCenterBillManagement.DCBMModelClass
{
    public class TestTypeSetupClass
    {
        public int Id { get; set; }
        public string TypeName { get; set; }

        public TestTypeSetupClass(int id, string typeName)
        {
            Id = id;
            TypeName = typeName;
        }

        public TestTypeSetupClass(string typeName)
        {
            TypeName = typeName;
        }
    }
}