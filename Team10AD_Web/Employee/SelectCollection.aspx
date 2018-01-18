<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true" CodeBehind="SelectCollection.aspx.cs" Inherits="Team10AD_Web.Employee.SelectCollection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Only representative can make changes to this page</h2>
    <h2>Select Collection Point</h2>
    <asp:Label ID="lblSelection" runat="server" Text="Label" Visible="False"></asp:Label>
    <asp:RadioButtonList ID="rdoBtnSelectCollection" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdoBtnSelectCollection_SelectedIndexChanged">
        <asp:ListItem Value="1">Administration Building (9:30 am)</asp:ListItem>
        <asp:ListItem Value="2">Management School (11:00 am)</asp:ListItem>
        <asp:ListItem Value="3">Medical School (9:30 am)</asp:ListItem>
        <asp:ListItem Value="4">Engineering School (11:00 am)</asp:ListItem>
        <asp:ListItem Value="5">Science School (9:30 am)</asp:ListItem>
        <asp:ListItem Value="6">University Hospital (11:00 am)</asp:ListItem>
    </asp:RadioButtonList>
</asp:Content>
