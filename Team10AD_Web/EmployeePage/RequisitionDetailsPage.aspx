<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePage/Employee.Master" AutoEventWireup="true" CodeBehind="RequisitionDetailsPage.aspx.cs" Inherits="Team10AD_Web.EmployeePage.RequisitionDetailsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Requisition Details</h2>
    <asp:Label ID="EmployeeName" runat="server" Text="Employee Name:"></asp:Label>
    <asp:TextBox ID="NameTextBox" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:Label ID="Status" runat="server" Text="Status:"></asp:Label>
    <asp:TextBox ID="StatusTextBox" runat="server" ReadOnly="True"></asp:TextBox>
    <asp:GridView ID="dgvRequisitionDetail" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="QuantityRequested" HeaderText="Quantity" />
            <asp:BoundField DataField="UnitOfMeasure" HeaderText="Unit Of Measure" />
            <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="CancelButton" runat="server" Text="Cancel Requisition" Visible="false" OnClick="CancelButton_Click" />
    <br />
    <asp:Label ID="lblRemarks" runat="server" Text="Remarks (Optional): "></asp:Label>&nbsp&nbsp<asp:TextBox ID="txtBoxRemarks" runat="server" TextMode="MultiLine" Height="51px" Width="201px" style = "resize:none" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnApprove" runat="server" Text="Approve" Visible="false" OnClick="btnApprove_Click"/>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="btnReject" runat="server" Text="Reject" Visible="false" OnClick="btnReject_Click"/>
</asp:Content>
