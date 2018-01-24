<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="GeneratePurchaseOrder.aspx.cs" Inherits="Team10AD_Web.Clerk.GeneratePurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Generate Purchase Order</h2>
    <asp:GridView ID="dgvShortfall" runat="server"></asp:GridView>
</asp:Content>
