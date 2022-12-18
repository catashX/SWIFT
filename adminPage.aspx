<%@ Page Title="" Language="C#" MasterPageFile="~/swift.Master" AutoEventWireup="true" CodeBehind="adminPage.aspx.cs" Inherits="SWIFT.adminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
      $(document).ready(function () {
          $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
      });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Please verify this course </h1>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:swiftDB %>" SelectCommand="SELECT [course_id], [matkul], [course_name], [course_time], [course_capacity], [course_price], [course_details], [course_pic], [tutor_NIM], [course_verif] FROM [course_master_table] WHERE ([course_verif] = @course_verif)" OnDeleting="onDelete" OnUpdating="onUpdate" DeleteCommand="delete from course_master_table where course_id = @courseID" UpdateCommand="Update course_master_table set course_verif = 1 where course_id = @courseID">
            <DeleteParameters>
                <asp:Parameter Name="courseID" />
            </DeleteParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue=false Name="course_verif" Type="Boolean" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter DefaultValue="0" Name="courseID" />
            </UpdateParameters>
        </asp:SqlDataSource>
    <asp:GridView Cssclass="table table-striped table-bordered" runat="server" AutoGenerateColumns="False" DataKeyNames="course_id" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" OnRowCommand="course_verif" OnRowDataBound="course_bound" ID="course_verif_grid">
        <Columns>
            <asp:BoundField DataField="course_id" HeaderText="course_id" ReadOnly="True" SortExpression="course_id" />
            <asp:BoundField DataField="matkul" HeaderText="matkul" SortExpression="matkul" />
            <asp:BoundField DataField="course_name" HeaderText="course_name" SortExpression="course_name" />
            <asp:BoundField DataField="course_time" HeaderText="course_time" SortExpression="course_time" />
            <asp:BoundField DataField="course_capacity" HeaderText="course_capacity" SortExpression="course_capacity" />
            <asp:BoundField DataField="course_price" HeaderText="course_price" SortExpression="course_price" />
            <asp:BoundField DataField="course_details" HeaderText="course_details" SortExpression="course_details" />
            <asp:BoundField DataField="tutor_NIM" HeaderText="tutor_NIM" SortExpression="tutor_NIM" />
            <asp:TemplateField HeaderText="Image" ItemStyle-HorizontalAlign="Center">
                  <ItemTemplate>
                      <div class="container-fluid"><asp:Image CssClass="img-fluid" ID="Banner" runat="server" /></div>
                  </ItemTemplate>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <div class="container-fluid">
                        <asp:Button ID="deleteButton" runat="server" Text="Approve" CommandName="approve" BorderColor="LightGreen" ForeColor="white" BackColor="DarkSeaGreen" CommandArgument='<%# Eval("course_id") %>' />
                        <asp:Button ID="approveButton" runat="server" Text="Delete" CommandName="delete" BorderColor="PaleVioletRed" ForeColor="white" BackColor="DarkRed" CommandArgument='<%# Eval("course_id") %>' />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
