<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="RetrievalDetailPage.aspx.cs" Inherits="Team10AD_Web.Clerk.RetrievalDetailPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Retrieval Details</h2>
    <asp:Label ID="RetID" runat="server" Text="Retrieval ID:"></asp:Label>
    <asp:TextBox ID="RetIDTextBox" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:Label ID="RetStatus" runat="server" Text="Status:"></asp:Label>
    <asp:TextBox ID="StatusTextBox" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:ValidationSummary ID="QtyValidationSummary" runat="server" validationgroup="QtyValidation"/>
    <br />
    <asp:GridView ID="dgvRetrievalDetail" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:BoundField DataField="BalanceQuantity" HeaderText="Current Stock" />
            <asp:BoundField DataField="RequestedQuantity" HeaderText="Quantity Requested" />
            <asp:TemplateField HeaderText="Quantity to Retrieve">
                <ItemTemplate>
                    <asp:TextBox ID="RetrieveQty" runat="server" Text='<%# QtyToRetrieve((int) Eval("BalanceQuantity"),(int) Eval("RequestedQuantity")) %>'></asp:TextBox>
                    <asp:CompareValidator ID="QtyValidator" runat="server" controltovalidate="RetrieveQty" ValueToCompare='<%# (int) Eval("RequestedQuantity")%>' operator="LessThanEqual" type="Integer" ErrorMessage="Have to be equal or less than the quantity requested" Font-Bold="True" ></asp:CompareValidator>
                    <asp:CompareValidator ID="NegativeQtyValidator" runat="server" controltovalidate="RetrieveQty" ValueToCompare='0' operator="GreaterThanEqual" type="Integer" ErrorMessage="Cannot be negative" Font-Bold="True" ></asp:CompareValidator>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="GenDisbursementList" runat="server" Text="Generate Disbursement Lists" OnClick="GenDisbursementList_Click" />
</asp:Content>
