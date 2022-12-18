<%@ Page Title="" Language="C#" MasterPageFile="~/swift.Master" AutoEventWireup="true" CodeBehind="CoursePage.aspx.cs" Inherits="SWIFT.CoursePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:swiftDB %>" SelectCommand="SELECT [course_id], [matkul], [course_name], [course_time], [course_capacity], [course_price], [course_details], [course_pic], [tutor_NIM] FROM [course_master_table] WHERE ([course_verif] = @course_verif)">
        <SelectParameters>
            <asp:Parameter DefaultValue=true Name="course_verif" Type="Boolean" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="course_id" OnRowDataBound="course_bounds" OnRowCommand="course_comm">
        <Columns>
            <asp:BoundField DataField="course_id" HeaderText="course_id" ReadOnly="True" SortExpression="course_id" />
            <asp:BoundField DataField="matkul" HeaderText="matkul" SortExpression="matkul" />
            <asp:BoundField DataField="course_name" HeaderText="course_name" SortExpression="course_name" />
            <asp:BoundField DataField="course_time" HeaderText="course_time" SortExpression="course_time" />
            <asp:BoundField DataField="course_capacity" HeaderText="course_capacity" SortExpression="course_capacity" />
            <asp:BoundField DataField="course_price" HeaderText="course_price" SortExpression="course_price" />
            <asp:BoundField DataField="course_details" HeaderText="course_details" SortExpression="course_details" />
            <asp:TemplateField>
                <ItemTemplate>
                    <div class="container-fluid"><asp:Image CssClass="img-fluid" ID="Banner" runat="server" /></div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <div class="container-fluid">
                        <asp:Button ID="viewTutor" runat="server" Text="ViewTutor" CommandName="viewTutor" BorderColor="LightGreen" ForeColor="white" BackColor="DarkSeaGreen" CommandArgument='<%# Eval("tutor_NIM") %>' />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
