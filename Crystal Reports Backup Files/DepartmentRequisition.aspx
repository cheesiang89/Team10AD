<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePage/Employee.Master" AutoEventWireup="true" CodeBehind="DepartmentRequisition.aspx.cs" Inherits="Team10AD_Web.EmployeePage.DepartmentRequisition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Department Requisition</h2>
    <asp:Button ID="btnPendingReq" runat="server" Text="Pending Requisition" />
    <asp:Button ID="btnReqHst" runat="server" Text="Requisition History" OnClick="btnReqHst_Click" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label" type="datetime-local"></asp:Label>
    <asp:GridView ID="dgvDepReq" runat="server" AutoGenerateColumns="False" OnRowCommand="dgvDepReq_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="S/N">
                <ItemTemplate>
                    <%#Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Employee Name" DataField="Name" />
            <asp:BoundField DataField="RequisitionDate" HeaderText="Requisition Date" DataFormatString="{0:dd-MMM-yyyy}" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="Details" Text="Details" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="RequisitionID" HeaderText="Requisition ID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                <HeaderStyle CssClass="hide"></HeaderStyle>
                <ItemStyle CssClass="hide"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="RequestorID" HeaderText="Requestor ID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide">
                <HeaderStyle CssClass="hide"></HeaderStyle>
                <ItemStyle CssClass="hide"></ItemStyle>
            </asp:BoundField>
        </Columns>
    </asp:GridView>
</asp:Content>
