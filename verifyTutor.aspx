<%@ Page Title="" Language="C#" MasterPageFile="~/swift.Master" AutoEventWireup="true" CodeBehind="verifyTutor.aspx.cs" Inherits="SWIFT.verifyTutor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
      $(document).ready(function () {
          $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
      });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center><h1>Unverified Tutor List</h1></center>
    
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:swiftDB %>" SelectCommand="SELECT [tutor_NIM], [tutor_name], [tutor_email], [tutor_angkatan], [tutor_telepon], [tutor_fotoKTM], [tutor_verif], [tutor_gender], [tutor_departemen] FROM [tutor_master_table] WHERE ([tutor_verif] = @tutor_verif)" OnUpdating="onUpdate" OnDeleting="onDelete" DeleteCommand="Delete from tutor_master_table where tutor_nim = @nim" UpdateCommand="UPDATE tutor_master_table set tutor_verif = 1 where tutor_nim = @nim">
        <DeleteParameters>
            <asp:Parameter Name="nim" />
        </DeleteParameters>
        <SelectParameters>
            <asp:Parameter DefaultValue = false Name="tutor_verif" Type="Boolean" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="nim" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:GridView Cssclass="table table-striped table-bordered" runat="server" ID="tutorVerifGrid" AutoGenerateColumns="False" BorderStyle="Double" DataKeyNames="tutor_NIM" DataSourceID="SqlDataSource1" OnRowDataBound="verifTutorBound" OnRowCommand="verif_Command" AllowPaging="True" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="tutor_name" HeaderText="tutor_name" SortExpression="tutor_name"/>
            <asp:BoundField DataField="tutor_NIM" HeaderText="tutor_NIM" ReadOnly="True" SortExpression="tutor_NIM" />
            <asp:BoundField DataField="tutor_email" HeaderText="tutor_email" SortExpression="tutor_email" />
            <asp:BoundField DataField="tutor_departemen" HeaderText="tutor_departemen" SortExpression="tutor_departemen" />
            <asp:BoundField DataField="tutor_gender" HeaderText="tutor_gender" SortExpression="tutor_gender" />
            <asp:BoundField DataField="tutor_angkatan" HeaderText="tutor_angkatan" SortExpression="tutor_angkatan" />
            <asp:BoundField DataField="tutor_telepon" HeaderText="tutor_telepon" SortExpression="tutor_telepon" />
            <asp:TemplateField HeaderText="KTM" ItemStyle-HorizontalAlign="Center">
                  <ItemTemplate>
                      <div class="container-fluid"><asp:Image CssClass="img-fluid" ID="KTMimg" runat="server" /></div>
                  </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <div class="container-fluid">
                        <asp:Button ID="deleteButton" runat="server" Text="Approve" CommandName="approve" BorderColor="LightGreen" ForeColor="white" BackColor="DarkSeaGreen" CommandArgument='<%# Eval("tutor_NIM") %>' />
                        <asp:Button ID="approveButton" runat="server" Text="Delete" CommandName="delete" BorderColor="PaleVioletRed" ForeColor="white" BackColor="DarkRed" CommandArgument='<%# Eval("tutor_NIM") %>' />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
