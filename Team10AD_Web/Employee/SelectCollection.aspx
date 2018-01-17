<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true" CodeBehind="SelectCollection.aspx.cs" Inherits="Team10AD_Web.Employee.SelectCollection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Only representative can make changes to this page</h2>
    <h2>Select Collection Point</h2>
    <asp:RadioButtonList ID="rdoBtnSelectCollection" runat="server"></asp:RadioButtonList>
</asp:Content>
