<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="DepartmentList.aspx.cs" Inherits="Team10AD_Web.Clerk.DepartmentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Department List</h2>
    <asp:GridView ID="dgvDeptList" runat="server" AutoGenerateColumns="False" OnRowCommand="dgvDeptList_RowCommand">
        <Columns>
            <asp:BoundField DataField="DepartmentCode" HeaderText="Department Code" />
            <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" />
            <asp:BoundField DataField="Name" HeaderText="Head's Name" />
            <asp:ButtonField ButtonType ="Button" CommandName="Select" HeaderText="" Text="Detail" />
        </Columns>
    </asp:GridView>
</asp:Content>
