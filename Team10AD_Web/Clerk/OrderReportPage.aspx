<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="OrderReportPage.aspx.cs" Inherits="Team10AD_Web.Clerk.OrderReportPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblCategory" runat="server" Text="Category:"></asp:Label></td>
            <td>    
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
                                <asp:Button ID="btnDeleteCat" runat="server" Text="Delete" OnClick="btnDeleteCat_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMY" runat="server" Text="Month/Year:"></asp:Label></td>
            <td>
            <asp:DropDownList ID="dropMonth" runat="server">
                <asp:ListItem Value="1">Jan</asp:ListItem>
                <asp:ListItem Value="2">Feb</asp:ListItem>
                <asp:ListItem Value="3">Mar</asp:ListItem>
                <asp:ListItem Value="4">Apr</asp:ListItem>
                <asp:ListItem Value="5">May</asp:ListItem>
                <asp:ListItem Value="6">Jun</asp:ListItem>
                <asp:ListItem Value="7">Jul</asp:ListItem>
                <asp:ListItem Value="8">Aug</asp:ListItem>
                <asp:ListItem Value="9">Sep</asp:ListItem>
                <asp:ListItem Value="10">Oct</asp:ListItem>
                <asp:ListItem Value="11">Nov</asp:ListItem>
                <asp:ListItem Value="12">Dec</asp:ListItem>
            </asp:DropDownList>
                <asp:DropDownList ID="dropYear" runat="server">
                    <asp:ListItem Value="2016">2016</asp:ListItem>
                    <asp:ListItem Value="2017">2017</asp:ListItem>
                    <asp:ListItem Value="2018">2018</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnAddDate" runat="server" Text="Add" OnClick="btnAddDate_Click" /></td>
              <td>
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
            <td><asp:Button ID="btnGenerateReport" runat="server" Text="Generate Order Report" OnClick="btnGenerateReport_Click" />
            </td>
            <td colspan="2">&nbsp;&nbsp;&nbsp;<asp:Button ID="btnClearSelection" runat="server" Text="Clear All Selections" />
            </td>
        </tr>
    </table>
    <asp:Chart ID="orderChart" runat="server">
    <series>
        <asp:Series Name="Series1">
        </asp:Series>
         <asp:Series Name="Series2">
        </asp:Series>
    </series>
    <chartareas>
        <asp:ChartArea Name="ChartArea1">
        </asp:ChartArea>
    </chartareas>
        </asp:Chart>  
</asp:Content>
