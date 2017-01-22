<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnpaidBillReport.aspx.cs" Inherits="DiagnosticCenterBillManagement.DCBMUI.UnpaidBillReportClassUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 98px;
        }
        .auto-style2 {
            width: 94px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <fieldset>
            <legend>Unpaid Bill Report</legend>
            
            <td>
                <asp:LinkButton ID="homeLinkButton" runat="server" OnClick="homeLinkButton_Click">HOME</asp:LinkButton>
            </td>
            
            <table>
                <tr>
                    <td>From Date</td>
                    <td>
                        <asp:TextBox ID="fromDateTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>To Date</td>
                    <td>
                        <asp:TextBox ID="toDateTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Button ID="showButton" runat="server" Text="Show" OnClick="showButton_Click" />
                    </td>
                </tr>
            </table>
        </fieldset>

 
        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="False">
            
            <Columns>
                <asp:TemplateField HeaderText="SL">
                    <ItemTemplate>
                        <%#Container.DataItemIndex + 1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Invoicee Number">
                    <ItemTemplate>
                        <%#Eval("InvoiceNumber") %>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="Patient Name">
                    <ItemTemplate>
                        <%#Eval("PatientName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mobile Number">
                    <ItemTemplate>
                        <%#Eval("MobileNumber") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Due Bill">
                    <ItemTemplate>
                        <%#Eval("DueBill") %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
            <table>
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="pdfButton" runat="server" Text="PDF" OnClick="pdfButton_Click" />  
                    </td>
                    <td class="auto-style2">Total</td>
                    <td>
                        <asp:TextBox ID="totalTextBox" runat="server" ReadOnly="True"></asp:TextBox> 
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
