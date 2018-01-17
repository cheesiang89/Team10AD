<%@ Page Title="Inventory" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="Team10AD_Web.Clerk.Inventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Inventory    </h2>
    <asp:GridView ID="dgvCatalogue" runat="server" AllowPaging="true" OnPageIndexChanging="dgvCatalogue_PageIndexChanging" >
        </asp:GridView>

 
</asp:Content>
