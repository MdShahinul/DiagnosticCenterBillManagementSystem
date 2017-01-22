using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagement.DCBMModelClass;

namespace DiagnosticCenterBillManagement
{
    public partial class PaymentUI : System.Web.UI.Page
    {
        String connectionString = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string billNumber = searchTextBox.Text;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "Select * FROM TestDetails WHERE PatientInvoiceNumber = '" + billNumber + "';";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlParameter search = new SqlParameter();
            search.ParameterName = "@SearchByTagTB";
            search.Value = billNumber.Trim();
            cmd.Parameters.Add(search);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            showBillGridView.DataSource = dt;
            showBillGridView.DataBind();
            searchTextBox.ReadOnly = true;
            TextBoxField();
        }

        public void TextBoxField()
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "Select * from paymentView1 where PatientInvoiceNumber ='" + searchTextBox.Text + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            PaymentClass paymentClass = null;
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                dataReader.Read();
                string invoiceDate = dataReader["InvoiceeDate"].ToString();
                string amount = dataReader["TotalBil"].ToString();
                string paidAmount = dataReader["PaidBill"].ToString();
                string dueAmount = dataReader["DueBill"].ToString();
                paymentClass = new PaymentClass(invoiceDate, amount, paidAmount, dueAmount);
                dataReader.Close();
            }
            con.Close();
            
            billDateLabel.Text = paymentClass.BillDate;
            totalFeeLabel.Text = paymentClass.Amount;
            paidAmountLabel.Text = paymentClass.PaidAnount;
            dueAmountLabel.Text = paymentClass.DueAmount;
        }

        protected void payButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            string query = "update paymentView1 set PaidBill +='" + amountTextBox.Text + "', DueBill -= '" + amountTextBox.Text + "' where PatientInvoiceNumber = '" + searchTextBox.Text + "';";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            int rowAffecd = cmd.ExecuteNonQuery();
            if (rowAffecd > 0)
            {
                massageLabel.Text = "Bill Paid";
                TextBoxField();
            }
            else
            {
                massageLabel.Text = "Faild.";
            }
            con.Close();
            amountTextBox.Text=String.Empty;
        }

        protected void homeLinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("IndexUI.aspx");
        }
    }
}