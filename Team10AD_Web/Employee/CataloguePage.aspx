
﻿<%@ Page Title="Catalogue" Language="C#" AutoEventWireup="true" MasterPageFile="~/Employee/Employee.Master" CodeBehind="CataloguePage.aspx.cs" Inherits="Team10AD_Web.Employee.CataloguePage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Stationery Catalogue</h2>
    <asp:TextBox ID="txtBoxSearch" runat="server">Search by category/desc</asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" />
    <br />
    <asp:Label runat="server" ID="lblTest" Text=""></asp:Label>

    <asp:GridView ID="dgvCatalogue" runat="server" AllowPaging="True" OnPageIndexChanging="dgvCatalogue_PageIndexChanging"
        AutoGenerateColumns="False" OnRowCommand="dgvCatalogue_RowCommand">
        <Columns>

            <asp:BoundField DataField="Category" HeaderText="Category" ItemStyle-CssClass="Category"></asp:BoundField>
            <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-CssClass="Description"></asp:BoundField>
            <asp:BoundField DataField="UnitOfMeasure" HeaderText="Unit of Measure" ItemStyle-CssClass="UnitOfMeasure"></asp:BoundField>

            <%-- Hidden fields--%>
            <asp:TemplateField Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblItemCode" runat="server" Text='<%# Bind("ItemCode") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="ItemCode" />
            </asp:TemplateField>

            <%--  --%>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="btnAdd" runat="server" Text="Add" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>


    <asp:Button ID="btnTest" runat="server" Text="Test" OnClick="btnTest_Click" />

    <div id="dialog" style="display: none">
        <b>Category</b><asp:Label ID="lblCategory" runat="server"></asp:Label>
        <br />
        <b>Description</b>
        <asp:Label ID="lblDescription" runat="server"></asp:Label>
        <br />
        <b>Unit of Measure</b><asp:Label ID="lblUOM" runat="server"></asp:Label>
        <br />
        <b>Quantity</b><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />

        <br />

    </div>

    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" />
        </Scripts>
        <Scripts>
            <asp:ScriptReference Path="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" />
        </Scripts>
        <Scripts>
            <asp:ScriptReference Path="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" />
        </Scripts>
    </asp:ScriptManagerProxy>



    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">   
        $(document).ready(function () {
            $(document).on("click", "[id*=btnAdd]", function () {
                $("#MainContent_lblCategory").html($(".Category", $(this).closest("tr")).html());
                $("#MainContent_lblDescription").html($(".Description", $(this).closest("tr")).html());
                $("#MainContent_lblUOM").html($(".UnitOfMeasure", $(this).closest("tr")).html());
                $("#dialog").dialog({
                    title: "View Details",
                    buttons: {
                        Ok: function () {
                            $(this).dialog('close');
                        }
                    },
                    modal: true
                });
                //  window.alert($(".Category", $(this).closest("tr")).html());
                return false;
            });
        });
    </script>

</asp:Content>

