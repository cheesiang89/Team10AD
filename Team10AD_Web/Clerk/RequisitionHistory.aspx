<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="RequisitionHistory.aspx.cs" Inherits="Team10AD_Web.Clerk.RequisitionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Requisition History</h2>
    <asp:GridView ID="dgvReqList" runat="server" AutoGenerateColumns="False" OnRowCommand="dgvReqList_RowCommand">
        <Columns>
            <asp:BoundField DataField="RequisitionID" HeaderText="Requisition No." ReadOnly="True" />
            <asp:BoundField DataField="ApprovalDate" HeaderText="Date" ReadOnly="True" DataFormatString="{0:dd-MMM-yyyy}" />
            <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:ButtonField ButtonType="Button" CommandName="Details" Text="Details" />
        </Columns>

    </asp:GridView>
</asp:Content>
