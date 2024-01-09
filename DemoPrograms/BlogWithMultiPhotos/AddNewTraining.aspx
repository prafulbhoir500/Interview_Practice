<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewTraining.aspx.cs" Inherits="Interview_Practice.DemoPrograms.BlogWithMultiPhotos.AddNewTraining" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Event Form</title>
    <!-- Add Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-4">
        <div>

            <h2>Event Form</h2>
            <div class="form-group">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" />
            </div>
            <div class="form-group">
                <label for="txtTitle">Title:</label>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtDescription">Description:</label>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtConductDate">Conduct Date:</label>
                <asp:TextBox ID="txtConductDate" runat="server" placeholder="MM/DD/YYYY" CssClass="form-control"></asp:TextBox>
                <!-- You may use a Calendar control or a date picker for a better user experience. -->
            </div>
            <div class="form-group">
                <label for="txtConductBy">Conduct By:</label>
                <asp:TextBox ID="txtConductBy" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <div class="row">
                    <div class="col-3">
                        <label for="txtConductBy">Conduct By:</label>
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                    </div>
                    <div class="col-3">
                        <label for="txtConductBy">Conduct By:</label>
                        <asp:TextBox ID="txtImageName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-2">
                        <asp:CheckBox ID="chkActive" runat="server" />
                        <label>Is Active</label>
                    </div>
                    <div class="col-2">
                        <asp:CheckBox ID="chkDefault" runat="server" />
                        <label>Set Default</label>
                    </div>

                    <div class="col-2">
                        <asp:Button ID="btnAddImage" runat="server" Text="Add" OnClick="btnAddImage_Click" />
                    </div>
                </div>
            </div>

            <!-- ... (existing code) ... -->

            <div class="form-group">
                <asp:GridView ID="gvImages" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="ImageURL" HeaderText="Image Path" />
                        <asp:BoundField DataField="ImageAlt" HeaderText="Image Alt Tag" />
                        <asp:BoundField DataField="IsActive" HeaderText="Is Active" />
                        <asp:BoundField DataField="IsDefault" HeaderText="Set Default" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Button ID="btnRemove" runat="server" Text="Remove" OnClick="btnRemove_Click" CommandArgument='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

            <!-- ... (existing code) ... -->


        </div>
    </form>

    <!-- Add Bootstrap JavaScript (optional) -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
