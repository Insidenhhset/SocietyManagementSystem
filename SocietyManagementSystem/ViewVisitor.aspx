<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ViewVisitor.aspx.cs" Inherits="SocietyManagementSystem.ViewVisitor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="text-center my-4">View Visitor</h2>

<div class="container">
    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Flat Number:</label>
        <div class="col-sm-9">
            <asp:Label ID="Label1" runat="server" Text="Label" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Visitor Name:</label>
        <div class="col-sm-9">
            <asp:Label ID="Label2" runat="server" Text="Label" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Phone:</label>
        <div class="col-sm-9">
            <asp:Label ID="Label3" runat="server" Text="Label" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Address:</label>
        <div class="col-sm-9">
            <asp:Label ID="Label4" runat="server" Text="Label" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Person To Meet:</label>
        <div class="col-sm-9">
            <asp:Label ID="Label5" runat="server" Text="Label" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Reason To Meet:</label>
        <div class="col-sm-9">
            <asp:Label ID="Label6" runat="server" Text="Label" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">In Data & Time:</label>
        <div class="col-sm-9">
            <asp:Label ID="Label7" runat="server" Text="Label" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Status:</label>
        <div class="col-sm-9">
            <asp:Label ID="Label8" runat="server" Text="Label" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Out Data & Time:</label>
        <div class="col-sm-9">
            <asp:TextBox ID="TextBox1" runat="server" TextMode="DateTimeLocal" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Out Remark:</label>
        <div class="col-sm-9">
            <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
        </div>
    </div>
    <asp:Button runat="server" Text="Update" CssClass="btn btn-primary" OnClick="Unnamed_Click" />
</div>


</asp:Content>
