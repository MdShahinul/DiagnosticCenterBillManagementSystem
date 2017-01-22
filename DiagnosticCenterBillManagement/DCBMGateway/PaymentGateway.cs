using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiagnosticCenterBillManagement.DCBMModelClass;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace DiagnosticCenterBillManagement.DCBMGateway
{
    public class PaymentGateway
    {
        string connectingString = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public List<PaymentClass> GetAllInvoiceBill()
        {
            SqlConnection connection = new SqlConnection(connectingString);
            string query = "SELECT TestName, Fee FROM TestDetails WHERE PatientInvoiceNumber =';";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<PaymentClass> testNames = new List<PaymentClass>();
            while (reader.Read())
            {
                string testName = reader["TestName"].ToString();
                string fee = reader["Fee"].ToString();
                int testTypeId = (int)reader["TestTypeId"];
                PaymentClass test = new PaymentClass();
                testNames.Add(test);
            }
            reader.Close();
            connection.Close();
            return testNames;
        }
    }
}