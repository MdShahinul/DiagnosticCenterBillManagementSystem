using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DiagnosticCenterBillManagement.DCBMModelClass;

namespace DiagnosticCenterBillManagement.DCBMGateway
{
    public class TestTypeSetupGateway
    {
        string connectingString = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public int InsertType(TestTypeSetupClass testTypeSetupClass)
        {
            SqlConnection connection = new SqlConnection(connectingString);
            string query = "INSERT INTO TypeName VALUES ('" + testTypeSetupClass.TypeName + "');";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }
        public List<TestTypeSetupClass> GetAllType()
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

        public bool CheckInsertType(TestTypeSetupClass testTypeSetupClass)
        {
            bool isTypeNameExists = false;
            SqlConnection connection = new SqlConnection(connectingString);
            string query = "SELECT * FROM TypeName WHERE TypeName = '" + testTypeSetupClass.TypeName + "';";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                isTypeNameExists = true;
            }
            return isTypeNameExists;
        }
    }
}