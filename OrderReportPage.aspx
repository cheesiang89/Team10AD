<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="OrderReportPage.aspx.cs" Inherits="Team10AD_Web.Clerk.OrderReportPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 172px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblCategory" runat="server" Text="Category:"></asp:Label>&nbsp;
                <asp:DropDownList ID="ddlCat" runat="server"></asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnAddCategory" runat="server" Text="Add" OnClick="btnAddCategory_Click" /></td>
            <td>
                <asp:GridView ID="dgvCategory" runat="server" OnRowCreated="dgvCategory_RowCreated" OnRowDataBound="dgvCategory_RowDataBound">
                    <Columns></Columns>
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Button ID="btnDeleteCat" runat="server" Text="Delete" OnClick="btnDeleteCat_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMonth" runat="server" Text="Month:"></asp:Label>&nbsp;
            <asp:DropDownList ID="dropMonth" runat="server">
                <asp:ListItem Value="1">January</asp:ListItem>
                <asp:ListItem Value="2">February</asp:ListItem>
                <asp:ListItem Value="3">March</asp:ListItem>
                <asp:ListItem Value="4">April</asp:ListItem>
                <asp:ListItem Value="5">May</asp:ListItem>
                <asp:ListItem Value="6">June</asp:ListItem>
                <asp:ListItem Value="7">July</asp:ListItem>
                <asp:ListItem Value="8">August</asp:ListItem>
                <asp:ListItem Value="9">September</asp:ListItem>
                <asp:ListItem Value="10">October</asp:ListItem>
                <asp:ListItem Value="11">November</asp:ListItem>
                <asp:ListItem Value="12">December</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
            <td>
            <td>&nbsp;</td>
            <td></td>
        </tr>
        <tr>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblYear" runat="server" Text="Year:"></asp:Label>&nbsp;
                <asp:DropDownList ID="dropYear" runat="server">
                    <asp:ListItem Value="2016">2016</asp:ListItem>
                    <asp:ListItem Value="2017">2017</asp:ListItem>
                    <asp:ListItem Value="2018">2018</asp:ListItem>
                </asp:DropDownList>
            <td class="auto-style1">
                <asp:Button ID="btnAddDate" runat="server" Text="Add" OnClick="btnAddDate_Click" />

            </td>
       
            <td class="auto-style1">
                <asp:GridView ID="dgvDate" runat="server" OnRowDataBound="gridDate_RowDataBound" OnRowCreated="gridDate_RowCreated">
                    <Columns></Columns>
                    <Columns></Columns>
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Button ID="btnDeleteDate" runat="server" Text="Delete" OnClick="btnDeleteDate_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
           <td></td> 
            <td>
               &nbsp;&nbsp;&nbsp; <asp:Button ID="btnGenerateReport" runat="server" Text="Generate Order Report" />
            </td>
            <td colspan="2">
                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnClearSelection" runat="server" Text="Clear All Selections" />
            </td>
        </tr>
    </table>
</asp:Content>
