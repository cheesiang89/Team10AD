<%@ Page Title="Disbursement List" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="DisbursementList.aspx.cs" Inherits="Team10AD_Web.Clerk.DisbursementRecord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Disbursement Record</h2>
    <asp:GridView ID="dgvDisbursementRecord" runat="server" AutoGenerateColumns="False" OnRowCommand="dgvDisbursementRecord_RowCommand">
        <Columns>
            <asp:BoundField DataField="DisbursementID" HeaderText="Disbursement List No." />
            <asp:BoundField DataField="CollectionDate" HeaderText="Collection Date" />
            <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" />
            <asp:BoundField DataField="PointName" HeaderText="Collection Point" />
            <asp:BoundField DataField="Name" HeaderText="Representative Name" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="details" Text="Details" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
