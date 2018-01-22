<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="RetrievalDetailPage.aspx.cs" Inherits="Team10AD_Web.Clerk.RetrievalDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Retrieval Details</h2>
    <asp:Label ID="RetID" runat="server" Text="Retrieval ID:"></asp:Label>
    <asp:TextBox ID="RetIDTextBox" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:Label ID="RetStatus" runat="server" Text="Status:"></asp:Label>
    <asp:TextBox ID="StatusTextBox" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:GridView ID="dgvRetrievalDetail" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="BalanceQuantity" HeaderText="Current Stock" />
            <asp:BoundField DataField="RequestedQuantity" HeaderText="Quantity Requested" />
            <asp:TemplateField HeaderText="Quantity to Retrieve">
                <ItemTemplate>
                    <asp:TextBox ID="RetrieveQty" runat="server" Text='<%# QtyToRetrieve((int) Eval("BalanceQuantity"),(int) Eval("RequestedQuantity")) %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="GenDisbursementButton" runat="server" Text="Generate Disbursement Lists" OnClick="GenDisbursementButton_Click" />
</asp:Content>
