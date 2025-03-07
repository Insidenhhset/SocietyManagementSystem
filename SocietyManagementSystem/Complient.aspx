<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Complient.aspx.cs" Inherits="SocietyManagementSystem.Complient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-4 mb-3 ">Complaint Management</h2>

     <nav aria-label="breadcrumb">
    <ol class="breadcrumb pl-0 bg-transparent">
      <li class="breadcrumb-item"><a href="Admin.aspx">Dashboard</a></li>
      <li class="breadcrumb-item active" aria-current="page">Complaint Management</li>
    </ol>
  </nav>

<div class="m-5">

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting">
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
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CssClass="btn btn-danger" CommandArgument='<%# Eval("Complaint_Id") %>' OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>

</asp:Content>
