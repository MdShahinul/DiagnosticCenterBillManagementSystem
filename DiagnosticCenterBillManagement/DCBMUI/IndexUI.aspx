<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexUI.aspx.cs" Inherits="DiagnosticCenterBillManagement.DCBMUI.IndexUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <fieldset>
                <legend>HOME PAGE</legend>
                <table style="width: 255px">
                    <tr>
                        <td>
                            <asp:LinkButton ID="TestTypeSetupButton" runat="server" OnClick="TestTypeSetupButton_Click">Test Type Setup</asp:LinkButton>
                            <br />
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="TestSetupButton" runat="server" OnClick="TestSetupButton_Click">Test Setup</asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="TestRequestEntryButton" runat="server" OnClick="TestRequestEntryButton_Click">Test Request Entry </asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LinkButton ID="paymentLinkButton" runat="server" OnClick="paymentLinkButton_Click" >Payment </asp:LinkButton>
                            <br />
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:LinkButton ID="testWiseReportLinkButton" runat="server" OnClick="testWiseReportLinkButton_Click">Test Wise Report</asp:LinkButton>
                            <br />
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:LinkButton ID="typeWiseReportLinkButton1" runat="server" OnClick="typeWiseReportLinkButton1_Click" >Type Wise Report</asp:LinkButton>
                            <br />
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:LinkButton ID="unpaidBillReportLinkButton1" runat="server" OnClick="unpaidBillReportLinkButton1_Click" >Unpaid Bill Report</asp:LinkButton>
                            <br />
                        </td>
                    </tr>
                </table>

            </fieldset>
    </div>
    </form>
</body>
</html>
