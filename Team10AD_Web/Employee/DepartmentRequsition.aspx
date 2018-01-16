
<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true" CodeBehind="DepartmentRequisition.aspx.cs" Inherits="Team10AD_Web.DepartmentRequisition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Department Requisition</h2>
    <asp:Button ID="btnPendingReq" runat="server" Text="Pending Requisition" />
    <asp:Button ID="btnReqHst" runat="server" Text="Requisition History" />
    <asp:GridView ID="dgvDepReq" runat="server"></asp:GridView>
</asp:Content>