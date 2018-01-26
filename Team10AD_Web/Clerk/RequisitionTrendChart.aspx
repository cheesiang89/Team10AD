<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="RequisitionTrendChart.aspx.cs" Inherits="Team10AD_Web.Clerk.RequisitionTrendChart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="chart-container">
    <canvas id="chart" width="400" height="400"></canvas>
</div>
     <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.1/Chart.bundle.min.js"></script>
      <script type="text/javascript" src="<%= ResolveUrl ("~/Scripts/chart.js") %>"></script>
</asp:Content>
