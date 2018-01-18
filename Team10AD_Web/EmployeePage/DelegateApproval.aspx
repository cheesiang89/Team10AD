<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePage/Employee.Master" AutoEventWireup="true" CodeBehind="DelegateApproval.aspx.cs" Inherits="Team10AD_Web.EmployeePage.DelegateApproval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Delegated employee should be always sorted to the top of table PLUS the row will be highlighted</h2>
    <h2>Delegate Approval Authority</h2>
    <asp:GridView ID="dgvDelegateApproval" runat="server"></asp:GridView>
</asp:Content>
