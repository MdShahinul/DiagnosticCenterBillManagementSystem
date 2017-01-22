<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestRequestEntry.aspx.cs" Inherits="DiagnosticCenterBillManagement.DCBMUI.TestRequestEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Request Entry</title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css" />
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#dateOfBirthTextBox").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "-100:+0"
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <fieldset>
                <asp:LinkButton ID="homeLinkButton" runat="server" OnClick="homeLinkButton_Click">HOME</asp:LinkButton>
                <legend>Test Request Entry</legend>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Name Of The Patient"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="patientTextBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Date Of Birth"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="dateOfBirthTextBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Mobile No"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="mobileNoTextBox" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Select Test"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="testNameDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="testNameDropDownList_SelectedIndexChanged"></asp:DropDownList><br />
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Fee"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="feeTextBox" runat="server" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <asp:Button ID="addButton" runat="server" Text="Add" OnClick="addButton_Click" />
                        </td>
                    </tr>
                </table>
                <asp:Label ID="messageLabel" runat="server" Text=""></asp:Label>
            </fieldset>

            <asp:GridView ID="testRequestEntryGridView" runat="server" AutoGenerateColumns="False" Width="380px">
                <Columns>
                    <asp:TemplateField HeaderText="Serial Number">
                        <ItemTemplate><%#Container.DataItemIndex + 1 %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Test Name">
                        <ItemTemplate><%#Eval("TestName") %></ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fee">
                        <ItemTemplate><%#Eval("Fee") %></ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />

            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="Total : "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="totalTextBox" runat="server" ReadOnly="True"></asp:TextBox><br />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
                    </td>
                </tr>
            </table>
            <asp:Label ID="resultLabel" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
