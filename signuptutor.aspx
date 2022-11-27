<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signuptutor.aspx.cs" Inherits="SWIFT.signuptutor" %>

<!DOCTYPE html>
<html lang="en" dir="ltr">
  <head>
     <title>Sign Up</title>
    <meta charset="UTF-8">
      <link href="css/signupmemb.css" rel="stylesheet" />
     <meta name="viewport" content="width=device-width, initial-scale=1.0">
   </head>
<body>
  <div class="container">
    <div class="title">Pendaftaran Tutor</div>
    <div class="content">
      <form action="signupmember.aspx" runat="server">
        <div class="user-details">
          <div class="input-box">
            <span class="details">Nama Panjang</span>
              <!-- <input type="text" placeholder="Nama" required id="namaPanjangMember" runat="server"> -->
               <asp:TextBox Cssclass="form-control" ID="namaTutor" runat="server" placeholder="Nama"></asp:TextBox>
          </div>
          <div class="input-box">
            <span class="details">NIM</span>
                <asp:TextBox Cssclass="form-control" ID="tutor_nim" runat="server" placeholder="NIM"></asp:TextBox>
          </div>
          <div class="input-box">
            <span class="details">Angkatan</span>
            <asp:TextBox Cssclass="form-control" ID="tutor_angkatan" runat="server" placeholder="angkatan" TextMode="Number"></asp:TextBox>
          </div>
          <div class="input-box">
            <span class="details">Departemen</span>
             <asp:TextBox Cssclass="form-control" ID="tutor_departemen" runat="server" placeholder="departemen"></asp:TextBox>
          </div>
          <div class="input-box">
            <span class="details">Email</span>
             <asp:TextBox Cssclass="form-control" ID="tutor_email" runat="server" placeholder="email" TextMode="Email"></asp:TextBox>
          </div>
          <div class="input-box">
            <span class="details">Nomor Telepon/Whatsapp</span>
             <asp:TextBox Cssclass="form-control" ID="tutor_telepon" runat="server" placeholder="telepon" TextMode="Number"></asp:TextBox>
          </div>
          <div class="input-box">
            <span class="details">Password</span>
            <asp:TextBox Cssclass="form-control" ID="tutor_pass" runat="server" placeholder="password" TextMode="Password"></asp:TextBox>
          </div>
          <div class="input-box">
            <span class="details">Ketik Ulang Password</span>
            <asp:TextBox Cssclass="form-control" ID="tutor_passwordRep" runat="server" placeholder="password" TextMode="Password"></asp:TextBox>
          </div>
            <div class="input-box">
            <span class="details">Upload KTM</span>
            <asp:FileUpload id="ktm" runat="server"/>
          </div>
           <div class="gender-details">
            <asp:RadioButton Groupname="gender" id="dot_male" runat="server" />
            <asp:RadioButton Groupname="gender" id="dot_female" runat="server" />
          <span class="gender-title">Gender</span>
          <div class="category">
           <label for="dot_male">
            <span class="dot male"></span>
            <span class="gender">Male</span>
          </label>
          <label for="dot_female">
            <span class="dot female"></span>
            <span class="gender">Female</span>
          </label>
          </div>
        </div>
            <div class="button">
            <asp:Button ID="RegButtonTutor" runat="server" text="Register" OnClick="RegButtonTutor_Click" />
            </div>
        </div>
       </form>
    </div>
  </div>

</body>
</html>


