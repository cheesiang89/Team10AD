<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="GenerateOrderReport.aspx.cs" Inherits="Team10AD_Web.Clerk.GenerateOrderReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 253px;
        }
        .auto-style2 {
            width: 76px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td class="auto-style2">&nbsp;<asp:Label ID="lblCatagory" runat="server" Text="Catagory:"></asp:Label></td>
            <td class="auto-style1">&nbsp;<asp:DropDownList ID="dropCategory" runat="server" DataSourceID="SqlDataSource3" DataTextField="Category" DataValueField="Category"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Team10ADConnectionString %>" SelectCommand="SELECT DISTINCT Category FROM Catalogues"></asp:SqlDataSource>
            </td>
            <td>&nbsp;<asp:Button ID="btnCategoryAdd" runat="server" Text="Add" OnClick="btnCategoryAdd_Click" /></td>
             <td>&nbsp;<asp:GridView ID="dgvCategory" runat="server"></asp:GridView>
             </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;<asp:Label ID="lblMonth" runat="server" Text="Month:"></asp:Label></td>
            <td class="auto-style1">&nbsp;<asp:DropDownList ID="dropMonth" runat="server">
                <asp:ListItem>Janurary</asp:ListItem>
                <asp:ListItem>February</asp:ListItem>
                <asp:ListItem>March</asp:ListItem>
                <asp:ListItem>April</asp:ListItem>
                <asp:ListItem>May</asp:ListItem>
                <asp:ListItem>June</asp:ListItem>
                <asp:ListItem>July</asp:ListItem>
                <asp:ListItem>August</asp:ListItem>
                <asp:ListItem>September</asp:ListItem>
                <asp:ListItem>October</asp:ListItem>
                <asp:ListItem>November</asp:ListItem>
                <asp:ListItem>December</asp:ListItem>
                </asp:DropDownList></td>
            <td>&nbsp;</td>
            <td>&nbsp;<asp:GridView ID="dgvMonth" runat="server"></asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;<asp:Label ID="lblYear" runat="server" Text="Year:"></asp:Label></td>
            <td class="auto-style1">&nbsp;<asp:DropDownList ID="dropYear" runat="server">
                <asp:ListItem>2016</asp:ListItem>
                <asp:ListItem>2017</asp:ListItem>
                <asp:ListItem>2018</asp:ListItem>
                </asp:DropDownList></td>
            <td>&nbsp;<asp:Button ID="btnYearAdd" runat="server" Text="Add" /></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1"><asp:Button ID="btnGenerate" runat="server" Text="Generate" /></td>
            <td><asp:Button ID="btnClear" runat="server" Text="Clear" /></td>
            <td>&nbsp;</td>            
        </tr>
    </table>
</asp:Content>
