<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="UserVisitorList.aspx.cs" Inherits="SocietyManagementSystem.UserVisitorList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mt-2 mb-3 text-center">Visitor Management</h2>

<div class="m-5">
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="Visitor_Id" AutoGenerateColumns="False" CssClass="table table-striped table-bordered " OnRowCommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="Visitor Id" DataField="Visitor_Id"  />
            <asp:BoundField HeaderText="Flat Number" DataField="Flat_No"  />
            <asp:BoundField HeaderText="Visitor Name" DataField="Name" />
            <asp:BoundField HeaderText="Phone" DataField="Phone"  />
            <asp:BoundField HeaderText="Person To Meet" DataField="Person_to_meet" />
            <asp:BoundField HeaderText="In Time" DataField="In_datetime" />
            <asp:BoundField HeaderText="Out Time" DataField="Out_datetime" />
            <asp:BoundField HeaderText="Status" DataField="Is_in_out" />

            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                   <asp:Button ID="btnView" runat="server" Text="View"
    CommandName="View" CommandArgument='<%# Container.DataItemIndex %>'
    CssClass="btn btn-primary" />
        </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>

</asp:Content>
