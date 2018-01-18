<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="RequisitionDetail.aspx.cs" Inherits="Team10AD_Web.Clerk.RequisitionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Requisition Details</h2>
    <asp:Label ID="EmployeeName" runat="server" Text="Employee Name:"></asp:Label>
    <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Status" runat="server" Text="Status:"></asp:Label>
    <asp:TextBox ID="StatusTextBox" runat="server"></asp:TextBox>
    <asp:GridView ID="dgvRequisitionDetail" runat="server"></asp:GridView>
    <asp:Button ID="CancelButton" runat="server" Text="Cancel Requisition" />
</asp:Content>
