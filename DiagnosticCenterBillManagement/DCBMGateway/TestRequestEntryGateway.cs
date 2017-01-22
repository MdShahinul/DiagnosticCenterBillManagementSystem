using DiagnosticCenterBillManagement.DCBMModelClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DiagnosticCenterBillManagement.DCBMGateway
{
    public class TestRequestEntryGateway
    {
        string connectingString = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public int InsertPatientInformation(TestRequestEntryClass testRequestEntryClass)
        {
            SqlConnection connection = new SqlConnection(connectingString);
            string query = "INSERT INTO PatientInformation VALUES ('" + testRequestEntryClass.PatientName + "','" + testRequestEntryClass.DateOfBirth + "','" + testRequestEntryClass.MobileNumber + "','"+ testRequestEntryClass.InvoiceDate +"','"+ testRequestEntryClass.InvoiceNumber +"');";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public int InsertPatientTest(TestRequestEntryClass testRequestEntryClass)
        {
            SqlConnection connection = new SqlConnection(connectingString);
            string query = "INSERT INTO TestDetails VALUES ('" + testRequestEntryClass.TestName + "','" + testRequestEntryClass.Fee + "','"+testRequestEntryClass.InvoiceNumber +"');";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public int InsertPatientBil(TestRequestEntryClass testRequestEntryClass)
        {
            SqlConnection connection = new SqlConnection(connectingString);
            string query = "INSERT INTO PatientBillInformation VALUES ('" + testRequestEntryClass.TotalBil + "','" + testRequestEntryClass.PaidBill + "','"+ testRequestEntryClass.DueBill +"','" + testRequestEntryClass.InvoiceNumber + "');";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
    }
}