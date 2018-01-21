<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePage/Employee.Master" AutoEventWireup="true" CodeBehind="RequisitionCart.aspx.cs" Inherits="Team10AD_Web.EmployeePage.RequisitionCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2><b>Requisition Cart</b></h2>
          <%-- Populate rows --%> 
    <div id="tableContent">
   <table class="table table-bordered" id="cartTable">
       <tr>
           <th>Item Code</th>
           <th>Description</th>
           <th>Quantity</th>
           <th>Unit of Measure</th>
           <th></th>
       </tr>
   </table>
    </div>
   <input id="btnSubmitRequisition" type="button" value="Submit Requisition" />
    <%--<asp:Button ID="btnSubmitRequisition" runat="server" Text="Submit Requisition" />--%>
    <input id="btnEmptyCart" type="button" value="Empty Cart" />
    <%--<asp:Button ID="btnEmptyCart" runat="server" Text="Empty Cart" />--%>
   <%--   <input id="btnTest" type="button" value="Test" />--%>
<%--    <asp:Button ID="Test" runat="server" Text="Test" />--%>
<script type="text/javascript" src="<%= ResolveUrl ("~/Scripts/cart.js") %>"></script>
    <asp:HiddenField ID="reqID" runat="server" />
   <a href="/EmployeePage/Test.aspx"></a>
</asp:Content>
