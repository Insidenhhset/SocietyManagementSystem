<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddVisitor.aspx.cs" Inherits="SocietyManagementSystem.AddVisitor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center my-4">Add Visitor</h2>

<div class="container">
    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Flat Number:</label>
        <div class="col-sm-9">
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Visitor Name:</label>
        <div class="col-sm-9">
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Phone:</label>
        <div class="col-sm-9">
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Address:</label>
        <div class="col-sm-9">
            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Person To Meet:</label>
        <div class="col-sm-9">
            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Reason To Meet:</label>
        <div class="col-sm-9">
            <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">In Data & Time:</label>
        <div class="col-sm-9">
            <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control" TextMode="DateTimeLocal"></asp:TextBox>
        </div>
    </div>
<asp:Button runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btn_Click" />

</asp:Content>
