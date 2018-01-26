<%@ Page Title="" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="GeneratePO.aspx.cs" Inherits="Team10AD_Web.Clerk.GeneratePO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Create Purchase Order </h2>
    <div>
        <asp:Label ID="lblItemCode" runat="server" Text="Item Code"></asp:Label>
        <asp:TextBox ID="txtItemCode" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CausesValidation="False" />

    </div>
    <asp:Label ID="lblTag" runat="server" Text=""></asp:Label>
    <%-- <asp:Panel ID="pnlDescription" Visible="false" runat="server">--%>


    <asp:Button ID="btnAddItem" runat="server" Text="Add Item" OnClick="btnAddItem_Click" CausesValidation="False" />

    <%--</asp:Panel>--%>
    <br />
    <asp:Label ID="lblTest" runat="server" Text=""></asp:Label>
    <br />
    <br />
    <br />


    <asp:Repeater ID="repeaterItems" runat="server" OnItemCommand="repeaterItems_ItemCommand">

        <ItemTemplate>
            <%-- <asp:RequiredFieldValidator ID="ValidatorRequired1" runat="server" ErrorMessage="Field required. Enter 0 if no quantity" ControlToValidate="txtSupp1" ValidationGroup="Supplier1" Display="None"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="ValidatorPositiveInt1" runat="server" ErrorMessage="Positive Numbers Only" ControlToValidate="txtSupp1" ValidationExpression="^[0-9][0-9]*$" ValidationGroup="Supplier1" Display="None" BackColor="Red" ></asp:RegularExpressionValidator>--%>
            <%-- <asp:RequiredFieldValidator ID="ValidatorRequired2" runat="server" ErrorMessage="Field required. Enter 0 if no quantity" ControlToValidate="txtSupp2" ValidationGroup="Supplier2" Display="None" BackColor="Red" EnableViewState="True" EnableClientScript="False"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="ValidatorPositiveInt2" runat="server" ErrorMessage="Positive Numbers Only" ControlToValidate="txtSupp2" ValidationExpression="^[0-9][0-9]*$" ValidationGroup="Supplier2" Display="None" BackColor="Red" EnableViewState="True" EnableClientScript="False"></asp:RegularExpressionValidator>--%>
            <%-- <asp:RequiredFieldValidator ID="ValidatorRequired3" runat="server" ErrorMessage="Field required. Enter 0 if no quantity" ControlToValidate="txtSupp3" ValidationGroup="Supplier3" Display="None" BackColor="Red" EnableViewState="True" EnableClientScript="False"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Positive Numbers Only" ControlToValidate="txtSupp3" ValidationExpression="^[0-9][0-9]*$" ValidationGroup="Supplier3" Display="None" BackColor="Red" EnableViewState="True" EnableClientScript="False"></asp:RegularExpressionValidator>--%>

            <table id='poTable' class="table table-bordered">
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
                    <td>
                        <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label></td>
                    <td>
                        <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label></td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <td>


                                <asp:TextBox ID="txtSupp1" runat="server"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="ValidatorRequired1"
                                    runat="server" ErrorMessage="Field required. Enter 0 if no quantity"
                                    ControlToValidate="txtSupp1" ValidationGroup="Supplier1"></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator ID="ValidatorPositiveInt1" runat="server"
                                    ErrorMessage="Positive Numbers Only" ControlToValidate="txtSupp1"
                                    ValidationExpression="^[0-9][0-9]*$" ValidationGroup="Supplier1"></asp:RegularExpressionValidator>
                                <%--              <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Supplier1" CssClass="text-danger" DisplayMode="SingleParagraph" />--%>
                                <br />
                                <asp:Label ID="lblMinQty1" runat="server" CssClass="text-danger" Text="Qty must be above min. qty" Visible="False">  </asp:Label>

                            </td>
                            <td>
                                <asp:TextBox ID="txtSupp2" runat="server"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="ValidatorRequired2" runat="server"
                                    ErrorMessage="Field required. Enter 0 if no quantity"
                                    ControlToValidate="txtSupp2" ValidationGroup="Supplier2"
                                    EnableViewState="True" EnableClientScript="False"></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator ID="ValidatorPositiveInt2" runat="server"
                                    ErrorMessage="Positive Numbers Only" ControlToValidate="txtSupp2"
                                    ValidationExpression="^[0-9][0-9]*$" ValidationGroup="Supplier2"
                                    EnableViewState="True" EnableClientScript="False"></asp:RegularExpressionValidator>
                                <%--  <asp:ValidationSummary ID="ValidationSummary2" runat="server" ValidationGroup="Supplier2" CssClass="text-danger" DisplayMode="SingleParagraph"/>--%>
                                <br />
                                <asp:Label ID="lblMinQty2" runat="server" CssClass="text-danger" Text="Qty must be above min. qty" Visible="False">  </asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSupp3" runat="server"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="ValidatorRequired3" runat="server"
                                    ErrorMessage="Field required. Enter 0 if no quantity"
                                    ControlToValidate="txtSupp3" ValidationGroup="Supplier3"
                                    EnableViewState="True" EnableClientScript="False"></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                                    runat="server" ErrorMessage="Positive Numbers Only"
                                    ControlToValidate="txtSupp3" ValidationExpression="^[0-9][0-9]*$"
                                    ValidationGroup="Supplier3" EnableViewState="True"
                                    EnableClientScript="False"></asp:RegularExpressionValidator>
                                <%--<asp:ValidationSummary ID="ValidationSummary3" runat="server" ValidationGroup="Supplier3"  CssClass="text-danger" DisplayMode="SingleParagraph"/>--%>
                                <br />
                                <asp:Label ID="lblMinQty3" runat="server" CssClass="text-danger" Text="Qty must be above min. qty" Visible="False">  </asp:Label>
                            </td>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <td>
                        <asp:Button ID="btnDelete" runat="server" Text="Delete"
                            CommandArgument='<%# Container.ItemIndex %>'
                            CommandName="Delete" CausesValidation="False" /></td>
                </tr>
            </table>
        </ItemTemplate>

    </asp:Repeater>

    <asp:Button ID="btnGeneratePO" runat="server" Text="Generate PO" OnClick="btnGeneratePO_Click" CausesValidation="True" />

    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CausesValidation="False" />

</asp:Content>
