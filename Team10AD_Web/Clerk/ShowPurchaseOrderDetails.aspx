<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="ShowPurchaseOrderDetails.aspx.cs" Inherits="Team10AD_Web.Clerk.ShowPurchaseOrderDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Purchase Order Details - <asp:Label ID="lblpoid" runat="server" Text="Label"></asp:Label></h2>
    <br />
    <asp:Label ID="lblDate1" runat="server" Text="Date: "></asp:Label>
    <asp:Label ID="lblDate2" runat="server" Text=""></asp:Label>
    <br />
    <asp:Label ID="lblSupplier1" runat="server" Text="Supplier: "></asp:Label>
    <asp:Label ID="lblSupplier2" runat="server" Text=""></asp:Label>
    <asp:GridView ID="dgvPODetails" runat="server" AllowPaging="True" OnPageIndexChanging="dgvPODetails_PageIndexChanging" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" />
        </Columns>
    </asp:GridView>
</asp:Content>
