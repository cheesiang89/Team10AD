<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="ClerkReqReport.aspx.cs" Inherits="Team10AD_Web.Clerk.ClerkReqReport" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="dgvReqRpt" runat="server"></asp:GridView>
    <asp:Chart ID="chartRequisitionReport" runat="server" Width="907px" CssClass="auto-style1" Height="412px">
        <Titles>
            <asp:Title runat="server" Text="Total Marks of Students"></asp:Title>
        </Titles>
        <Series>
            <asp:Series Name="Series1">
               <%-- <Points>
                    <asp:DataPoint  AxisLabel="Mark" YValues="800"/>
                    <asp:DataPoint  AxisLabel="Zen" YValues="500"/>
                    <asp:DataPoint  AxisLabel="Sam" YValues="600"/>
                    <asp:DataPoint  AxisLabel="Marc" YValues="800"/>
                </Points>--%>
            </asp:Series>
              <asp:Series Name="Series2">
               <%-- <Points>
                    <asp:DataPoint  AxisLabel="Hello" YValues="800"/>
                    <asp:DataPoint  AxisLabel="Shoes" YValues="500"/>
                    <asp:DataPoint  AxisLabel="Sammy" YValues="600"/>
                    <asp:DataPoint  AxisLabel="March" YValues="800"/>
                </Points>--%>
            </asp:Series>
             <asp:Series Name="Series3">
               <%-- <Points>
                    <asp:DataPoint  AxisLabel="Hello" YValues="800"/>
                    <asp:DataPoint  AxisLabel="Shoes" YValues="500"/>
                    <asp:DataPoint  AxisLabel="Sammy" YValues="600"/>
                    <asp:DataPoint  AxisLabel="March" YValues="800"/>
                </Points>--%>
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </asp:Content>
