

<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true" CodeBehind="DepartmentRequisitionDetail.aspx.cs" Inherits="Team10AD_Web.Employee.DepartmentRequisitionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Department Requisition Detail</h2>
    <table>
        <tr>
            <td>Employee Name:</td>
            <td><asp:TextBox ID="txtBoxEmployeeName" runat="server" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Status</td>
            <td><asp:TextBox ID="txtBoxStatus" runat="server" ReadOnly="True"></asp:TextBox></td>
        </tr>
    </table>
    <asp:GridView ID="dgvDpReqDetails" runat="server"></asp:GridView>
    <br />
    Remarks (Optional): <asp:TextBox ID="txtBoxRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
    <table>
        <tr>
            <td><asp:Button ID="btnApprove" runat="server" Text="Approve" /></td>   
            <td><asp:Button ID="btnReject" runat="server" Text="Reject" /></td>
        </tr>
    </table>   
</asp:Content>
