<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="RequisitionReportPage.aspx.cs" Inherits="Team10AD_Web.Clerk.RequisitionReportPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Chart ID="reqChart" runat="server" Width="1029px" Height="760px">
      
    <series>
        <asp:Series Name="Series1" Legend="Legend1">
        </asp:Series>
         <asp:Series Name="Series2" Legend="Legend1">
        </asp:Series>
        <asp:Series Name="Series3" Legend="Legend1">
        </asp:Series>
    </series>
    <chartareas>
        <asp:ChartArea Name="ChartArea1">
            <AxisY Title="Quantity Requested">
            </AxisY>
            <AxisX Title="Month, Year">
            </AxisX>
        </asp:ChartArea>
    </chartareas>
        <Legends>
            <asp:Legend Name="Legend1">
            </asp:Legend>
            <asp:Legend Name="Legend2">
            </asp:Legend>
            <asp:Legend Name="Legend3">
            </asp:Legend>
        </Legends>
    <Titles>
        <asp:Title Name="Title1" Font="Microsoft Sans Serif, 12pt, style=Bold">
        </asp:Title>
    </Titles>
</asp:Chart>
</asp:Content>
