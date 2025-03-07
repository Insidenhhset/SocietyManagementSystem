<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="BillPayment.aspx.cs" Inherits="SocietyManagementSystem.BillPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2 class="text-center my-4">Bill Payment Status</h2>

<div class="container">
    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Flat Number:</label>
        <div class="col-sm-9">
            <asp:Label ID="Label1" runat="server" Text="Label" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Bill Details:</label>
        <div class="col-sm-9">
            <asp:Label ID="Label2" runat="server" Text="Label" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Bill Months:</label>
        <div class="col-sm-9">
            <asp:Label ID="Label3" runat="server" Text="Label" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Bill Amount:</label>
        <div class="col-sm-9">
            <asp:Label ID="Label4" runat="server" Text="Label" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Payment Date:</label>
        <div class="col-sm-9">
            <asp:TextBox ID="TextBox1" runat="server"  TextMode="Date" CssClass="form-control" />
        </div>
    </div>

    <div class="row mb-3" >
        <label class="col-sm-3 font-weight-bold">Paid Bill Amount:</label>
        <div class="col-sm-9">
            <asp:TextBox ID="TextBox2" runat="server"  CssClass="form-control" />
        </div>
    </div>


    <div class="row mb-3">
        <label class="col-sm-3 font-weight-bold">Payment Method:</label>
        <div class="col-sm-9" >

            <asp:DropDownList ID="DropDownList1"  runat="server"  CssClass="form-control">
                <asp:ListItem >Cash</asp:ListItem>
                <asp:ListItem>UPI</asp:ListItem>
            </asp:DropDownList>

        </div>
    </div>
    <asp:Button ID="Button1" runat="server"  Text="Payment" CssClass="btn btn-primary" OnClick="Button1_Click"  />
    
</div>
 
</asp:Content>
