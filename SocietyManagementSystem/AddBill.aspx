<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddBill.aspx.cs" Inherits="SocietyManagementSystem.AddBill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center mt-5">Add Bill</h2>

  <div class="m-auto" style="width: 50%">
      <div class="form-group">
          <label for="TextBox1">Bill Title:</label>
          <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Enter bill title"></asp:TextBox>
      </div>

      <div class="form-group">
          <label for="DropDownList1">Flat Number:</label>
          <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="Page_Load">
          </asp:DropDownList>
      </div>

      <div class="form-group">
          <label for="TextBox2">Amount:</label>
          <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Enter amount"></asp:TextBox>
      </div>

      <div class="form-group">
          <label for="TextBox3">Month:</label>
          <asp:TextBox ID="TextBox3" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
      </div>

      <div class="form-group text-center">
          <asp:Button ID="Button1" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="Button1_Click" />
      </div>
  </div>

</asp:Content>
