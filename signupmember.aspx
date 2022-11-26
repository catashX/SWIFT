<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signupmember.aspx.cs" Inherits="SWIFT.signupmember" %>

<!DOCTYPE html>
<html lang="en" dir="ltr">
  <head>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="css/signupmemb.css">
     <meta name="viewport" content="width=device-width, initial-scale=1.0">
   </head>
<body>
  <div class="container">
    <div class="title">Pendaftaran Member</div>
    <div class="content">
      <form action="signupmember.aspx" runat="server">
        <div class="user-details">
          <div class="input-box">
            <span class="details">Nama Panjang</span>
              <!-- <input type="text" placeholder="Nama" required id="namaPanjangMember" runat="server"> -->
               <asp:TextBox Cssclass="form-control" ID="namaMember" runat="server" placeholder="Nama"></asp:TextBox>
          </div>
          <div class="input-box">
            <span class="details">NIM</span>
                <asp:TextBox Cssclass="form-control" ID="member_nim" runat="server" placeholder="NIM"></asp:TextBox>
          </div>
          <div class="input-box">
            <span class="details">Angkatan</span>
            <asp:TextBox Cssclass="form-control" ID="member_angkatan" runat="server" placeholder="angkatan" TextMode="Number"></asp:TextBox>
          </div>
          <div class="input-box">
            <span class="details">Departemen</span>
             <asp:TextBox Cssclass="form-control" ID="member_departemen" runat="server" placeholder="departemen"></asp:TextBox>
          </div>
          <div class="input-box">
            <span class="details">Email</span>
             <asp:TextBox Cssclass="form-control" ID="member_email" runat="server" placeholder="email" TextMode="Email"></asp:TextBox>
          </div>
          <div class="input-box">
            <span class="details">Nomor Telepon/Whatsapp</span>
             <asp:TextBox Cssclass="form-control" ID="member_telepon" runat="server" placeholder="telepon" TextMode="Number"></asp:TextBox>
          </div>
          <div class="input-box">
            <span class="details">Password</span>
            <asp:TextBox Cssclass="form-control" ID="member_pass" runat="server" placeholder="password" TextMode="Password"></asp:TextBox>
          </div>
          <div class="input-box">
            <span class="details">Ketik Ulang Password</span>
            <asp:TextBox Cssclass="form-control" ID="member_passwordRep" runat="server" placeholder="password" TextMode="Password"></asp:TextBox>
          </div>
              <div class="gender-details">
            <asp:RadioButton Groupname="gender" id="dot1" runat="server" />
            <asp:RadioButton Groupname="gender" id="dot2" runat="server" />
          <span class="gender-title">Gender</span>
          <div class="category">
           <label for="dot1">
            <span class="dot one"></span>
            <span class="gender">Male</span>
          </label>
          <label for="dot2">
            <span class="dot two"></span>
            <span class="gender">Female</span>
          </label>
          </div>
        </div>
            <div class="button">
            <asp:Button ID="RegButtonMember" runat="server" text="Register" OnClick="RegButtonMember_Click" />
            </div>
        </div>
       </form>
    </div>
  </div>

</body>
</html>

