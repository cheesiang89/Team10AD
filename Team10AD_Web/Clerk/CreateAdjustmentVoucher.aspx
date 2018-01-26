<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="CreateAdjustmentVoucher.aspx.cs" Inherits="Team10AD_Web.Clerk.CreateAdjustmentVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create Adjustment Voucher</h2>
    <asp:GridView ID="dgvCreateAdj" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ItemCode" HeaderText="Item Code" ReadOnly="True"/>
            <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="True" />
            <asp:BoundField DataField="QuantityAdjusted" HeaderText="Quantity to Adjust" ReadOnly="True" />
            <asp:TemplateField HeaderText="Reason">
                <ItemTemplate>
                    <asp:TextBox ID="ReasonTextBox" runat="server" TextMode="MultiLine" Width="350px" MaxLength="200"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
      </asp:GridView>
    <asp:Button ID="UpdateButton" runat="server" Text="Update" OnClick="UpdateButton_Click" />
</asp:Content>
