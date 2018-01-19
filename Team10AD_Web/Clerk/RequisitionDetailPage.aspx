<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="RequisitionDetailPage.aspx.cs" Inherits="Team10AD_Web.Clerk.RequisitionDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Requisition Details</h2>
    <asp:Label ID="ReqID" runat="server" Text="Requisition ID:"></asp:Label>
    <asp:TextBox ID="ReqIDTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Status" runat="server" Text="Status:"></asp:Label>
    <asp:TextBox ID="StatusTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="DeptName" runat="server" Text="Department Name:"></asp:Label>
    <asp:TextBox ID="DeptNameTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="DeptCode" runat="server" Text="Department Code:"></asp:Label>
    <asp:TextBox ID="DeptCodeTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="EmployeeName" runat="server" Text="Employee Name:"></asp:Label>
    <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="EmployeePhone" runat="server" Text="Employee Number:"></asp:Label>
    <asp:TextBox ID="EmployeePhoneTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Email" runat="server" Text="Employee Email:"></asp:Label>
    <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:GridView ID="dgvRequisitionDetail" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="QuantityRequested" HeaderText="Quantity Requested" />
            <asp:BoundField DataField="QuantityRetrieved" HeaderText="Quantity Retrieved" />
        </Columns>
    </asp:GridView>
</asp:Content>
