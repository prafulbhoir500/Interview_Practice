<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridViewCRUD.aspx.cs" Inherits="Interview_Practice.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Grid View CRUD</title>
    <link href="Assets/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h1 class="text-center">Person Data</h1>
        <div class="container">
            <asp:GridView ID="GridViewPerson" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" ShowFooter="True" DataKeyNames="ID" OnRowCommand="GridViewPerson_RowCommand" OnRowEditing="GridViewPerson_RowEditing" OnRowCancelingEdit="GridViewPerson_RowCancelingEdit" OnRowDeleting="GridViewPerson_RowDeleting" OnRowUpdating="GridViewPerson_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtName" runat="server" Text='<%#Eval("Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtNameFooter" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <asp:Label ID="lblGender" runat="server" Text='<%#Eval("Gender") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtGender" runat="server" Text='<%#Eval("Gender") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtGenderFooter" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="City">
                        <ItemTemplate>
                            <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCity" runat="server" Text='<%#Eval("City") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCityFooter" runat="server"></asp:TextBox>
                        </FooterTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Action">
                         <ItemTemplate>
                             <asp:LinkButton ID="lbtnEdit" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                             <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete">Delete</asp:LinkButton>
                         </ItemTemplate>
                         <EditItemTemplate>
                             <asp:LinkButton ID="lbtnUpdate" runat="server" CommandName="Update">Update</asp:LinkButton>
                             <asp:LinkButton ID="lbtnCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                         </EditItemTemplate>
                         <FooterTemplate>
                             <asp:LinkButton ID="lbtnAddNew" runat="server" CommandName="AddNew" CssClass="btn btn-primary">Add New Record</asp:LinkButton>
                         </FooterTemplate>
                     </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
