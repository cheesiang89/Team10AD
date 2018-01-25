<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="DepartmentDetail.aspx.cs" Inherits="Team10AD_Web.Clerk.DepartmentDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Department Details</h2>
    <asp:Label ID="lblDeptCode" runat="server" Text="Department Code:"></asp:Label>
    <asp:TextBox ID="txtBoxDeptCode" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:Label ID="lblDeptName" runat="server" Text="Department Name:"></asp:Label>
    <asp:TextBox ID="txtBoxDeptName" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:Label ID="lblContName" runat="server" Text="Contact Name:"></asp:Label>
    <asp:TextBox ID="txtBoxContName" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:Label ID="lblTelNum" runat="server" Text="Telephone No.:"></asp:Label>
    <asp:TextBox ID="txtBoxTelNum" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:Label ID="lblRepName" runat="server" Text="Representative Name:"></asp:Label>
    <asp:TextBox ID="txtBoxRepName" runat="server" ReadOnly="True"></asp:TextBox>

    <br />

    <asp:Label ID="lblColPoint" runat="server" Text="Collection Point:"></asp:Label>
    <asp:TextBox ID="txtBoxColPoint" runat="server" ReadOnly="True"></asp:TextBox>



</asp:Content>
