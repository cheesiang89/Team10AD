<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePage/Employee.Master" AutoEventWireup="true" CodeBehind="DepartmentRequisitionHistory.aspx.cs" Inherits="Team10AD_Web.EmployeePage.DepartmentRequisitionHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Department Requisition History</h2>
    <asp:Button ID="btnPendingReq" runat="server" Text="Pending Requisition" OnClick="btnPendingReq_Click" />
    <asp:Button ID="btnReqHst" runat="server" Text="Requisiton History" />
    <br />
    <br />
     <asp:GridView ID="dgvDepReqHst" runat="server" AutoGenerateColumns="False" OnRowCommand="dgvDepReqHst_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="S/N">
                <ItemTemplate>
                   <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Employee Name" DataField="Name" />
            <asp:BoundField DataField="RequisitionDate" HeaderText="Requisition Date" DataFormatString="{0:dd-MMM-yyyy}"/>
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnDetails" runat="server" CausesValidation="false" CommandName="Details" Text="Details" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="RequisitionID" HeaderText="RequisitionID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
            <asp:BoundField DataField="RequestorID" HeaderText="Employee ID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
        </Columns>
    </asp:GridView>
</asp:Content>