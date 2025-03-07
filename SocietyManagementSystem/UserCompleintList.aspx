<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="UserCompleintList.aspx.cs" Inherits="SocietyManagementSystem.UserCompleintList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="mt-2 mb-3 text-center">Complient Management</h2>
<asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-success text-light float-right mt-2 mr-5 mb-3" NavigateUrl="~/AddCompleint.aspx">Add</asp:HyperLink>

<div class="m-5">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Complaint_Id" />
            <asp:BoundField HeaderText="Username" DataField="Username" />
            <asp:BoundField HeaderText="Flat Number" DataField="Flat_No" />
            <asp:BoundField HeaderText="Description" DataField="Description" />
            <asp:BoundField HeaderText="Status" DataField="Status" />
            <asp:BoundField HeaderText="Created At" DataField="Created_At" />

            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="btnView" runat="server" CssClass="btn btn-warning text-light" Text="View" CommandName="View" CommandArgument='<%# Eval("Complaint_Id") %>'></asp:Button>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>

</asp:Content>
