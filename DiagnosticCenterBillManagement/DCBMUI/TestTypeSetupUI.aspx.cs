using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DiagnosticCenterBillManagement.DCBMManager;
using DiagnosticCenterBillManagement.DCBMModelClass;

namespace DiagnosticCenterBillManagement.DCBMUI
{
    public partial class TestTypeSetupUI : System.Web.UI.Page
    {
        TestTypeSetupManager testTypeSetupManager = new TestTypeSetupManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            typeNameGridView.DataSource = testTypeSetupManager.GetAllType();
            typeNameGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string typeName = typeNameTextBox.Text;
            if (typeNameTextBox.Text == String.Empty)
            {
                messageLabel.Text = "Please Write Type Name";
            }
            else
            {
                TestTypeSetupClass testTypeSetupClass = new TestTypeSetupClass(typeName);
                messageLabel.Text = testTypeSetupManager.SaveType(testTypeSetupClass);
            }
            typeNameTextBox.Text = String.Empty;
        }

        protected void showButton_Click(object sender, EventArgs e)
        {
            typeNameGridView.DataSource = testTypeSetupManager.GetAllType();
            typeNameGridView.DataBind();
        }
        protected void homeLinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("IndexUI.aspx");
        }
    }
}