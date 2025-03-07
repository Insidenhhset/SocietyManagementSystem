
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddFlat.aspx.cs" Inherits="SocietyManagementSystem.AddFlat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1>Flats Management</h1>

        <nav aria-label="breadcrumb">
            <ol class="breadcrumb pl-0 bg-transparent">
                <li class="breadcrumb-item"><a href="Admin.aspx">Dashboard</a></li>
                <li class="breadcrumb-item"><a href="FlatManagement.aspx">Flats Management</a></li>
                <li class="breadcrumb-item active" aria-current="page">Add Flat</li>
            </ol>
        </nav>

        <div class="card w-50">
            <div class="card-header bg-primary text-white">
                <h4 class="mb-0">Add New Flat</h4>
            </div>
            <div class="card-body">
                <div class="mb-3">
                    <label class="form-label">Flat Number</label>
                    <asp:TextBox ID="txtFlatNo" runat="server" CssClass="form-control" required></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Floor Number</label>
                    <asp:TextBox ID="txtFloorNo" runat="server" CssClass="form-control" required></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Block Number</label>
                    <asp:TextBox ID="txtBlockNo" runat="server" CssClass="form-control" required></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Flat Type</label>
                    <asp:DropDownList ID="ddlFlatType" runat="server" CssClass="form-select">
                    </asp:DropDownList>
                </div>
                <div class="text-end">
                    <asp:Button ID="btnAddFlat" runat="server" CssClass="btn btn-success" Text="Add Flat" OnClick="btnAddFlat_Click" />
                    <a href="FlatManagement.aspx" class="btn btn-secondary">Cancel</a>
                </div>
                <asp:Label ID="lblError" runat="server" CssClass="text-danger mt-3" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>