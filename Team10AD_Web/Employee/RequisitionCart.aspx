<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true" CodeBehind="RequisitionCart.aspx.cs" Inherits="Team10AD_Web.Employee.RequisitionCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><b>Requisition Cart</b></h2>
           
    <asp:GridView ID="dgvRequisitionCart" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField />
            <asp:BoundField />
            <asp:BoundField />
            <asp:BoundField />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
  
    <asp:Button ID="btnSubmitRequisition" runat="server" Text="Submit Requisition" />

    <asp:Button ID="btnEmptyCart" runat="server" Text="Empty Cart" />


</asp:Content>
