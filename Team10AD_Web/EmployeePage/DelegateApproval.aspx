<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePage/Employee.Master" AutoEventWireup="true" CodeBehind="DelegateApproval.aspx.cs" Inherits="Team10AD_Web.EmployeePage.DelegateApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Delegated employee should be always sorted to the top of table PLUS the row will be highlighted</h2>
    <h2>Delegate Approval Authority</h2>
            <asp:GridView ID="dgvDelegateApproval" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="dgvDelegateApproval_SelectedIndexChanged" Width="236px" OnRowCommand="dgvDelegateApproval_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Employee Name" ItemStyle-CssClass="EmpName"/>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="btnDelegate" runat="server" CausesValidation="false" CommandName="Select" Text="Delegate" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
            <%-- Hidden fields--%>
            <asp:TemplateField Visible="False">
                <ItemTemplate>
                    <asp:Label ID="lblApproverID" runat="server" Text='<%# Bind("EmployeeID") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle CssClass="ItemCode" />
            </asp:TemplateField>

            <%--  --%>
                </Columns>
            </asp:GridView>
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lblID" runat="server"></asp:Label>    
    <asp:Label ID="lblApproverID" runat="server"></asp:Label>
    <asp:Label ID="lblApproverName" runat="server" Text="Label"></asp:Label>         
    
     <div id="dialog" style="display: none">
                <b>Approval authority is to be delegated to </b>
                <asp:Label ID="lblApprover" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
         <b>from:</b>
                
                <br />
                <br />
                <b>Start Date:</b>
                <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date" Min='<%# DateTime.Now.ToString("yyyy-MM-dd") %>'></asp:TextBox>
                <asp:RequiredFieldValidator ID="validRequiredStartDate" runat="server" ErrorMessage="This field must be selected." ControlToValidate="txtStartDate" ></asp:RequiredFieldValidator>
                <br />
                <br />
                <b>End Date:</b>
                <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validRequiredEndDate" runat="server" ErrorMessage="This field must be selected" ControlToValidate="txtEndDate" ></asp:RequiredFieldValidator>
                <br />
                <br />
                <br />
                <br />
         <%-- This button need to change --%>
               <%-- <asp:Button ID="btnConfirm" runat="server" Text="Confirm" Font-Bold="True" ForeColor="White" BackColor="#009933" OnClick="btnConfirm_Click" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="btnCancel" runat="server" Text="Cancel" BackColor="Red" ForeColor="White" Font-Bold="True" OnClick="btnCancel_Click" CausesValidation="False" />--%>
            </div>

     <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" />
        </Scripts>
        <Scripts>
            <asp:ScriptReference Path="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" />
        </Scripts>
        <Scripts>
            <asp:ScriptReference Path="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" />
        </Scripts>
    </asp:ScriptManagerProxy>

    
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $(document).on("click", "[id*=btnDelegate]", function () {
                $("#MainContent_txtStartDate").html($(".EmpName", $(this).closest("tr")).html());
                $("#MainContent_txtStartDate").attr("min", (new Date()).toISOString().substring(0, 10));
                $("#MainContent_txtEndDate").attr("min", (new Date()).toISOString().substring(0, 10));
                  $("#dialog").dialog({
                    title: "View Details",
                    buttons: {
                        Confirm: function () {
                            close();
                            $(this).dialog('close');
                        },
                        Close: function () {
                            $(this).dialog('close');
                        }
                    },
                    modal: true
                });
                //  window.alert($(".Category", $(this).closest("tr")).html());
                return false;
            });

            function close() {
                //Dump all code in this function
                window.alert("TEst"); //closing on Ok click
            }
        });

       
    </script>
</asp:Content>
