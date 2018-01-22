
<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePage/Employee.Master" AutoEventWireup="true" CodeBehind="DepartmentRequisition.aspx.cs" Inherits="Team10AD_Web.EmployeePage.DepartmentRequisition" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Department Requisition</h2>
    <asp:Button ID="btnPendingReq" runat="server" Text="Pending Requisition" />
    <asp:Button ID="btnReqHst" runat="server" Text="Requisition History" />
    <br />
    <br />
    <asp:GridView ID="dgvDepReq" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="S/N">
                <ItemTemplate>
                   <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="RequestorID" HeaderText="Employee ID" />
            <asp:BoundField DataField="RequisitionDate" HeaderText="Requisition Date" DataFormatString="{0:dd-MMM-yyyy}"/>
            <asp:ButtonField ButtonType="Button" ShowHeader="True" Text="Details" />
            <asp:BoundField DataField="RequisitionID" HeaderText="RequisitionID"  />
            <asp:BoundField HeaderText="Employee Name" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="Requestor ID" DataField="RequestorID" />
            <asp:BoundField HeaderText="Requestor Name" DataField="Name" />
        </Columns>
    </asp:GridView>


</asp:Content>