<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestSetup.aspx.cs" Inherits="DiagnosticCenterBillManagement.DCBMUI.TestSetup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Setup</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          
            <fieldset>
                <legend>Test Setup</legend>
                <asp:LinkButton ID="homeLinkButton" runat="server" OnClick="homeLinkButton_Click">HOME</asp:LinkButton>
                  
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Test Name"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="testNameTextBox" runat="server"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Fee"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="feeTextBox" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="BDT"></asp:Label><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Test Type"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="testTypeDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="testTypeDropDownList_SelectedIndexChanged"></asp:DropDownList><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
            </fieldset>
            <asp:GridView ID="showTestNameGridView" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Serial Number">
                        <ItemTemplate>
                            <%#Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Test Name">
                        <ItemTemplate>
                            <%#Eval("TestName") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fee">
                        <ItemTemplate>
                            <%#Eval("Fee") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Test Type">
                        <ItemTemplate>
                            <%#Eval("TestTypeId") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
