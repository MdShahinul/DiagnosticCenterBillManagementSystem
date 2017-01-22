using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagnosticCenterBillManagement.DCBMModelClass;

namespace DiagnosticCenterBillManagement.DCBMGateway
{
    public class UnpaidBillReportGateway
    {
        string connectingString = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        
        public List<UnpaidBillReportClass> GetUnpaidBill()
        {
            SqlConnection con = new SqlConnection(connectingString);
            string query = "Select * from unpaidBillReport";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            List<UnpaidBillReportClass> unpaidBillReports = new List<UnpaidBillReportClass>();
            while (dataReader.Read())
            {
                UnpaidBillReportClass unpaidBillReportClass = new UnpaidBillReportClass();
                unpaidBillReportClass.InvoiceNumber = dataReader["InvoiceNumber"].ToString();
                unpaidBillReportClass.PatientName = dataReader["PatientName"].ToString();
                unpaidBillReportClass.MobileNumber = dataReader["MobileNumber"].ToString();
                unpaidBillReportClass.DueBill = dataReader["DueBill"].ToString();
                unpaidBillReports.Add(unpaidBillReportClass);
            }
            con.Close();
            return unpaidBillReports;
        }

        public int TotalBillAmount()
        {
            int total = 0;
            SqlConnection con = new SqlConnection(connectingString);
            string query = "select sum(DueBill) DueBill from unpaidBillReport";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                dataReader.Read();
                total = Convert.ToInt32(dataReader["DueBill"]);
                dataReader.Close();
            }
            con.Close();
            return total;
        }
    }
}