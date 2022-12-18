<%@ Page Title="" Language="C#" MasterPageFile="~/swift.Master" AutoEventWireup="true" CodeBehind="visitProfile.aspx.cs" Inherits="SWIFT.visitProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container-fluid">
      <div class="row">
         <div class="col-md-5 mx-auto">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <asp:Image id="picUser" ImageUrl="imgs/generaluser.png" runat="server" CssClass="w-50"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Profil Tutor</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-12">
                        <label>Nama Panjang</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="NamaUser" runat="server" placeholder="Nama Panjang" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col-md-7">
                        <label>NIM</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="NIMUser" runat="server" placeholder="NIM" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                       <div class="col-md-5">
                        <label>Jenis Kelamin</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="genderUser" runat="server" placeholder="gender" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                       </div>
                   <div class="row">
                      <div class="col-md-7">
                        <label>Departemen</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="deptUser" runat="server" placeholder="Departemen" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-5">
                        <label>Angkatan</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="angkatanUser" runat="server" placeholder="Angkatan" TextMode="Number" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>    
                  </div>
                    <div class="row">
                <div class="col-md-7">
                        <label>Email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="emailUser" runat="server" placeholder="Email" TextMode="Email" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-5">
                        <label>No Telepon</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="teleponUser" runat="server" placeholder="No Telepon" TextMode="Number" ReadOnly="True"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <asp:TextBox CssClass="form-control" ID="descBox" runat="server" TextMode="MultiLine" placeholder="Deskripsi"/>
                         </center>
                     </div>      
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br><br>
         </div>
         </div>
    </div>
    </div>
</asp:Content>
