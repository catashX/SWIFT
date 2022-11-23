<%@ Page Title="" Language="C#" MasterPageFile="~/swift.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="SWIFT.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>SWIFT</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero vh-100 d-flex align-items-center" id="home">
        <div class="container">
            <div class="row">
                <div class="col-lg-7 mx-auto text-center">
                    <h1 class="display-4 text-white"><img class="logo" src="img/logoerase3.png" alt="" style="width: 250px;"></h1>
                    <p class="text-white my-3">SWIFT (Study With Your Favorite Tutor) merupakan website untuk memfasilitasi mahasiswa PKU IPB University yang sedang mencari tutor, juga mahasiswa semester 3 ke atas yang ingin mencari pekerjaan sampingan sebagai seorang tutor.</p>
                    <a href="login.aspx" class="btn btn-outline-light">Log In</a>
                    <a href="signupmember.aspx" class="btn btn-outline-light">Sign Up</a>
                </div>
            </div>
        </div>
    </div><!-- //HERO -->

    <!-- SERVICES -->
    <section id="services">
        <div class="container">
            <div class="row mb-5">
                <div class="col-md-8 mx-auto text-center">
                    <h6 class="text-primary">SERIVCES</h6>
                    <h1>Our Services</h1>
                    <p>Lorem ipsum dolor sit amet consectetur nisi necessitatibus repellat distinctio eveniet eaque fuga
                        in cumque optio consectetur harum vitae debitis sapiente praesentium aperiam aut</p>
                </div>
            </div>
            <div class="row g-4">
                <div class="col-lg-4 col-sm-6">
                    <div class="service card-effect bounceInUp">
                        <div class="iconbox">
                            <i class='bx bxs-check-shield'></i>
                        </div>
                        <h5 class="mt-4 mb-2">Service</h5>
                        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Nihil perspiciatis illo asperiores
                            perferendis </p>
                    </div>
                </div>
                <div class="col-lg-4 col-sm-6">
                    <div class="service card-effect">
                        <div class="iconbox">
                            <i class='bx bxs-comment-detail'></i>
                        </div>
                        <h5 class="mt-4 mb-2">Service</h5>
                        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Nihil perspiciatis illo asperiores
                            perferendis </p>
                    </div>
                </div>
                <div class="col-lg-4 col-sm-6">
                    <div class="service card-effect">
                        <div class="iconbox">
                            <i class='bx bxs-cog'></i>
                        </div>
                        <h5 class="mt-4 mb-2">Service</h5>
                        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Nihil perspiciatis illo asperiores
                            perferendis </p>
                    </div>
                </div>
                <div class="col-lg-4 col-sm-6">
                    <div class="service card-effect">
                        <div class="iconbox">
                            <i class='bx bxs-heart'></i>
                        </div>
                        <h5 class="mt-4 mb-2">Service</h5>
                        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Nihil perspiciatis illo asperiores
                            perferendis </p>
                    </div>
                </div>
                <div class="col-lg-4 col-sm-6">
                    <div class="service card-effect">
                        <div class="iconbox">
                            <i class='bx bxs-rocket'></i>
                        </div>
                        <h5 class="mt-4 mb-2">Service</h5>
                        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Nihil perspiciatis illo asperiores
                            perferendis </p>
                    </div>
                </div>
                <div class="col-lg-4 col-sm-6">
                    <div class="service card-effect">
                        <div class="iconbox">
                            <i class='bx bxs-doughnut-chart'></i>
                        </div>
                        <h5 class="mt-4 mb-2">Service</h5>
                        <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Nihil perspiciatis illo asperiores
                            perferendis </p>
                    </div>
                </div>
            </div>
        </div>
    </section><!-- SERVICES -->

    <!-- TEAM -->
    <section id="team">
        <div class="container">
            <div class="row mb-5">
                <div class="col-md-8 mx-auto text-center">
                    <h6 class="text-primary">TEAM</h6>
                    <h1>Meet Our Crew Members</h1>
                    <p>Lorem ipsum dolor sit amet consectetur nisi necessitatibus repellat distinctio eveniet eaque fuga
                        in cumque optio consectetur harum vitae debitis sapiente praesentium aperiam aut</p>
                </div>
            </div>
            <div class="row text-center g-4">
                <div class="col-lg-4 col-sm-6">
                    <div class="team-member card-effect">
                        <img src="img/team1.jpg" alt="">
                        <h5 class="mb-0 mt-4">Agustinus Zefanya</h5>
                        <p>Ilmu Komputer 58 <br/> IPB University</p>
                    </div>
                </div>
                <div class="col-lg-4 col-sm-6">
                    <div class="team-member card-effect">
                        <img src="img/team2.jpg" alt="">
                        <h5 class="mb-0 mt-4">Ifdhaul Fitri</h5>
                        <p>Ilmu Komputer 58 <br/> IPB University</p>
                    </div>
                </div>
                <div class="col-lg-4 col-sm-6">
                    <div class="team-member card-effect">
                        <img src="img/team4.jpg" alt="">
                        <h5 class="mb-0 mt-4">Muhammad Ilham Hakim Suherman</h5>
                        <p>Ilmu Komputer 58 <br/> IPB University</p>
                    </div>
                </div>
            </div>
        </div>
    </section><!-- TEAM -->

    <!-- CONTACT -->
    <section id="contact">
        <div class="container">
            <div class="row mb-5">
                <div class="col-md-8 mx-auto text-center">
                    <h6 class="text-primary">KONTAK</h6>
                    <h1>LAPORKAN</h1>
                    <p>Jika terjadi kendala ataupun masalah yang terjadi pada sistem, tutor, ataupun member, Anda dapat mengirimkan pesan pada box di bawah ini.</p>
                </div>
            </div>

            <form action="" class="row g-3 justify-content-center">
                <div class="col-md-5">
                    <input type="text" class="form-control" placeholder="Masukkan Nama Panjang Anda">
                </div>
                <div class="col-md-5">
                    <input type="text" class="form-control" placeholder="Masukkan E-mail">
                </div>
                <div class="col-md-10">
                    <input type="text" class="form-control" placeholder="Masukkan Subjek">
                </div>
                <div class="col-md-10">
                    <textarea name="" id="" cols="30" rows="5" class="form-control"
                        placeholder="Masukkan Pesan"></textarea>
                </div>
                <div class="col-md-10 d-grid">
                    <button class="btn btn-primary">KIRIM</button>
                </div>
            </form>

        </div>
    </section>
</asp:Content>

