<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="GenerateRequestReport.aspx.cs" Inherits="Team10AD_Web.Clerk.GenerateRequestReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 131px;
        }
        .auto-style2 {
            width: 97px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td class="auto-style2"> <asp:Label ID="lblDept" runat="server" Text="Department:"></asp:Label></td>
            <td class="auto-style1"><asp:DropDownList ID="dropDept" runat="server" DataSourceID="SqlDataSource1" DataTextField="DepartmentName" DataValueField="DepartmentName"></asp:DropDownList>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Team10ADConnectionString %>" SelectCommand="SELECT [DepartmentName] FROM [Departments]"></asp:SqlDataSource></td>
            <td><asp:Button ID="btnAddDept" runat="server" Text="Add" OnClick="btnAddDept_Click" /></td>           
            <td>
            <asp:GridView ID="dgvDept" runat="server" OnSelectedIndexChanged="dgvDept_SelectedIndexChanged">
            
                </asp:GridView></td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2"><asp:Label ID="lblMonth" runat="server" Text="Month:"></asp:Label></td>
            <td class="auto-style1"><asp:DropDownList ID="dropMonth" runat="server">
                <asp:ListItem>January</asp:ListItem>
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
        </tr>
         <tr>
            <td class="auto-style2"><asp:Label ID="lblYear" runat="server" Text="Year:"></asp:Label></td>
            <td class="auto-style1">
                <asp:DropDownList ID="dropYear" runat="server">
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                </asp:DropDownList></td>
             <td>
                 <asp:Button ID="btnADDMonth" runat="server" Text="Add" /></td>
            <td>
                <asp:GridView ID="dgvMmonth" runat="server"></asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblCategory" runat="server" Text="Category:"></asp:Label></td>
            <td class="auto-style1">
                <asp:DropDownList ID="dropCategory" runat="server" DataSourceID="SqlDataSource2" DataTextField="Category" DataValueField="Category"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Team10ADConnectionString %>" SelectCommand="SELECT distinct  [Category] FROM [Catalogues] "></asp:SqlDataSource>
            </td>
             <td>
                 <asp:Button ID="btnAddCategory" runat="server" OnClick="btnAddCategory_Click" Text="Add" />
            </td>
            <td>
                <asp:GridView ID="dgvCatagory" runat="server"></asp:GridView>
            </td>
        </tr>
         <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1"><asp:Button ID="btnGenerate" runat="server" Text="Generate" /></td>
            <td><asp:Button ID="btnClear" runat="server" Text="Clear" /></td>
            <td>&nbsp;</td>
            
        </tr>
    </table>
</asp:Content>
