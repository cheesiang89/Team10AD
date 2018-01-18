<%@ Page Title="Catalogue" Language="C#"  AutoEventWireup="true" MasterPageFile="~/Employee/Employee.Master" CodeBehind="CataloguePage.aspx.cs" Inherits="Team10AD_Web.Employee.CataloguePage" %>
<%@ Register Assembly="ASP.Web.UI.PopupControl" Namespace="ASP.Web.UI.PopupControl" TagPrefix="ASPP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Stationery Catalogue</h2>
    <asp:TextBox ID="txtBoxSearch" runat="server">Search by category/desc</asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search" />
    <br />
    <asp:Label runat="server" ID="lblTest" Text=""></asp:Label>
   
    <asp:GridView ID="dgvCatalogue" runat="server" AllowPaging="True" OnPageIndexChanging="dgvCatalogue_PageIndexChanging"
        AutoGenerateColumns="False" OnRowCommand="dgvCatalogue_RowCommand" >
        <Columns>
            <asp:BoundField DataField="ItemCode" HeaderText="Item Code" ItemStyle-CssClass="ItemCode"/>
            <asp:BoundField DataField="Category" HeaderText="Category" ItemStyle-CssClass="Category"/>
            <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-CssClass="Description"/>
            <asp:BoundField DataField="MinimumOrderQuantity" HeaderText="Reorder Quantity" ItemStyle-CssClass="MinQty" />

            <asp:TemplateField ShowHeader="False" >
                <ItemTemplate>
                    <asp:LinkButton ID="btnAdd" runat="server" Text="Add" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>"/>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
     



    <ASPP:PopupPanel HeaderText="" ID="popup" runat="server" >
            <PopupWindow runat="server" >
                <ASPP:PopupWindow ID="PopupWindow1" runat="server">
                  <div align="center" style="width: 500px; height:150px">
                    <table >
                        <tr>
                            <td>
                                <asp:Label runat="server" Text="Category:" /></td>
                            <td>
                                <asp:Label runat="server" Text="" ID="lblCategory" /></td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label runat="server" Text="Description:" /></td>
                            <td>
                                 <asp:Label runat="server" Text="" ID="lblDescription" /></td>
                        </tr>
                        <tr>
                            <td >
                                <asp:Label runat="server" Text="Unit of Measure:" /></td>
                            <td >
                                <asp:Label runat="server" Text="" ID="lblUOM" /></td>
                        </tr>
                            <tr>
                            <td>
                                <asp:Label runat="server" Text="Quantity:" /></td>
                            <td>
                                                               
                                <asp:TextBox runat="server" ID="txtQuantity" CausesValidation="False"></asp:TextBox></td>
                          </tr>
                        <tr>
                           <td>
                               <%-- <asp:RegularExpressionValidator ID="validNumOnly" runat="server" 
                                    ErrorMessage="Numbers only" ControlToValidate="txtQuantity"  
                                    ValidationExpression="^\d+$" ValidationGroup="vNumOnly"></asp:RegularExpressionValidator>--%>
                                <%--<asp:RequiredFieldValidator ID="validRequired" runat="server" 
                                    ErrorMessage="Required" ControlToValidate="txtQuantity"></asp:RequiredFieldValidator>
                                <asp:RangeValidator ID="validRange" runat="server" 
                                    ErrorMessage="Must be positive value" ControlToValidate="txtQuantity" MinimumValue="0" 
                                    SetFocusOnError="False" MaximumValue="100"></asp:RangeValidator>--%>
                               <asp:ValidationSummary runat="server" ID="vSummary" ValidationGroup="vNumOnly" DisplayMode="BulletList" /></td> 
                        </tr>
                        <tr>
                            <td>
                            <asp:Button ID="btnConfirm" CommandName="Add" runat="server" Text="Add to Cart" OnClick="btnConfirm_Click" 
                                OnClientClick="return false"/>
                                </td>
                        </tr>

                    </table>
                      </div>
                </ASPP:PopupWindow>
            </PopupWindow>
        </ASPP:PopupPanel>
    
    
    
    
    
    
    
</asp:Content>

