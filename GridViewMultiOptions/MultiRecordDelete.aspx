<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MultiRecordDelete.aspx.cs" Inherits="Interview_Practice.GridViewMultiOptions.MultiRecordDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Delete Multi Records</title>
    <link href="../Assets/bootstrap.css" rel="stylesheet" />
    <style>
        #rdoGender label {
            margin-left: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row justify-content-center mt-3">
                <div class="col-md-6 col-sm-12">
                    <div class="card">
                        <div class="card-title text-center">
                            <h1>Fill Details</h1>
                        </div>

                        <div class="card-body">
                            <div class="row justify-content-between">
                                <div class="col-auto">
                                    <label class="col-form-label">Name</label>
                                </div>
                                <div class="col-10">
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-auto">
                                    <label class="col-form-label">Gender</label>
                                </div>
                                <div class="col-10">
                                    <asp:RadioButtonList ID="rdoGender" runat="server" RepeatDirection="Horizontal" CellPadding="10">
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                        <asp:ListItem>Other</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>

                            <div class="row justify-content-between">
                                <div class="col-auto">
                                    <label class="col-form-label">City</label>
                                </div>
                                <div class="col-10">
                                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                            <div class="mt-5 text-center">
                                <asp:Button ID="btnSubmit" CssClass="btn btn-primary" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="mt-5">
                <asp:GridView ID="GridViewPersonData" runat="server" CssClass="table table-bordered text-center" DataKeyNames="ID" AutoGenerateColumns="false">
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
                                <label><%#Eval("gender") %></label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="City">
                            <ItemTemplate>
                                <label><%#Eval("city") %></label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkRecord" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </div>

            <div class="my-3 text-end">
                <asp:Button ID="btnDelete" runat="server" Text="Delete Selected Records" CssClass="btn btn-danger" OnClick="btnDelete_Click" />
            </div>

        </div>


    </form>
</body>
</html>
