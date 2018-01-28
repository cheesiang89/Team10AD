<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="RequistionReportFront.aspx.cs" Inherits="Team10AD_Web.Clerk.RequistionReportFront" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <%-- Department --%>
            <td>
                <asp:Label ID="lblDept" runat="server" Text="Department: "></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlDept" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Button ID="btnAddDept" runat="server" Text="Add Department" OnClick="btnAddDept_Click" /></td>
            <td>

                <asp:GridView ID="gridDept" runat="server" OnRowDataBound="gridDept_RowDataBound" OnRowCreated="gridDept_RowCreated">
                    <Columns></Columns>
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Button ID="btnDeleteDept" runat="server" Text="Delete" OnClick="btnDeleteDept_Click" />

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </td>
        </tr>
        <tr>
            <%-- Category --%>
            <td>
                <asp:Label ID="lblCategory" runat="server" Text="Category: "></asp:Label>

            </td>
            <td>
                <asp:DropDownList ID="ddlCategory" runat="server">
                </asp:DropDownList>



            </td>
            <td>
                <asp:Button ID="btnAddCategory" runat="server" Text="Add Category" OnClick="btnAddCategory_Click" /></td>
            <td>
                <asp:GridView ID="gridCategory" runat="server" OnRowDataBound="gridCategory_RowDataBound" OnRowCreated="gridCategory_RowCreated">
                    <Columns></Columns>
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Button ID="btnDeleteCategory" runat="server" Text="Delete" OnClick="btnDeleteCategory_Click" />

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <%-- Month/Year --%>
            <td>
                <asp:Label ID="lblMY" runat="server" Text="Month/Year"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlMonth" runat="server">
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
                </asp:DropDownList>
                <asp:DropDownList ID="ddlYear" runat="server">
                    <asp:ListItem>2016</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2018</asp:ListItem>
                </asp:DropDownList>
                
            </td>
            <td>
                <asp:Button ID="btnAddDate" runat="server" Text="Add Date" OnClick="btnAddDate_Click" /></td>
            <td>
                <asp:GridView ID="gridDate" runat="server" OnRowDataBound="gridDate_RowDataBound" OnRowCreated="gridDate_RowCreated">
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
    </table>
    <asp:Button ID="btnMakeChart" runat="server" Text="Generate Report" OnClick="btnMakeChart_Click" />
</asp:Content>
