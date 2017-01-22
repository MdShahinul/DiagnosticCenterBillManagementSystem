<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTypeSetupUI.aspx.cs" Inherits="DiagnosticCenterBillManagement.DCBMUI.TestTypeSetupUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Type Setup</title>
</head>
<body>
    <form id="form1" runat="server">
    <div> 
        <fieldset>
            <legend>Test Type Setup</legend>
        <asp:LinkButton ID="homeLinkButton1" runat="server" OnClick="homeLinkButton1_Click">HOME</asp:LinkButton>
           <table>
               <tr>
                   <td>
                        <asp:Label ID="Label1" runat="server" Text="Type Name"></asp:Label>
                   </td>
                   <td>
                         <asp:TextBox ID="typeNameTextBox" runat="server"></asp:TextBox> <br/>
                   </td>
               </tr>
               
               <tr>
                   <td>
                        <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
                   </td>
                   <td>
                        <asp:Button ID="showButton" runat="server" Text="Show" OnClick="showButton_Click" /><br/>
                   </td>
               </tr>
           </table>
            <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
        </fieldset>
    </div>
        <asp:GridView ID="typeNameGridView" runat="server" AutoGenerateColumns="False" Width="305px">
             <Columns>
                <asp:TemplateField HeaderText="SL">
                    <ItemTemplate><%#Eval("Id") %></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Type Name">
                    <ItemTemplate><%#Eval("typeName") %></ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
