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
    public partial class TestSetup : System.Web.UI.Page
    {
        TestSetupManager testSetupManager = new TestSetupManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTypeDropdown();
            showTestNameGridView.DataSource = testSetupManager.GetAllTestName();
            showTestNameGridView.DataBind();
        }

        protected void saveButton_Click(object sender, EventArgs e)
        {
            string nameTest = testNameTextBox.Text;
            string fee = feeTextBox.Text;
            int testType = Convert.ToInt32(testTypeDropDownList.SelectedValue);
            
            if (testNameTextBox.Text == String.Empty && feeTextBox.Text == String.Empty && testType >0)
            {
                messageLabel.Text = "Please Write Test Name & Fee";
            }
            else
            {
                TestSetupClass testName = new TestSetupClass(nameTest, fee, testType);
                messageLabel.Text = testSetupManager.SaveTestName(testName);
            }
            testNameTextBox.Text = String.Empty;
            feeTextBox.Text = String.Empty;
        }
        private void LoadTypeDropdown()
        {
            if (!IsPostBack)
            {
                TestSetupManager testSetupManager = new TestSetupManager();
                List<TestTypeSetupClass> dropDownList = testSetupManager.GetAllTestType();
                testTypeDropDownList.DataSource = dropDownList;
                testTypeDropDownList.DataValueField = "Id";
                testTypeDropDownList.DataTextField = "TypeName";
                testTypeDropDownList.DataBind(); 
                testTypeDropDownList.Items.Insert(0, "Select Type");
            }
            

        }
        protected void testTypeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void homeLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("IndexUI.aspx");
        }

    }
}