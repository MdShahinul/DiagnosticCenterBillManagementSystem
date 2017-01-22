<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentUI.aspx.cs" Inherits="DiagnosticCenterBillManagement.PaymentUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <fieldset>
            <legend>PayBill</legend>
            <asp:LinkButton ID="homeLinkButton1" runat="server" OnClick="homeLinkButton1_Click">HOME</asp:LinkButton>
                <fieldset>
                    <asp:Label ID="Label1" runat="server" Text="Bill No"></asp:Label>
                    <asp:TextBox ID="searchTextBox" runat="server"></asp:TextBox>
                    <asp:Button ID="searchButton" runat="server" Text="Search" OnClick="searchButton_Click" />
                </fieldset>
                <fieldset>
                    <asp:GridView ID="showBillGridView" runat="server" AutoGenerateColumns="False" Width="380px">
                        <Columns>
                            <asp:TemplateField HeaderText="SL">
                                <ItemTemplate><%#Container.DataItemIndex + 1 %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Test">
                                <ItemTemplate><%#Eval("TestName") %></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fee">
                                <ItemTemplate><%#Eval("Fee") %></ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="Label2" runat="server" Text="Bill Date : "></asp:Label>
                    <asp:Label ID="billDateLabel" runat="server" Text=""></asp:Label><br/>
                    <asp:Label ID="Label4" runat="server" Text="Total Fee : "></asp:Label>
                    <asp:Label ID="totalFeeLabel" runat="server" Text=""></asp:Label><br/>
                    <asp:Label ID="Label6" runat="server" Text="Paid Amount : "></asp:Label>
                    <asp:Label ID="paidAmountLabel" runat="server" Text=""></asp:Label><br/>
                    <asp:Label ID="Label8" runat="server" Text="Due Amount : "></asp:Label>
                    <asp:Label ID="dueAmountLabel" runat="server" Text=""></asp:Label><br/>
                    <asp:Label ID="Label10" runat="server" Text="Amount : "></asp:Label>
                    <asp:TextBox ID="amountTextBox" runat="server"></asp:TextBox><br/>
                    <asp:Button ID="payButton" runat="server" Text="Pay" OnClick="payButton_Click" />
                    <asp:Label ID="massageLabel" runat="server" Text=""></asp:Label>
                </fieldset>
        </fieldset>
    </div>
    </form>
</body>
</html>
