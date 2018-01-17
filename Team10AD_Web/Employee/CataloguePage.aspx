<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true" CodeBehind="CataloguePage.aspx.cs" Inherits="Team10AD_Web.Employee.CataloguePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <h2>Stationery Catalogue</h2>
    <asp:TextBox ID="txtBoxSearch" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" />
    <br />
    <asp:GridView ID="dgvCatalogue" runat="server"></asp:GridView>
</asp:Content>
