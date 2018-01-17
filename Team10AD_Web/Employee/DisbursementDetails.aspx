<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true" CodeBehind="DisbursementDetails.aspx.cs" Inherits="Team10AD_Web.Employee.DisbursementDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <h2>Disbursement Details</h2>
    <asp:Label ID="lblDisList1" runat="server" Text="Disbursement List:"></asp:Label>
    <asp:Label ID="lblDisList2" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblSts1" runat="server" Text="Status:"></asp:Label>
    <asp:Label ID="lblSts2" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblColDate1" runat="server" Text="Collection Date£º"></asp:Label>
    <asp:Label ID="lblColDate2" runat="server" ></asp:Label>
    <br />
    <asp:GridView ID="dgvDisList" runat="server"></asp:GridView>
    <br />
    <asp:Label ID="lblRemarks" runat="server" Text="Remarks:"></asp:Label>
    <br />
    <asp:TextBox ID="txtBoxRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
    <br/>
    <asp:Label ID="lblDeptRepName1" runat="server" Text="Department Representative Name:"></asp:Label>
    <asp:Label ID="lblDeptRepName2" runat="server" ></asp:Label>
    <asp:Label ID="lblSignature1" runat="server" Text="Signature"></asp:Label>
    <asp:Image ID="Image1" runat="server" />
</asp:Content>
