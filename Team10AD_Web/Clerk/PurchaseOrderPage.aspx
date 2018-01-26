<%@ Page Title="Purchase Order" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="PurchaseOrderPage.aspx.cs" Inherits="Team10AD_Web.Clerk.PurchaseOrderPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Purchase Order Record</h2>
    <asp:GridView ID="dgvPORecord" runat="server" AllowPaging="True" OnPageIndexChanging="dgvPORecord_PageIndexChanging" AutoGenerateColumns="False" OnRowCommand="dgvPORecord_RowCommand">
        <Columns>
            <asp:BoundField DataField="POID" HeaderText="Purchase Order ID" />
            <asp:BoundField DataField="CreationDate" HeaderText="Creation Date" DataFormatString="{0:dd-MMM-yyyy}" />
            <asp:BoundField DataField="SupplierName" HeaderText="Supplier" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="Details" Text="Details" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
