<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Multi_Record_Delete_GridView.aspx.cs" Inherits="Interview_Practice.Multi_Record_Delete_GridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Multi Record Delete</title>
    <link href="Assets/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:GridView ID="GridViewPerson" runat="server" CssClass="table table-bordered" DataKeyNames="ID" AutoGenerateColumns="false" ShowFooter="True" OnRowCommand="GridViewPerson_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:BoundField DataField="City" HeaderText="City" />
                    <asp:TemplateField HeaderText="Select Rows">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:LinkButton ID="LinkButton1" CssClass="btn btn-danger" runat="server" CommandName="DeleteMulti">Delete Selected</asp:LinkButton>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
