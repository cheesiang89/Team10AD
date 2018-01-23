<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="GeneratePO.aspx.cs" Inherits="Team10AD_Web.Clerk.GeneratePO" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create Purchase Order </h2>
    <div>
        <asp:Label ID="lblItemCode" runat="server" Text="Item Code"></asp:Label>
        <asp:TextBox ID="txtItemCode" runat="server"></asp:TextBox>
           <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
    </div>
    <asp:Label ID="lblTag" runat="server" Text="" ></asp:Label>
   <%-- <asp:Panel ID="pnlDescription" Visible="false" runat="server">--%>
        
        <asp:Label ID="lblDescription" runat="server" Text="Hello" ></asp:Label>
            <asp:Button ID="btnAddItem" runat="server" Text="Add Item" OnClick="btnAddItem_Click" />
      
    <%--</asp:Panel>--%>
    <asp:Repeater ID="repeaterItems" runat="server">
         <ItemTemplate>
   <asp:Label ID="itemDescription" runat="server" Text=<%# Eval("Description") %> ></asp:Label>
          
    </ItemTemplate>
    </asp:Repeater>
</asp:Content>
