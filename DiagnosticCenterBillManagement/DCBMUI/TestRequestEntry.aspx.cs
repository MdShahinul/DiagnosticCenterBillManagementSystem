using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagement.DCBMManager;
using DiagnosticCenterBillManagement.DCBMModelClass;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace DiagnosticCenterBillManagement.DCBMUI
{
    public partial class TestRequestEntry : System.Web.UI.Page
    {
        TestRequestEntryManager testRequestEntryManager = new TestRequestEntryManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTestName();
        }
        protected void addButton_Click(object sender, EventArgs e)
        {
            string testName = Convert.ToString(testNameDropDownList.SelectedItem);
            decimal fee = Convert.ToDecimal(feeTextBox.Text);

            if (ViewState["Total"] == null)
            {
                List<decimal> list = new List<decimal>();
                list.Add(fee);
                ViewState["Total"] = list;
            }
            else
            {
                List<decimal> list = (List<decimal>)ViewState["Total"];
                list.Add(fee);
                ViewState["Total"] = list;
            }
            decimal total = 0;
            List<decimal> listAll = (List<decimal>)ViewState["Total"];
            foreach (decimal to in listAll)
            {
                total = +total + to;
                totalTextBox.Text = Convert.ToString(total);
            }


            TestRequestEntryClass testRequestEntryClassFee = new TestRequestEntryClass(testName, fee);
            if (ViewState["Test"] == null)
            {
                List<TestRequestEntryClass> testRequest = new List<TestRequestEntryClass>();
                testRequest.Add(testRequestEntryClassFee);
                ViewState["Test"] = testRequest;
            }
            else
            {
                List<TestRequestEntryClass> testRequest = (List<TestRequestEntryClass>)ViewState["Test"];
                testRequest.Add(testRequestEntryClassFee);
                ViewState["Test"] = testRequest;

            }
            List<TestRequestEntryClass> testRequestAll = (List<TestRequestEntryClass>)ViewState["Test"];
            testRequestEntryGridView.DataSource = testRequestAll;
            testRequestEntryGridView.DataBind();
            patientTextBox.ReadOnly = true;
            dateOfBirthTextBox.ReadOnly = true;
            mobileNoTextBox.ReadOnly = true;
            ViewState["Test"] = testRequestAll;
        }
        protected void saveButton_Click(object sender, EventArgs e)
        {
            string patientName = patientTextBox.Text;
            string dateOfBirth = dateOfBirthTextBox.Text;
            string mobileNumber = mobileNoTextBox.Text;
            string invoiceDate = DateTime.Today.ToShortDateString();
            string invoiceNnumber = String.Format("{0:d9}", (DateTime.Now.Ticks / 10) % 1000000000);

            TestRequestEntryClass testRequestEntryClass = new TestRequestEntryClass(patientName, dateOfBirth, mobileNumber, invoiceDate, invoiceNnumber);
            messageLabel.Text = testRequestEntryManager.InsertPatientInformation(testRequestEntryClass);
            List<TestRequestEntryClass> testRequestEntry = (List<TestRequestEntryClass>)ViewState["Test"];
            foreach (var test in testRequestEntry)
            {
                string testName = test.TestName;
                decimal fee = test.Fee;
                string invoice = invoiceNnumber;
                TestRequestEntryClass testRequest = new TestRequestEntryClass(testName, fee, invoice);
                testRequestEntryManager.InsertPatientTest(testRequest);
            }
            string totalBill = totalTextBox.Text;
            string paidBill = Convert.ToString(0);
            string dueBill = totalTextBox.Text;
            string patientInvoiceNumber = invoiceNnumber;
            TestRequestEntryClass testRequestBill = new TestRequestEntryClass(totalBill, paidBill, dueBill, patientInvoiceNumber);
            resultLabel.Text = testRequestEntryManager.InsertPatientBill(testRequestBill);
        }
        private void LoadTestName()
        {
            if (!IsPostBack)
            {
                TestSetupManager testSetupManager = new TestSetupManager();
                List<TestSetupClass> dropDownList = testSetupManager.GetAllTestName();
                testNameDropDownList.DataSource = dropDownList;
                testNameDropDownList.DataValueField = "Fee";
                testNameDropDownList.DataTextField = "TestName";
                testNameDropDownList.DataBind();
                testNameDropDownList.Items.Insert(0, "Select Test");
            }
        }
        protected void testNameDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            feeTextBox.Text = testNameDropDownList.SelectedValue;
        }
        protected void homeLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("IndexUI.aspx");
        }
    }
}