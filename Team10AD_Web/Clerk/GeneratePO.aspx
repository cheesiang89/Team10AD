<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="GeneratePO.aspx.cs" Inherits="Team10AD_Web.Clerk.GeneratePO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create Purchase Order </h2>
    <div>
        <asp:Label ID="lblItemCode" runat="server" Text="Item Code"></asp:Label>
        <asp:TextBox ID="txtItemCode" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
    </div>
    <asp:Label ID="lblTag" runat="server" Text=""></asp:Label>
    <%-- <asp:Panel ID="pnlDescription" Visible="false" runat="server">--%>

    <asp:Label ID="lblDescription" runat="server" Text="Hello"></asp:Label>
    <asp:Button ID="btnAddItem" runat="server" Text="Add Item" OnClick="btnAddItem_Click" />

    <%--</asp:Panel>--%>
    <br />
    <asp:Label ID="lblTest" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <br />
    <asp:Repeater ID="repeaterItems" runat="server" OnItemCommand="repeaterItems_ItemCommand">

        <ItemTemplate>
            <table class="table table-bordered">
                <tr>
                    <th>
                        <asp:Label ID="lblHeaderIC" runat="server" Text="Item Code"></asp:Label>
                    </th>
                    <th>
                        <asp:Label ID="lblHeaderDesc" runat="server" Text="Description"></asp:Label>
                    </th>
                    <th>
                        <asp:Label ID="lblHeaderS1" runat="server" Text='<%# "Quantity("+ Eval("FirstSupplier")+")" %>'></asp:Label>
                    </th>
                    <th>
                        <asp:Label ID="lblHeaderS2" runat="server" Text='<%# "Quantity("+ Eval("SecondSupplier")+")" %>'></asp:Label>
                    </th>
                    <th>
                        <asp:Label ID="lblHeaderS3" runat="server" Text='<%# "Quantity("+ Eval("ThirdSupplier")+")" %>'></asp:Label>
                    </th>
                    <th></th>
                </tr>
                <tr>
                    <td></trd>
                        <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label></td>
                    <td>
                        <asp:TextBox ID="txtSupp1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSupp2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="txtSupp3" runat="server"></asp:TextBox>
                    </td>
                    <th>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete"
                            CommandArgument='<%# Container.ItemIndex %>'
                            CommandName="Delete" /></th>
                </tr>
            </table>
        </ItemTemplate>

    </asp:Repeater>

    <asp:Button ID="btnGeneratePO" runat="server" Text="Generate PO" OnClick="btnGeneratePO_Click" />
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />

</asp:Content>
