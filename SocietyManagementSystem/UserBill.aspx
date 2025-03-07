<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="UserBill.aspx.cs" Inherits="SocietyManagementSystem.UserBill" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-start mt-4">

       

        <div class="container mt-4">
             <h2 class="mt-2 mb-3 ">Bills</h2>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered " OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="Bill ID" DataField="Bill_Id" SortExpression="Bill_Id" />
                    <asp:BoundField HeaderText="Flat ID" DataField="Flat_Id" SortExpression="Flat_Id" />
                    <asp:BoundField HeaderText="Bill Title" DataField="Bill_title" SortExpression="Bill_title" />
                    <asp:BoundField HeaderText="Amount" DataField="Amount" SortExpression="Amount" />
                    <asp:BoundField HeaderText="Month" DataField="Month" SortExpression="Month" />
                    <asp:TemplateField HeaderText="Paid Amount" SortExpression="Paid_amount">
                        <ItemTemplate>
                            <%# string.IsNullOrEmpty(Eval("Paid_amount").ToString()) ? "Pending" : "Paid" %>
                        </ItemTemplate>

                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="ViewBtn" runat="server" CssClass="btn btn-warning text-light" Text="View" CommandName="View" CommandArgument='<%# Eval("Bill_Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Download Bill">
                        <ItemTemplate>
                            <asp:Button ID="downloadBtn" runat="server" CssClass="btn btn-primary text-light" Text="Download" CommandName="Download" OnClick="downloadBtn_Click" CommandArgument='<%# Eval("Bill_Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
