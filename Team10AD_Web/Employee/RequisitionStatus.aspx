<%@ Page Title="" Language="C#" MasterPageFile="~/Employee/Employee.Master" AutoEventWireup="true" CodeBehind="RequisitionStatus.aspx.cs" Inherits="Team10AD_Web.Employee.RequisitionStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      <h2>Requisition Status</h2>
    <asp:GridView ID="dgvReqStatus" runat="server" AutoGenerateColumns="False" OnRowCommand="dgvReqStatus_RowCommand">
        <Columns>
            <asp:BoundField DataField="RequisitionID" HeaderText="Requisition ID" />
            <asp:BoundField DataField="Name" HeaderText="Employee Name" ReadOnly="True" />
            <asp:BoundField DataField="RequisitionDate" HeaderText="Date" ReadOnly="True" />
            <asp:BoundField DataField="Status" HeaderText="Status" ReadOnly="True" />
            <asp:BoundField DataField="EmployeeID" HeaderText="Status" ReadOnly="True" Visible="false" />
            <asp:ButtonField ButtonType="Button" CommandName="Details" Text="Details" />
            <asp:TemplateField>
                <ItemTemplate>
                <asp:Button runat="server" Text="Cancel" 
                Visible='<%# IsRequestorAndPending((int) Eval("EmployeeID"),(int) Eval("RequisitionID")) %>' 
                CommandName="CancelRequisition"/>
            </ItemTemplate>
            </asp:TemplateField>
        </Columns>
      </asp:GridView>
</asp:Content>
