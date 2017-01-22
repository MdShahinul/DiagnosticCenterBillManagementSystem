using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagnosticCenterBillManagement.DCBMModelClass;

namespace DiagnosticCenterBillManagement.DCBMGateway
{
    public class TestSetupGateway
    {
        string connectingString = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        public int InserTypeName(TestSetupClass testSetupClass)
        {
            SqlConnection connection = new SqlConnection(connectingString);
            string query = "INSERT INTO TestName VALUES('" + testSetupClass.TestName + "','" + testSetupClass.Fee + "','" + testSetupClass.TestTypeId + "');";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public bool IsNumber(TestSetupClass testSetupClass)
        {
            bool isNumber = false;
            decimal number;
            string numner = Convert.ToString(testSetupClass.Fee);
            if (Decimal.TryParse(numner, out number))
            {
                isNumber = true;
            }
            return isNumber;
        }
        public bool IsTestNameExists(TestSetupClass testSetupClass)
        {
            bool isTestNameExists = false;
            SqlConnection connection = new SqlConnection(connectingString);
            string query = "SELECT * FROM TestName WHERE TestName ='" + testSetupClass.TestName + "';";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                isTestNameExists = true;
            }
            return isTestNameExists;
        }
        public List<TestSetupClass> GetAllTestNames()
        {
            SqlConnection connection = new SqlConnection(connectingString);
            string query = "SELECT * FROM TestName;";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<TestSetupClass> testNames = new List<TestSetupClass>();
            while (reader.Read())
            {
                string testName = reader["TestName"].ToString();
                string fee = reader["Fee"].ToString();
                int testTypeId = (int)reader["TestTypeId"];
                TestSetupClass test = new TestSetupClass(testName, fee, testTypeId);
                testNames.Add(test);
            }
            reader.Close();
            connection.Close();
            return testNames;
        }
        public List<TestTypeSetupClass> GetAllTestType()
        {
            SqlConnection connection = new SqlConnection(connectingString);
            string query = "SELECT * FROM TypeName;";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<TestTypeSetupClass> typeNames = new List<TestTypeSetupClass>();
            while (reader.Read())
            {
                int id = (int)reader["Id"];
                string typeName = reader["TypeName"].ToString();
                TestTypeSetupClass name = new TestTypeSetupClass(id, typeName);
                typeNames.Add(name);
            }
            reader.Close();
            connection.Close();
            return typeNames;
        }
    }
}