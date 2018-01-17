<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true" CodeBehind="RequisitionDetails.aspx.cs" Inherits="Team10AD_Web.Employee.RequisitionDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Requisition Details</h2>
    <asp:Label ID="lblEmName" runat="server" Text="Employee Name:"></asp:Label>
    <asp:TextBox ID="txtBoxEmName" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:Label ID="lblStatus" runat="server" Text="Status:"></asp:Label>
    <asp:TextBox ID="txtBoxStatus" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:GridView ID="dgvReqDetails" runat="server"></asp:GridView>
</asp:Content>
