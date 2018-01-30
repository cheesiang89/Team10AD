<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="RequistionReportFront.aspx.cs" Inherits="Team10AD_Web.Clerk.RequistionReportFront" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:RadioButtonList ID="rdoCatorDept" runat="server" onclick="chooseReqReport();" OnSelectedIndexChanged="rdoCatorDept_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem Value="category" Text="Multiple Categories comparison"></asp:ListItem>
        <asp:ListItem Value="dept" Text="Multiple Department comparison"></asp:ListItem>

                </asp:RadioButtonList>
    <asp:Panel ID="pnlReportContent" runat="server" Visible="false">
             <table style="width: 100%;">
        <tr>
            <%-- Department --%>
            <td>
                <asp:Label ID="lblDept" runat="server" Text="Department: "></asp:Label>
                <br />
                <asp:Label ID="lblMax1Dept" runat="server" Text="Max 1 Dept" Visible="false"></asp:Label>
                <br />
                  <asp:Label ID="lblMax3Dept" runat="server" Text="Max 3 Dept" Visible="false"></asp:Label>

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
                      <br />
                <asp:Label ID="lblMax1Cat" runat="server" Text="Max 1 Category" Visible="false"></asp:Label>
                <br />
                  <asp:Label ID="lblMax3Cat" runat="server" Text="Max 3 Category" Visible="false"></asp:Label>

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
                     <asp:ListItem></asp:ListItem>
                    <asp:ListItem>Jan</asp:ListItem>
                    <asp:ListItem>Feb</asp:ListItem>
                    <asp:ListItem>Mar</asp:ListItem>
                    <asp:ListItem>Apr</asp:ListItem>
                    <asp:ListItem>May</asp:ListItem>
                    <asp:ListItem>Jun</asp:ListItem>
                    <asp:ListItem>Jul</asp:ListItem>
                    <asp:ListItem>Aug</asp:ListItem>
                    <asp:ListItem>Sep</asp:ListItem>
                    <asp:ListItem>Oct</asp:ListItem>
                    <asp:ListItem>Nov</asp:ListItem>
                    <asp:ListItem>Dec</asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="ddlYear" runat="server">
                     <asp:ListItem></asp:ListItem>
                   <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2017</asp:ListItem>
                    <asp:ListItem>2016</asp:ListItem>
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
        </asp:Panel>
    
</asp:Content>
