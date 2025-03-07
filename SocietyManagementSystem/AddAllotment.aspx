<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddAllotment.aspx.cs" Inherits="SocietyManagementSystem.AddAllotment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="card">
            <div class="card-header bg-primary text-white">
                <h4 class="mb-0">Add New Allotment</h4>
            </div>
            <div class="card-body">
                <asp:Label ID="lblError" runat="server" CssClass="text-danger mb-3" Visible="false"></asp:Label>

                <div class="mb-3">
                    <label class="form-label">User</label>
                    <asp:DropDownList ID="ddlUser" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label">Block Number</label>
                    <asp:DropDownList ID="ddlBlock" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlBlock_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label">Flat</label>
                    <asp:DropDownList ID="ddlFlat" runat="server" CssClass="form-select"></asp:DropDownList>
                </div>
                <div class="mb-3">
                    <label class="form-label">Move-in Date</label>
                    <asp:TextBox ID="txtMoveInDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label class="form-label">Move-out Date</label>
                    <asp:TextBox ID="txtMoveOutDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                </div>
                <div class="text-end">
                    <asp:Button ID="btnAddAllotment" runat="server" CssClass="btn btn-success" Text="Add Allotment" OnClick="btnAddAllotment_Click"/>
                    <a href="AllotmentManagement.aspx" class="btn btn-secondary">Cancel</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>