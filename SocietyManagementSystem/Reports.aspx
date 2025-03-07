<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="SocietyManagementSystem.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-4">
        <h1 class="text-2xl font-weight-bold custom-heading">Bill Report</h1>

        <!-- Breadcrumb -->
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb pl-0 bg-transparent">
                <li class="breadcrumb-item"><a href="Admin.aspx">Dashboard</a></li>
                <li class="breadcrumb-item active" aria-current="page">Reports</li>
            </ol>
        </nav>

        <div class="border border-2 rounded-3">
            <div class="d-flex justify-content-between align-items-center p-2 ml-2">
                <h4 class="m-0">Report</h4>
            </div>

            <div class="card ">
                <div class="card-body">
                    <div class="row g-3">
                        <div class="col-md-3">
                            <label for="DropDownList1" class="form-label">Report For</label>
                            <asp:DropDownList ID="DropDownList1" AutoPostBack="true" runat="server" CssClass="form-select">
                                <asp:ListItem>Bill</asp:ListItem>
                                <asp:ListItem>Complaint</asp:ListItem>
                                <asp:ListItem>Visitor</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="col-md-3">
                            <label for="TextBox1" class="form-label">Start Date</label>
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="col-md-3">
                            <label for="TextBox2" class="form-label">End Date</label>
                            <asp:TextBox ID="TextBox2" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        </div>

                        <div class="col-md-3 d-flex align-items-end">
                            <asp:Button ID="Button1" runat="server" Text="Generate Report" OnClick="Button1_Click" CssClass="btn btn-primary w-75" />
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <div id="billData" runat="server">

            <div class="d-flex justify-content-between align-items-center border border-2  rounded-3">

                <h4 class="m-2" id="reporttitle" runat="server"></h4>
                <asp:Button ID="btnExport" runat="server" CssClass="btn btn-success m-2" OnClick="btnExport_Click" Text="Export" Visible="false" />

            </div>

            <asp:GridView ID="GridView1" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="BillTitle" HeaderText="Bill Title" />
                    <asp:BoundField DataField="FlatNo" HeaderText="Flat No" />
                    <asp:BoundField DataField="BillAmount" HeaderText="Bill Amount"  />
                    <asp:BoundField DataField="BillMonth" HeaderText="Bill Month" />
            <asp:BoundField DataField="PaidDate" HeaderText="Paid Date"
    DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />



                          <asp:BoundField DataField="PaymentMethod" HeaderText="Payment Method" />
                    <asp:BoundField DataField="PaidAmount" HeaderText="Paid Amount"  />
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <span class="badge bg-primary text-white text-sm px-3 py-2 rounded">
                                <%# Eval("status") %>
                            </span>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

        </div>

        <div id="complaintData" runat="server">

            <div class="d-flex justify-content-between align-items-center border border-2  rounded-3">

                <h4 class="m-2" id="complainttitle" runat="server"></h4>
                <asp:Button ID="Button2" runat="server" CssClass="btn btn-success m-2" OnClick="Button2_Click" Text="Export" Visible="false" />

            </div>

            <asp:GridView ID="GridView2" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="UserName" HeaderText="User Name" />
                    <asp:BoundField DataField="FlatNo" HeaderText="Flat No" />
                    <asp:BoundField DataField="ComplaintMessage" HeaderText="Complaint Message" DataFormatString="{0:C}" />
                 
                         <asp:TemplateField HeaderText="Status">
         <ItemTemplate>
             <span class="badge bg-primary text-white text-sm px-3 py-2 rounded">
                 <%# Eval("ComplaintStatus") %>
             </span>
         </ItemTemplate>
         <ItemStyle HorizontalAlign="Center" />
     </asp:TemplateField>
                     <asp:BoundField DataField="ComplaintCreatedAt" HeaderText="Updated At" DataFormatString="{0:yyyy-MM-dd}" />
                    </Columns>
            </asp:GridView>

        </div>

        <div id="VisitorData" runat="server">

            <div class="d-flex justify-content-between align-items-center border border-2  rounded-3">

                <h4 class="m-2" id="visitortitle" runat="server"></h4>
                <asp:Button ID="Button3" runat="server" CssClass="btn btn-success m-2" OnClick="Button3_Click" Text="Export" Visible="false" />

            </div>

            <asp:GridView ID="GridView3" CssClass="table table-bordered table-hover" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="FlatNo" HeaderText="Flat No" />
                    <asp:BoundField DataField="VisitorName" HeaderText="Visitor Name" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="PersonToMeet" HeaderText="Person To Meet" />
                    <asp:BoundField DataField="Reason" HeaderText="Reason" />
                    <asp:BoundField DataField="InDate" HeaderText="In Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="OutRemark" HeaderText="Out Remark" />
                    <asp:BoundField DataField="OutDate" HeaderText="Out Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <span class="badge bg-primary text-white text-sm px-3 py-2 rounded">
                                <%# Eval("VisitorStatus") %>
                            </span>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

        </div>
</asp:Content>
