<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signuptutor.aspx.cs" Inherits="SWIFT.signuptutor" %>

<!DOCTYPE html>
<html lang="en" dir="ltr">
  <head>
      <title>Sign Up</title>
    <meta charset="UTF-8">
    <link rel="stylesheet" href="css/signupmemb.css">
     <meta name="viewport" content="width=device-width, initial-scale=1.0">
   </head>
<body>
  <div class="container">
    <div class="title">Pendaftaran Tutor</div>
    <div class="content">
      <form action="#">
        <div class="user-details">
          <div class="input-box">
            <span class="details">Nama Panjang</span>
            <input type="text" placeholder="Masukkan Nama Panjang Anda" required>
          </div>
          <div class="input-box">
            <span class="details">NIM</span>
            <input type="text" placeholder="Masukkan NIM Anda" required>
          </div>
          <div class="input-box">
            <span class="details">Angkatan</span>
            <input type="number" placeholder="Masukkan Angkatan Anda" required>
          </div>
          <div class="input-box">
            <span class="details">Departemen</span>
            <input type="text" placeholder="Masukkan Departemen Anda" required>
          </div>
          <div class="input-box">
            <span class="details">Email</span>
            <input type="text" placeholder="Masukkan Email Anda" required>
          </div>
          <div class="input-box">
            <span class="details">Nomor Telepon/Whatsapp</span>
            <input type="text" placeholder="Masukkan Nomor Telepon Anda" required>
          </div>
          <div class="input-box">
            <span class="details">Password</span>
            <input type="text" placeholder="Masukkan Password" required>
          </div>
          <div class="input-box">
            <span class="details">Ketik Ulang Password</span>
            <input type="text" placeholder="Ketik Ulang Password Anda" required>
          </div>
          <div class="input-box">
            <span class="details">Upload KTM</span>
            <input type="file" placeholder="Upload KTM Anda" required>
          </div>
        </div>
        <div class="gender-details">
          <input type="radio" name="gender" id="dot_male">
          <input type="radio" name="gender" id="dot_female">
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
          <input type="submit" value="Register">
        </div>
      </form>
    </div>
  </div>

</body>
</html>


