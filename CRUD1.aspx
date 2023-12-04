<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRUD1.aspx.cs" Inherits="Interview_Practice.CRUD1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Grid View</title>
    <link href="Assets/bootstrap.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-title">
                            <h2>Details</h2>
                        </div>
                        <div class="card-body">
                            <div class="mb-3">
                                <label>ID</label>
                                <asp:TextBox ID="txtID" runat="server" placeholder="Auto" Enabled="false"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label>Name</label>
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <label>Gender</label>
                                <asp:DropDownList ID="ddlGender" runat="server">
                                    <asp:ListItem Value="">Select Gender</asp:ListItem>
                                    <asp:ListItem Value="Male">Male</asp:ListItem>
                                    <asp:ListItem Value="Female">Female</asp:ListItem>
                                    <asp:ListItem Value="Other">Other</asp:ListItem>
                                </asp:DropDownList>
                            </div>

                            <div class="mb-3">
                                <label>City</label>
                                <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" OnClick="btnUpdate_Click" />
                                <asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <br />
            <div class="card-body">
                <asp:GridView ID="GridViewData" CssClass="table table-bordered" runat="server" AutoGenerateColumns="false" DataKeyNames="ID" OnRowDeleting="GridViewData_RowDeleting" OnRowEditing="GridViewData_RowEditing">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <label><%#Eval("ID") %></label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <label><%#Eval("Name") %></label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Gender">
                            <ItemTemplate>
                                <label><%#Eval("Gender") %></label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="City">
                            <ItemTemplate>
                                <label><%#Eval("City") %></label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnEdit" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                                <asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete">Delete</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
