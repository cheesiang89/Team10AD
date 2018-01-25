<%@ Page Title="Requisition Record" Language="C#" MasterPageFile="~/Clerk/Clerk.Master" AutoEventWireup="true" CodeBehind="RequisitionRecord.aspx.cs" Inherits="Team10AD_Web.Clerk.RequestsRecords" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Pending Requisitions</h2>
    <asp:GridView ID="dgvReqList" runat="server" AllowPaging="True" OnPageIndexChanging="dgvReqList_PageIndexChanging" AutoGenerateColumns="False" OnRowCommand="dgvReqList_RowCommand" OnRowDataBound="dgvReqList_RowDataBound">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:CheckBox ID="allchk" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="selectchk" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="RequisitionID" HeaderText="Requisition No." ReadOnly="True" />
            <asp:BoundField DataField="ApprovalDate" HeaderText="Date" ReadOnly="True" DataFormatString="{0:dd-MMM-yyyy}" />
            <asp:BoundField DataField="DepartmentName" HeaderText="Department Name" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:ButtonField ButtonType="Button" CommandName="Details" Text="Details" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="GenRetListButton" runat="server" Text="Generate Retrieval List" OnClick="GenRetListButton_Click" />
    <asp:Button ID="ReqHistButton" runat="server" Text="View Requisition History" OnClick="ReqHistButton_Click" />

    <script type="text/javascript">
        function SelectAll(id)
        {
            //get reference of GridView control
            var grid = document.getElementById("<%= dgvReqList.ClientID %>");
            //variable to contain the cell of the grid
            var cell;
            
            if (grid.rows.length > 0)
            {
                //loop starts from 1. rows[0] points to the header.
                for (i=1; i<grid.rows.length; i++)
                {
                    //get the reference of first column
                    cell = grid.rows[i].cells[0];
                    
                    //loop according to the number of childNodes in the cell
                    for (j=0; j<cell.childNodes.length; j++)
                    {           
                        //if childNode type is CheckBox                 
                        if (cell.childNodes[j].type =="checkbox")
                        {
                        //assign the status of the Select All checkbox to the cell 
                        //checkbox within the grid
                            cell.childNodes[j].checked = document.getElementById(id).checked;
                        }
                    }
                }
            }
        }
    </script>

</asp:Content>
