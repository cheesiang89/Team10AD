<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="AdjustmentVoucherList.aspx.cs" Inherits="Team10AD_Web.Clerk.AdjustmentVoucherList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Adjustment Voucher Records</h2>
    <asp:GridView ID="dgvAdjVoucher" runat="server" AutoGenerateColumns="False" OnRowCommand="dgvAdjVoucher_RowCommand" OnPageIndexChanging="dgvAdjVoucher_PageIndexChanging">
        <Columns>
            <asp:BoundField DataField="VoucherID" HeaderText="Voucher ID" />
            <asp:BoundField DataField="Name" HeaderText="Done By" ReadOnly="True" />
            <asp:BoundField DataField="DateIssue" HeaderText="Date Issued" ReadOnly="True" DataFormatString="{0:dd-MMM-yyyy}"/>
            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" />
            <asp:BoundField DataField="Approver" HeaderText="Acknowledged By" ReadOnly="True" />
            <asp:ButtonField ButtonType="Button" CommandName="Details" Text="Details" />
        </Columns>
      </asp:GridView>
</asp:Content>
