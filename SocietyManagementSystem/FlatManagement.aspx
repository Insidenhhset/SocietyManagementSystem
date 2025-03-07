<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="FlatManagement.aspx.cs" Inherits="SocietyManagementSystem.FlatManagement" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
                  <h1>Flats Management</h1>

  <nav aria-label="breadcrumb">
  <ol class="breadcrumb pl-0 bg-transparent">
    <li class="breadcrumb-item"><a href="Admin.aspx">Dashboard</a></li>
    <li class="breadcrumb-item active" aria-current="page">Flats Management</li>
  </ol>
</nav>
        <div class="card">
            <div class="card-header d-flex justify-content-between align-items-center  text-white">
                <h4 class="mb-0">Flats Management</h4>
                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" Text="Add" OnClick="btnAdd_Click" />
            </div>
            <div class="card-body">
                <div class="row mb-3">
                    <div class="col-md-6">
                        <label>Show Entries:</label>
                       

                        <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="form-select w-auto" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                            <asp:ListItem Text="All" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="5" Value="5"  Selected="True"></asp:ListItem>
                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="20" Value="20"></asp:ListItem>
                        </asp:DropDownList>

                    </div>
                    <div class="col-md-6 text-end">
                        <label>Search:</label>
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control d-inline w-50" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged"></asp:TextBox>
                    </div>
                </div>

                <asp:GridView ID="gvFlats" runat="server" CssClass="table table-bordered table-hover"
                    AutoGenerateColumns="False" AllowPaging="True" PageSize="10"
                    DataKeyNames="Flat_Id" OnRowEditing="gvFlats_RowEditing" OnRowDeleting="gvFlats_RowDeleting" 
                    OnPageIndexChanging="gvFlats_PageIndexChanging">
                    
                    <Columns>
                        <asp:BoundField DataField="Flat_Id" HeaderText="ID" />
                        <asp:BoundField DataField="Flat_No" HeaderText="Flat Number" />
                        <asp:BoundField DataField="Floor_No" HeaderText="Floor Number" />
                        <asp:BoundField DataField="Block_No" HeaderText="Block Number" />
                        <asp:BoundField DataField="Flat_type" HeaderText="Type" />
                        <asp:BoundField DataField="Created_At" HeaderText="Created At" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                        
                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-primary btn-sm"
                                    CommandName="Edit" Text="Edit"></asp:LinkButton>
                                <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger btn-sm"
                                    CommandName="Delete" Text="Delete" OnClientClick="return confirm('Are you sure you want to delete this flat?');"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                    <PagerStyle CssClass="pagination-ys" />
                </asp:GridView>

                <div class="d-flex justify-content-between mt-3">
                    <asp:Label ID="lblEntries" runat="server" CssClass="text-muted"></asp:Label>
                    <asp:Label ID="lblTotalEntries" runat="server" CssClass="text-muted"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>