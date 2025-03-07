<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ComplientView.aspx.cs" Inherits="SocietyManagementSystem.ComplientView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center my-4">View Complaint</h2>

<div class="container">
    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Username:</label>
        <div class="col-sm-9">
            <asp:Label ID="Label1" runat="server" Text="Label" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Flat Number:</label>
        <div class="col-sm-9">
            <asp:Label ID="Label2" runat="server" Text="Label" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Description:</label>
        <div class="col-sm-9">
            <asp:Label ID="Label3" runat="server" Text="Label" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Status:</label>
        <div class="col-sm-9">
            <asp:Label ID="Label4" runat="server" Text="Label" CssClass="form-control" />
        </div>
    </div>

   <div class="row mb-3">
    <label class="col-sm-3 font-weight-bold">Master Comment:</label>
    <div class="col-sm-9">
        <asp:Label ID="Label5" runat="server" Text="Label" CssClass="form-control mb-1"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
</div>
  

 <div class="row mb-3" id="statusDiv" runat="server">
        <label class="col-sm-3 font-weight-bold" >Status:</label>
        <div class="col-sm-9">
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                <asp:ListItem>In Progress</asp:ListItem>
                <asp:ListItem>Resolved</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="Button1_Click" />
</div>



</asp:Content>
