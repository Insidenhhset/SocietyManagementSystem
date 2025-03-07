<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Visitors.aspx.cs" Inherits="SocietyManagementSystem.Visitors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="mt-4 mb-3 ">Visitor Management</h2>
     <nav aria-label="breadcrumb">
    <ol class="breadcrumb pl-0 bg-transparent">
      <li class="breadcrumb-item"><a href="Admin.aspx">Dashboard</a></li>
      <li class="breadcrumb-item active" aria-current="page">Visitor Management</li>
    </ol>
  </nav>
  
<div class=" m-5">

    <asp:Label ID="Label2" runat="server" Style="font-size: 18px;color:black; font-weight: bold;" Text="Visitor Management"></asp:Label>

<asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-success text-light float-right mt-2 mr-5 mb-3" NavigateUrl="~/AddVisitor.aspx">Add</asp:HyperLink>

    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="Visitor_Id"
    OnRowCommand="GridView1_RowCommand"
    OnRowDeleting="GridView1_RowDeleting"
    OnRowEditing="GridView1_RowEditing"
        CssClass="table table-striped table-bordered" >  


    <Columns>
        <asp:BoundField DataField="Visitor_Id" HeaderText="ID" ReadOnly="True" />
        <asp:BoundField DataField="Flat_No" HeaderText="Flat No" />
        <asp:BoundField DataField="Name" HeaderText="Visitor Name" />
        <asp:BoundField DataField="Phone" HeaderText="Phone" />
        <asp:BoundField DataField="Person_to_meet" HeaderText="Person to Meet" />
        <asp:BoundField DataField="In_datetime" HeaderText="In Time" />
        <asp:BoundField DataField="Out_datetime" HeaderText="Out Time" />

      
        <asp:BoundField DataField="Is_in_out" HeaderText="Status"/>
 

     <asp:TemplateField HeaderText="Action">
    <ItemTemplate>


    <asp:Button ID="btnView" runat="server" Text="View" CommandName="View"
        CommandArgument='<%# Eval("Visitor_Id") %>' CssClass="btn btn-primary" />

    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteVisitor"
        CommandArgument='<%# Eval("Visitor_Id") %>' CssClass="btn btn-danger" />
</ItemTemplate>
<ItemStyle CssClass="text-center" />

</asp:TemplateField>

    </Columns>
</asp:GridView>
</div>
</asp:Content>
