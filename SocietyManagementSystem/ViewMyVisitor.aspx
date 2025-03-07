<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ViewMyVisitor.aspx.cs" Inherits="SocietyManagementSystem.ViewMyVisitor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center my-4">View Visitor Detail</h2>

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
            <label class="col-sm-3 font-weight-bold">Out Remark:</label>
            <div class="col-sm-9">
                <asp:Label ID="Label8" runat="server" Text="Label" CssClass="form-control" />
            </div>
        </div>

        <div class="row mb-3">
            <label class="col-sm-3 font-weight-bold">Out Data & Time:</label>
            <div class="col-sm-9">
                <asp:Label ID="Label9" runat="server" Text="Label" CssClass="form-control" />
            </div>
        </div>

        <div class="row mb-3">
            <label class="col-sm-3 font-weight-bold">Status:</label>
            <div class="col-sm-9">
                <asp:Label ID="Label10" runat="server" Text="Label" CssClass="form-control" />
            </div>
        </div>
</div>
</asp:Content>
