<%@ Page Title="" Language="C#" MasterPageFile="~/swift.Master" AutoEventWireup="true" CodeBehind="createCourse.aspx.cs" Inherits="SWIFT.createCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
      <div class="row">
         <div class="col-md-5">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>Course</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <center>
                           <asp:Image id="Banner" ImageUrl="imgs/books.png" runat="server" CssClass="w-50"/>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:FileUpload class="form-control" ID="BannerUpload" runat="server" />
                     </div>
                  </div>
                   <div class="row">
                     <div class="col-md-10">
                        <label>UID Course (auto generated)</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Course_id" runat="server" placeholder="course ID" ReadOnly="true"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-10">
                        <label>Nama Course</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Judul" runat="server" placeholder="Nama Course"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-8">
                        <label>Mata Kuliah</label>
                        <div class="form-group">
                           <asp:DropDownList class="form-control" ID="Matkul" runat="server">
                              <asp:ListItem Text="Kalkulus" Value="Kalkulus" />
                              <asp:ListItem Text="Biologi" Value="Biologi" />
                              <asp:ListItem Text="Fisika" Value="Fisika" />
                              <asp:ListItem Text="Kimia" Value="Kimia" />
                              <asp:ListItem Text="Ekonomi" Value="Ekonomi" />
                              <asp:ListItem Text="MBL" Value="MBL" />
                              <asp:ListItem Text="Statistika" Value="Statistika" />
                              <asp:ListItem Text="Berpikir Komputasional" Value="Berpikir Komputasional" />
                              <asp:ListItem Text="Bahasa Inggris" Value="Bahasa Inggris" />
                              <asp:ListItem Text="Sosiologi" Value="Sosiologi" />
                           </asp:DropDownList>
                        </div>
                        <label>Jadwal</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Jadwal" runat="server" placeholder="Tanggal Mulai" TextMode="DateTimeLocal"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-8">
                       <label>Kapasitas</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Cap" runat="server" placeholder="Kapasitas" TextMode="Number"></asp:TextBox>
                        </div>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-md-8">
                        <label>Harga Course</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Price" runat="server" placeholder="Harga Couse" TextMode="Number"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-12">
                        <label>Deskripsi</label>
                        <div class="form-group">
                           <asp:TextBox CssClass="form-control" ID="Desk" runat="server" placeholder="Deskripsi Course" TextMode="MultiLine" Rows="2"></asp:TextBox>
                        </div>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col-4">
                        <asp:Button ID="Add" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="Add_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Update" class="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="Update_Click" />
                     </div>
                     <div class="col-4">
                        <asp:Button ID="Delete" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="Delete_Click" />
                     </div>
                  </div>
               </div>
            </div>
            <a href="homepage.aspx"><< Back to Home</a><br>
            <br>
         </div>
         <div class="col-md-7">
            <div class="card">
               <div class="card-body">
                  <div class="row">
                     <div class="col">
                        <center>
                           <h4>List Course</h4>
                        </center>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <hr>
                     </div>
                  </div>
                  <div class="row">
                     <div class="col">
                        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="course_id" DataSourceID="SqlDataSource1" OnRowCommand ="select" AllowPaging="True" AllowSorting="True">
                            <Columns>
                                <asp:BoundField DataField="course_id" HeaderText="course_id" ReadOnly="True" SortExpression="course_id" />
                                <asp:BoundField DataField="matkul" HeaderText="matkul" SortExpression="matkul" />
                                <asp:BoundField DataField="course_name" HeaderText="course_name" SortExpression="course_name" />
                                <asp:BoundField DataField="course_time" HeaderText="course_time" SortExpression="course_time" />
                                <asp:BoundField DataField="course_capacity" HeaderText="course_capacity" SortExpression="course_capacity" />
                                <asp:BoundField DataField="course_price" HeaderText="course_price" SortExpression="course_price" />
                                <asp:BoundField DataField="course_details" HeaderText="course_details" SortExpression="course_details" />
                                <asp:BoundField DataField="tutor_NIM" HeaderText="tutor_NIM" SortExpression="tutor_NIM" />
                                <asp:CheckBoxField DataField="course_verif" HeaderText="course_verif" SortExpression="course_verif" />
                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>
                                        <asp:Button runat="server"  ID="Select" CommandName="Select" CommandArgument='<%# Eval("course_id") %>' Text="Select" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                         </asp:GridView>
                     </div>
                  </div>
                   <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:swiftDB %>" SelectCommand="SELECT * FROM [course_master_table] WHERE ([tutor_NIM] = @tutor_NIM)">
                       <SelectParameters>
                           <asp:SessionParameter Name="tutor_NIM" SessionField="NIM" Type="String" />
                       </SelectParameters>
                   </asp:SqlDataSource>
               </div>
            </div>
         </div>
      </div>
</asp:Content>
