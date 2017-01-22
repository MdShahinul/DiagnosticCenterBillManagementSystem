using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagement.DCBMManager;
using DiagnosticCenterBillManagement.DCBMModelClass; 
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace DiagnosticCenterBillManagement.DCBMUI
{
    public partial class UnpaidBillReportClassUI : System.Web.UI.Page
    {
        private string connectingString = WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        private UnpaidBillReportManager unpaidBillReportManager = new UnpaidBillReportManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGridView();
        }

        public void LoadGridView()
        {
            GridView.DataSource = unpaidBillReportManager.GateUnpaidBill();
            GridView.DataBind();
            totalTextBox.Text = unpaidBillReportManager.GatTotalBill().ToString();
        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectingString);
            conn.Open();
            SqlCommand cmd =
                new SqlCommand(
                    "Select * FROM unpaidBillReport WHERE InvoiceeDate Between '" + fromDateTextBox.Text + "' AND '" +
                    toDateTextBox.Text + "'", conn);
            try
            {
                SqlParameter search = new SqlParameter();
                search.ParameterName = "@SearchByTagTB";
                search.Value = fromDateTextBox.Text.Trim();
                cmd.Parameters.Add(search);
                SqlDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                GridView.DataSource = dt;
                GridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                //Connection Object Closed
                conn.Close();
            }
        }

        protected void homeLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("IndexUI.aspx");
        }

        protected void pdfButton_Click(object sender, EventArgs e)
        {
            FdfGenerate();
        }


        public void FdfGenerate()
        {

            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            doc.Open();
            Paragraph paragraph = new Paragraph("Diagonstic Center Bill Management System:");
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(doc,
                    new FileStream("C:/Users/SHAHIN/Downloads/D00S.pdf", FileMode.Create));
                PdfPTable pdfTable = new PdfPTable(4);
                pdfTable.HorizontalAlignment = 1;
                pdfTable.SpacingBefore = 20f;
                pdfTable.SpacingAfter = 20f;

                string query = "Select * from unpaidBillReport";
                SqlConnection con = new SqlConnection(connectingString);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                List<UnpaidBillReportClass> unpaidBillReportClasses = new List<UnpaidBillReportClass>();
                while (dataReader.Read())
                {
                    UnpaidBillReportClass unpaidBillReport = new UnpaidBillReportClass();
                    unpaidBillReport.InvoiceNumber = dataReader["InvoiceNumber"].ToString();
                    unpaidBillReport.PatientName = dataReader["PatientName"].ToString();
                    unpaidBillReport.MobileNumber = dataReader["MobileNumber"].ToString();
                    unpaidBillReport.DueBill = dataReader["DueBill"].ToString();
                    unpaidBillReportClasses.Add(unpaidBillReport);
                }

                pdfTable.AddCell("InvoiceNumber");
                pdfTable.AddCell("PatientName");
                pdfTable.AddCell("MobileNumber");
                pdfTable.AddCell("DueBill");

                foreach (var Report in unpaidBillReportClasses)
                {
                    pdfTable.AddCell(Report.InvoiceNumber);
                    pdfTable.AddCell(Report.PatientName);
                    pdfTable.AddCell(Report.MobileNumber);
                    pdfTable.AddCell(Report.DueBill);
                }
                doc.Open();
                doc.Add(paragraph);
                doc.Add(pdfTable);
                doc.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                doc.Close();

            }
        }
    }
}