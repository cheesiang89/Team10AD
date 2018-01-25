<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePage/Employee.Master" AutoEventWireup="true" CodeBehind="AssignRepresentative.aspx.cs" Inherits="Team10AD_Web.EmployeePage.AssignRepresentative" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <h2>Assign Representative</h2>
    <asp:Label ID="lblRepName" runat="server" Font-Bold="True" ForeColor="#009933" Font-Size="Medium"></asp:Label>
    <asp:Label ID="lblRepSubtitle1" runat="server" Font-Bold="True" ForeColor="#333333" Font-Size="Medium"></asp:Label>
    <br />
    <asp:Label ID="lblRepSubtitle2" runat="server" Font-Bold="True" Font-Italic="True" Font-Size="Medium"></asp:Label>
    <asp:GridView ID="dgvAssignRep" runat="server" AutoGenerateColumns="False" OnRowCommand="dgvAssignRep_RowCommand">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Employee Name" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnAssign" runat="server" CausesValidation="false" CommandName="Assign" Text="Assign" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
     </asp:GridView>
</asp:Content>
