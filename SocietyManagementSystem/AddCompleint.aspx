<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="AddCompleint.aspx.cs" Inherits="SocietyManagementSystem.AddCompleint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2 class="text-center mt-5">Add Complaint</h2>

<div class="m-auto" style="width: 50%">
    <div class="form-group">
        <label for="TextBox1">Description:</label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter bill title" TextMode="MultiLine"></asp:TextBox>
    </div>


    <div class="form-group">
        <asp:Button ID="Button1" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="Button1_Click" />
    </div>
</div>

</asp:Content>
