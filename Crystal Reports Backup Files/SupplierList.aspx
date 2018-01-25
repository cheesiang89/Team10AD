<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="SupplierList.aspx.cs" Inherits="Team10AD_Web.Clerk.SupplierList1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Supplier</h2>

    <asp:GridView ID="dgvSupList" runat="server" AllowPaging="True" OnPageIndexChanging="dgvSupList_PageIndexChanging" AutoGenerateColumns="False" OnRowCommand="dgvSupList_RowCommand">

        <Columns>
            <asp:BoundField DataField="SupplierCode" HeaderText="Supplier Code" />
            <asp:BoundField DataField="SupplierName" HeaderText="Supplier Name" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="Select" Text="Detail" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
         </asp:GridView>
</asp:Content>
