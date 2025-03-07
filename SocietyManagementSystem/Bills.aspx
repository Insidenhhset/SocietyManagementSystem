<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Bills.aspx.cs" Inherits="SocietyManagementSystem.Bills" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h2 class="mt-4 mb-3 ">Bills</h2>

       <nav aria-label="breadcrumb">
  <ol class="breadcrumb pl-0 bg-transparent">
    <li class="breadcrumb-item"><a href="Admin.aspx">Dashboard</a></li>
    <li class="breadcrumb-item active" aria-current="page">Bills Management</li>
  </ol>
</nav>
   <asp:Label ID="Label1" runat="server" Style="font-size: 18px; font-weight: 600;" Text="Bills Management"></asp:Label>

 <asp:HyperLink ID="HyperLink1" runat="server" CssClass="btn btn-success text-light float-right mt-2 mr-2 mb-3" NavigateUrl="~/AddBill.aspx">Add</asp:HyperLink>
 <asp:GridView ID="GridView1" runat="server" DataKeyNames="Bill_Id" AutoGenerateColumns="False" CssClass="table table-striped table-bordered " OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
     <Columns>
         <asp:BoundField HeaderText="Bill Id" DataField="Bill_Id" SortExpression="Bill_Id" ReadOnly="True" />
         <asp:BoundField HeaderText="Flat Id" DataField="Flat_Id" SortExpression="Flat_Id" />
         <asp:TemplateField HeaderText="Bill Title">
             <ItemTemplate>
                 <asp:Label ID="lblBillTitle" runat="server" Text='<%# Eval("Bill_title") %>'></asp:Label>
             </ItemTemplate>
             <EditItemTemplate>
                 <asp:TextBox ID="txtBillTitle" runat="server" Text='<%# Eval("Bill_title") %>'></asp:TextBox>
             </EditItemTemplate>
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Amount">
             <ItemTemplate>
                 <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
             </ItemTemplate>
             <EditItemTemplate>
                 <asp:TextBox ID="txtAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:TextBox>
             </EditItemTemplate>
         </asp:TemplateField>
         <asp:TemplateField HeaderText="Month">
             <ItemTemplate>
                 <asp:Label ID="lblMonth" runat="server" Text='<%# Eval("Month", "{0:yyyy-MM-dd}") %>'></asp:Label>
             </ItemTemplate>
             <EditItemTemplate>
                 <asp:TextBox ID="txtMonth" runat="server" Text='<%# Eval("Month", "{0:yyyy-MM-dd}") %>'></asp:TextBox>
             </EditItemTemplate>
         </asp:TemplateField>
         <asp:BoundField HeaderText="Paid Date" DataField="Paid_date" SortExpression="Paid_date" />
         <asp:BoundField HeaderText="Payment Method" DataField="Payment_method" SortExpression="Payment_method" />
         <asp:BoundField HeaderText="Paid Amount" DataField="Paid_amount" SortExpression="Paid_amount" />
         <asp:BoundField HeaderText="Created At" DataField="Created_At" SortExpression="Created_At" />
    <asp:TemplateField HeaderText="Action">
    <ItemTemplate>
        <div class="d-flex gap-2 ">
            <asp:Button ID="btnView" runat="server" CssClass="btn btn-warning text-light mr-2" Text="View" CommandName="View" CommandArgument='<%# Eval("Bill_Id") %>'></asp:Button>
            <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" CssClass="btn btn-primary mr-2" CommandArgument='<%# Eval("Bill_Id") %>' />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CssClass="btn btn-danger" CommandArgument='<%# Eval("Bill_Id") %>' OnClientClick="return confirm('Are you sure you want to delete this record?');" />
        </div>
    </ItemTemplate>
    <EditItemTemplate>
        <div class="d-flex gap-2">
            <asp:Button ID="btnUpdate" runat="server" Text="Update" CommandName="Update" CssClass="btn btn-success" CommandArgument='<%# Eval("Bill_Id") %>' />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="Cancel" CssClass="btn btn-secondary" />
        </div>
    </EditItemTemplate>
</asp:TemplateField>

     </Columns>
 </asp:GridView>
</asp:Content>
