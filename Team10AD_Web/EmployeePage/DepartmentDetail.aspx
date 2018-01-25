<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePage/Employee.Master" AutoEventWireup="true" CodeBehind="DepartmentDetail.aspx.cs" Inherits="Team10AD_Web.EmployeePage.DepartmentDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
           <h2>Department Details</h2>
    <table>
        <tr>
            <td>Representative Name:</td>
            <td><asp:TextBox ID="txtBoxRepName" runat="server" ReadOnly="True"></asp:TextBox></td>
        </tr>
         <tr>
            <td>Collection Point:</td>
            <td><asp:TextBox ID="txtBoxCollectionPt" runat="server" ReadOnly="True"></asp:TextBox></td>
        </tr>
    </table> 
</asp:Content>
