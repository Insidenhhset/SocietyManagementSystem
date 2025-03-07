<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ViewMyCompleint.aspx.cs" Inherits="SocietyManagementSystem.ViewMyCompleint" %>
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
        <label class="col-sm-3 font-weight-bold"  runat="server" id="master">Master Comment:</label>
        <div class="col-sm-9">
            <asp:Label ID="Label5" runat="server" Text="Label" CssClass="form-control" />
        </div>
    </div>
</div>

</asp:Content>
