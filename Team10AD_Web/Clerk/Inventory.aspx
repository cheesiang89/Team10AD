<%@ Page Title="Inventory" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="Team10AD_Web.Clerk.Inventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Inventory    
        
    </h2>
    <asp:TextBox ID="SearchBox" placeholder="Search by category/description" runat="server" Width="220px"></asp:TextBox><asp:Button ID="SearchBtn" runat="server" Text="Search" OnClick="SearchBtn_Click" />
    <asp:GridView ID="dgvCatalogue" runat="server" AllowPaging="True" OnPageIndexChanging="dgvCatalogue_PageIndexChanging" AutoGenerateColumns="False" >
        <Columns>
            <asp:BoundField DataField="Category" HeaderText="Category" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="UnitOfMeasure" HeaderText="Unit of Measure" />

        </Columns>
        </asp:GridView>
</asp:Content>
