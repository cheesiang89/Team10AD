<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="CrystalRequisitionReport.aspx.cs" Inherits="Team10AD_Web.Clerk.CrystalRequisitionReport" %>
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
            <td>
                <asp:Label ID="lblDept" runat="server" Text="Department:"></asp:Label></td>
            <td>
                <asp:DropDownList ID="dropDept" runat="server" DataSourceID="SqlDataSource1" DataTextField="DepartmentName" DataValueField="DepartmentName"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Team10ADConnectionString %>" SelectCommand="SELECT [DepartmentName] FROM [Departments]"></asp:SqlDataSource>
            </td>
            <td>
                <asp:Button ID="btnAddDept" runat="server" Text="Add" OnClick="btnAddDept_Click" /></td>
            <td>
                <asp:GridView ID="dgvDept" runat="server" AutoGenerateColumns="False" OnRowCommand="dgvDept_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Department">
                            
                            <ItemTemplate>
                                <asp:Label ID="lblDept" runat="server" Text='<%# Bind("Department") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField ShowHeader="False">
                            <ItemTemplate>
                                <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="DeleteRow" Text="Delete" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;<asp:Label ID="lblCatagory" runat="server" Text="Catagory:"></asp:Label></td>
            <td class="auto-style1">&nbsp;<asp:DropDownList ID="dropCategory" runat="server" DataSourceID="SqlDataSource3" DataTextField="Category" DataValueField="Category"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Team10ADConnectionString %>" SelectCommand="SELECT DISTINCT Category FROM Catalogues"></asp:SqlDataSource>
            </td>
            <td>&nbsp;<asp:Button ID="btnCategoryAdd" runat="server" Text="Add" OnClick="btnCategoryAdd_Click" /></td>
             <td>&nbsp;<asp:GridView ID="dgvCategory" runat="server" AutoGenerateColumns="False" OnRowCommand="dgvCategory_RowCommand">
                 <Columns>
                     <asp:TemplateField HeaderText="Category">
                         <ItemTemplate>
                                <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>'></asp:Label>
                            </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField ShowHeader="False">
                         <ItemTemplate>
                             <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="DeleteRow" Text="Delete" />
                         </ItemTemplate>
                     </asp:TemplateField>
                 </Columns>
                 </asp:GridView>
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
            <td>
               <asp:GridView ID="dgvDate" runat="server" AutoGenerateColumns="False" OnRowCommand="dgvDate_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="Date">                     
                        <ItemTemplate>
                            <asp:Label ID="lblDate" runat="server" Text='<%# Bind("Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="Button1" runat="server" CausesValidation="false" CommandName="DeleteRow" Text="Delete" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                </asp:GridView>

            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;<asp:Label ID="lblYear" runat="server" Text="Year:"></asp:Label></td>
            <td class="auto-style1">&nbsp;<asp:DropDownList ID="dropYear" runat="server">
                <asp:ListItem>2016</asp:ListItem>
                <asp:ListItem>2017</asp:ListItem>
                <asp:ListItem>2018</asp:ListItem>
                </asp:DropDownList></td>
            <td>&nbsp;<asp:Button ID="btnDateAdd" runat="server" Text="Add" OnClick="btnDateAdd_Click"/></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1"><asp:Button ID="btnGenerate" runat="server" Text="Generate" OnClick="btnGenerate_Click" /></td>
            <td><asp:Button ID="btnClear" runat="server" Text="Clear" OnClick="btnClear_Click" /></td>
            <td>&nbsp;</td>            
        </tr>
    </table>
</asp:Content>
