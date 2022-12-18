<%@ Page Title="" Language="C#" MasterPageFile="~/swift.Master" AutoEventWireup="true" CodeBehind="viewProfile.aspx.cs" Inherits="SWIFT.viewProfile" %>
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
                           <h4>Profil Anda</h4>
                        </center>
                     </div>
                  </div>
                   <div class="row">
                     <div class="col">
                        <center>
                           <asp:FileUpload ID="tutorPIC" runat="server" />
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
                           <asp:TextBox CssClass="form-control" ID="NamaUser" runat="server" placeholder="Nama Panjang"></asp:TextBox>
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
                           <asp:TextBox class="form-control" ID="deptUser" runat="server" placeholder="Departemen"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-5">
                        <label>Angkatan</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="angkatanUser" runat="server" placeholder="Angkatan" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>    
                  </div>
                    <div class="row">
                <div class="col-md-7">
                        <label>Email</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="emailUser" runat="server" placeholder="Email" TextMode="Email"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-5">
                        <label>No Telepon</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="teleponUser" runat="server" placeholder="No Telepon" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <asp:TextBox CssClass="form-control" ID="descBox" runat="server" TextMode="MultiLine" placeholder="Deskripsi"/>
                         </center>
                     </div>      
                  <div class="row">
                     <div class="col-md-6">
                        <label>Password Lama</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="oldPass" runat="server" placeholder="Password lama" TextMode="Password"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-6">
                        <label>Password baru</label>
                        <div class="form-group">
                           <asp:TextBox class="form-control" ID="newPass" runat="server" placeholder="Password baru" TextMode="Password"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-5 mx-auto">
                        <center>
                           <div class="form-group">
                              <asp:Button class="btn btn-primary btn-block btn-lg" ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click" />
                           </div>
                        </center>
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br><br>
         </div>
         </div>
    </div>
    </div>
</asp:Content>
