<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true" CodeBehind="RequisitionStatus.aspx.cs" Inherits="Team10AD_Web.Employee.RequisitionStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <h2>Requisition Status</h2>
    <asp:GridView ID="dgvReqStatus" runat="server" AutoGenerateColumns="False" OnRowCommand="dgvReqStatus_RowCommand">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Employee Name" />
            <asp:BoundField DataField="RequisitionDate" HeaderText="Date" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:ButtonField ButtonType="Button" CommandName="Details" Text="Details" />
            <asp:ButtonField ButtonType="Button" CommandName="Cancel" Text="Cancel" />
        </Columns>
      </asp:GridView>
</asp:Content>
