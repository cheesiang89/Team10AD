<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="OrderReportPage.aspx.cs" Inherits="Team10AD_Web.Clerk.OrderReportPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Chart ID="orderChart" runat="server" Width="1029px" Height="760px">
      
    <series>
        <asp:Series Name="Series1">
        </asp:Series>
         <asp:Series Name="Series2">
        </asp:Series>
        <asp:Series Name="Series3">
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
    <Titles>
        <asp:Title Name="Title1">
        </asp:Title>
    </Titles>
</asp:Chart>  
</asp:Content>
