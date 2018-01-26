<%@ Page Title="Stock Flow" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="StockFlow.aspx.cs" Inherits="Team10AD_Web.Clerk.StockCheck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Stock Flow</h2>

    <asp:Label ID="lblItemCode1" runat="server" Text="Item Code:"></asp:Label>
    <asp:Label ID="lblItemCode2" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblItemDesc1" runat="server" Text="Item Description:"></asp:Label>
    <asp:Label ID="lblItemDesc2" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblLoc1" runat="server" Text="Location:"></asp:Label>
    <asp:Label ID="lblLoc2" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblqty1" runat="server" Text="Current Quantity:"></asp:Label>
    <asp:Label ID="lblqty2" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblUOM1" runat="server" Text="UOM:"></asp:Label>
    <asp:Label ID="lblUOM2" runat="server"></asp:Label>
    <br />
    <p><b>History of Transaction</b></p>
    <asp:GridView ID="dgvHstTrans" runat="server" AllowPaging="True" OnPageIndexChanging="dgvHstTrans_PageIndexChanging" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Date" HeaderText="Date" DataFormatString="{0:dd-MMM-yyyy}" />
            <asp:BoundField DataField="Entity" HeaderText="Dept/Supplier/VoucherID" />
            <asp:BoundField DataField="Adjusted_Quantity" HeaderText="Adjusted Quantity" />
            <asp:BoundField DataField="Balance_Quantity" HeaderText="Balance Quantity" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />

</asp:Content>
