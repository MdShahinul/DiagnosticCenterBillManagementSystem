<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TypeWiseReportUI.aspx.cs" Inherits="DiagnosticCenterBillManagement.DCBMUI.TypeWiseReportUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 98px;
        }

        .auto-style2 {
            width: 91px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <legend>Test Wise Report</legend>

                <table>
                    <td>
                        <asp:LinkButton ID="homeLinkButton" runat="server" OnClick="homeLinkButton_Click1" >HOME</asp:LinkButton>
                    </td>
                    <tr>
                        <td>From Date</td>
                        <td>
                            <asp:TextBox ID="fromDateTextBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>To Date</td>
                        <td>
                            <asp:TextBox ID="toDateTextBox" runat="server" Width="128px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="showButton" runat="server" Text="Show" OnClick="showButton_Click" />
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="GridView1" AutoGenerateColumns="False" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="SL">
                            <ItemTemplate>
                                <%#Container.DataItemIndex +1 %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Test Type Name">
                            <ItemTemplate>
                                <%#Eval("")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total no of Test">
                            <ItemTemplate>
                                <%#Eval("")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Amount">
                            <ItemTemplate>
                                <%#Eval("")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <table>
                    <tr>
                        <td class="auto-style1">
                            <asp:Button ID="pdfButton" runat="server" Text="PDF" Width="34px" />
                        </td>
                        <td class="auto-style2">Total</td>
                        <td>
                            <asp:TextBox ID="totalTextBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>

            </fieldset>
        </div>
    </form>
</body>
</html>
