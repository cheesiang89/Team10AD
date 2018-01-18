<%@ Page Title="Inventory" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="Team10AD_Web.Clerk.Inventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Inventory    </h2>
    <asp:GridView ID="dgvCatalogue" runat="server" AllowPaging="True" OnPageIndexChanging="dgvCatalogue_PageIndexChanging" AutoGenerateColumns="False" >
        <Columns>
            <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
            <asp:BoundField DataField="Category" HeaderText="Category" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="ReorderLevel" HeaderText="Reorder Level" />
            <asp:BoundField DataField="MinimumOrderQuantity" HeaderText="Reorder Quantity" />
            <asp:BoundField DataField="BalanceQuantity" HeaderText="Existing Quantity" />
            <asp:BoundField DataField="UnitOfMeasure" HeaderText="Unit of Measure" />
            <asp:BoundField DataField="Location" HeaderText="Location" />
            <asp:ButtonField Text="Details" />
        </Columns>
        </asp:GridView>

 
</asp:Content>
