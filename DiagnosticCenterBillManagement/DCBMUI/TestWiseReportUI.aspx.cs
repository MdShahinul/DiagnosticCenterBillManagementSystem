using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DiagnosticCenterBillManagement.DCBMUI
{
    public partial class TestWiseReportUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void homeLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("IndexUI.aspx");
        }
    }
}