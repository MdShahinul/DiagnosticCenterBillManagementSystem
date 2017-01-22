using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiagnosticCenterBillManagement.DCBMUI
{
    public partial class IndexUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TestTypeSetupButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestTypeSetupUI.aspx");
        }

        protected void TestSetupButton_Click(object sender, EventArgs e)
        {
           Response.Redirect("TestSetup.aspx");
        }

        protected void TestRequestEntryButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestRequestEntry.aspx");
        }

        protected void paymentLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaymentUI.aspx");
        }

        protected void testWiseReportLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("TestWiseReportUI.aspx");
        }

        protected void typeWiseReportLinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("TypeWiseReportUI.aspx");
        }

        protected void unpaidBillReportLinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UnpaidBillReport.aspx");
        }

       
    }
}