<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Team10AD_Web.Clerk.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:GridView ID="dgvAlertLowSto" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="ItemCode" HeaderText="Item Code" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="ReorderLevel" HeaderText="Reorder Level" Visible="False" />
                        <asp:BoundField DataField="PendingRequestQuantity" HeaderText="Pending Request Qty" Visible="False" />
                        <asp:BoundField DataField="BalanceQuantity" HeaderText="Balance Quantity" Visible="False" />
                        <asp:BoundField DataField="PendingDeliveryQuantity" HeaderText="Pending Delivery Quantity" Visible="False" />
                        <asp:TemplateField HeaderText="Suggested Quantity to Order">
                            <ItemTemplate>
                                <asp:Label ID="SuggestedQty" runat="server" 
                                    Text='<%# SuggestedOrderQty((int) Eval("ReorderLevel"),(int) Eval("PendingRequestQuantity"), (int) Eval("BalanceQuantity"),(int)Eval("PendingDeliveryQuantity") ) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </td>
            <td>
                <asp:GridView ID="dgvReqPendCol" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="RequisitionID" HeaderText="Request No." />
                        <asp:BoundField DataField="ApprovalDate" HeaderText="Date" DataFormatString="{0:dd-MMM-yyyy}" />
                        <asp:BoundField DataField="DepartmentName" HeaderText="Department"  />
                        <asp:BoundField DataField="Status" HeaderText="Status"/>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnCreatePO" runat="server" Text="Create Purchase Order" OnClick="btnCreatePO_Click" /></td>
            <td>
                <asp:Button ID="btnGoReqRec" runat="server" Text="Go Requests Record" OnClick="btnGoReqRec_Click" /></td>
        </tr>
    </table>
</asp:Content>
