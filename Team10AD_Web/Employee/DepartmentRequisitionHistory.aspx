<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true" CodeBehind="DepartmentRequisitionHistory.aspx.cs" Inherits="Team10AD_Web.Employee.DepartmentRequisitionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Department Requisition History</h2>
    <asp:Button ID="btnPendingReq" runat="server" Text="Pending Requisition" />
    <asp:Button ID="btnReqHst" runat="server" Text="Requisiton History" />
    <asp:GridView ID="dgvDepReqHst" runat="server"></asp:GridView>
</asp:Content>