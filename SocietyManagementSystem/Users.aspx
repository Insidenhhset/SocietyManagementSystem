<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="SocietyManagementSystem.Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" />
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-4">
        <h1 class="text-2xl font-weight-bold custom-heading">User Management</h1>

        <!-- Breadcrumb -->
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb pl-0 bg-transparent">
                <li class="breadcrumb-item"><a href="Admin.aspx">Dashboard</a></li>
                <li class="breadcrumb-item active" aria-current="page">User Management</li>
            </ol>
        </nav>
        <div class="d-flex justify-content-between align-items-center border border-2  rounded-md">


            <h4 class="m-2">User Management</h4>
            <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success m-2" OnClick="btnAdd_Click" Text="Add" />
        </div>

        <div class="card">
            <div class="card-body">
                <div class="d-flex justify-content-between align-items-center mb-3">
                    <div>
                        Show entries
                        <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="form-select d-inline w-auto" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                          
                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                            <asp:ListItem Text="10" Value="10" ></asp:ListItem>
                            <asp:ListItem Text="25" Value="25" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="50" Value="50"></asp:ListItem>
                        </asp:DropDownList>
                        
                    </div>
                    <div>
                        Search:
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control d-inline w-auto" AutoPostBack="true" OnTextChanged="txtSearch_TextChanged" />
                    </div>
                </div>

                <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover"
                    AutoGenerateColumns="False" AllowPaging="true" PageSize="5"
                   OnRowCommand="GridView1_RowCommand" OnRowDeleting="gvUsers_RowDeleting"
                    OnPageIndexChanging="gvUsers_PageIndexChanging" DataKeyNames="ID">

                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="Name" HeaderText="Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Role" HeaderText="Role" />
                        <asp:BoundField DataField="CreatedAt" HeaderText="Created At" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />

                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <%-- <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-primary btn-sm" 
                                    CommandName="Edit" CommandArgument='<%# Eval("ID") %>' OnClick="btnEdit_Click" Text="Edit" />--%>
                              <asp:LinkButton 
                    ID="btnEdit" 
                         CssClass="btn btn-primary btn-sm"
                    runat="server" 
                    Text="Edit" 
                    CommandName="EditUser" 
                    CommandArgument='<%# Eval("ID") %>'>
                </asp:LinkButton>


                                <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-danger btn-sm"
                                    CommandName="Delete" CommandArgument='<%# Eval("ID") %>' Text="Delete"
                                    OnClientClick="return confirm('Are you sure you want to delete this user?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                       
                    <PagerStyle CssClass=" justify-content-center mt-3" />
                </asp:GridView>

                <div class="d-flex justify-content-between mt-3">
    <asp:Label ID="lblEntries" runat="server" CssClass="text-muted"></asp:Label>
    <asp:Label ID="lblTotalEntries" runat="server" CssClass="text-muted"></asp:Label>
</div>
            </div>
        </div>
    </div>
</asp:Content>
