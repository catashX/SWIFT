<%@ Page Title="" Language="C#" MasterPageFile="~/swift.Master" AutoEventWireup="true" CodeBehind="loginadmin.aspx.cs" Inherits="SWIFT.loginadmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <section class="container">
        <div class="row content d-flex justify-content-center align-items-center">
        <div class="col-md-5">
            <div  class="box shadow bg-white p-4 rounded">
                <div class="box shadow bg-white p-4">
                    <h3 class="mb-4 text-center fs-1">Log in As Admin</h3>
                        <div class="form-floating mb-3">
                            <asp:TextBox Cssclass="form-control" ID="admin_id_login" runat="server" placeholder="ID"></asp:TextBox>
                            <label for="floatingInput">ID</label>
                        </div>
                        <div class="form-floating mb-3">
                            <asp:TextBox Cssclass="form-control" ID="admin_pass_login" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                            <label for="floatingPassword">Password</label>
                        </div>
                        <div class="form-check mb-3">
                            <input class="form-check-input" type="checkbox" id="autoSizingCheck2">
                            <label class="form-check-label">Remember me</label>
                        </div>
                        <div class="d-grip gap-2 mb-3">
                            <asp:Button ID="LoginAdminButton" runat="server" text="Login" OnClick="LoginAdminButton_Click" />
                        </div>
                </div>
            </div>
        </div>
        </div>

    </section>
</asp:Content>

