<%@ Page Title="Retrieval List" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="RetrievalList.aspx.cs" Inherits="Team10AD_Web.Clerk.RetrievalList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2> Retrieval List</h2>
    <asp:GridView ID="dgvRetList" runat="server" AllowPaging="True" OnPageIndexChanging="dgvRetList_PageIndexChanging" AutoGenerateColumns="False" OnRowCommand="dgvRetList_RowCommand">
        <Columns>
            <asp:BoundField DataField="RetrievalID" HeaderText="Retrieval ID" ReadOnly="True" />
            <asp:BoundField DataField="RetrievalDate" HeaderText="Retrieval Date" ReadOnly="True" DataFormatString="{0:dd-MMM-yyyy}" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:ButtonField ButtonType="Button" CommandName="Details" Text="Details" />
        </Columns>
    </asp:GridView>
</asp:Content>
