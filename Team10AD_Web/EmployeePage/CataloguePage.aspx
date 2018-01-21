<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePage/Employee.Master" AutoEventWireup="true" CodeBehind="CataloguePage.aspx.cs" Inherits="Team10AD_Web.EmployeePage.CataloguePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Stationery Catalogue</h2>
    <asp:TextBox ID="txtBoxSearch" runat="server">Search by category/desc</asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" />
    <br />
<%--    <asp:Label runat="server" ID="lblTest" Text="Test"></asp:Label>--%>
    <br />
    <div id="notifyAdded" style="color:forestgreen"></div>

    <asp:GridView ID="dgvCatalogue" runat="server" AllowPaging="True" OnPageIndexChanging="dgvCatalogue_PageIndexChanging"
        AutoGenerateColumns="False" OnRowCommand="dgvCatalogue_RowCommand">
        <Columns>
            

             <asp:BoundField DataField="ItemCode" HeaderText="Item Code" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="ItemCode hidden" ></asp:BoundField>
            <asp:BoundField DataField="Category" HeaderText="Category" ItemStyle-CssClass="Category"></asp:BoundField>
            <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-CssClass="Description"></asp:BoundField>
            <asp:BoundField DataField="UnitOfMeasure" HeaderText="Unit of Measure" ItemStyle-CssClass="UnitOfMeasure"></asp:BoundField>

            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btnAdd" runat="server" Text="Add" CommandName="Add"  CommandArgument='<%# Container.DataItemIndex %>'/>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

    <div id="dialog" style="display: none">
        <b>Category</b><asp:Label ID="lblCategory" runat="server"></asp:Label>
        <br />
        <b>Description</b>
        <asp:Label ID="lblDescription" runat="server"></asp:Label>
        <br />
        <b>Unit of Measure</b><asp:Label ID="lblUOM" runat="server"></asp:Label>
        <br />
        <b>Quantity</b>
        <%-- Use number spinner: Note that default <input> created has no ID." --%>
       <div id="np">
              <%-- <asp:TextBox ID="txtInputQty" runat="server"></asp:TextBox>--%>
             
             </div>

        <br />
        <div id="warningAddToCart" style="color:red"> Number must be positive integer </div>
        <asp:Label ID="lblItemCode" runat="server" CSSClass="hidden"></asp:Label>
    </div>



</asp:Content>

