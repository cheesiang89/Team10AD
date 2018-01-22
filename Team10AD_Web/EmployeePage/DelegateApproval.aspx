<%@ Page Title="" Language="C#" MasterPageFile="~/EmployeePage/Employee.Master" AutoEventWireup="true" CodeBehind="DelegateApproval.aspx.cs" Inherits="Team10AD_Web.EmployeePage.DelegateApproval" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Delegated employee should be always sorted to the top of table PLUS the row will be highlighted</h2>
    <h2>Delegate Approval Authority</h2>
    <asp:GridView ID="dgvDelegateApproval" runat="server" AutoGenerateColumns="False" Width="236px" OnRowCommand="dgvDelegateApproval_RowCommand">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Employee Name" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnDelegate" runat="server" CausesValidation="false" CommandName="Select" Text="Delegate" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lblID" runat="server"></asp:Label>
    <asp:Label ID="lblApproverID" runat="server"></asp:Label>
    <asp:Label ID="lblApproverName" runat="server" Text="Label"></asp:Label>
    <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
    <%--  <asp:LinkButton ID="lnkBtn2" runat="server"></asp:LinkButton>--%>
    <cc1:ModalPopupExtender ID="mPop1" runat="server" BackgroundCssClass="modalBackground" PopupControlID="UpdatePanel1" TargetControlID="lnkDummy" >
    </cc1:ModalPopupExtender>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
  <%--  <div id="updatePanel1Div" class="modalPopup">--%>
    <asp:Panel ID="UpdatePanel1" runat="server" CssClass="modalPopup" align="center" >
        <%--<ContentTemplate>--%>
        <asp:Label ID="lblSubtitle1" runat="server" Font-Bold="True" Font-Size="Medium">Approval authority is to be delegated to </asp:Label>
            <asp:Label ID="lblApprover" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></asp:Label>
            <asp:Label ID="lblSubtitle2" runat="server" Text=" from:" Font-Bold="True" Font-Size="Medium"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblStartDate" runat="server" Font-Bold="True">Start Date:</asp:Label>
            <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="validRequiredStartDate" runat="server" ErrorMessage="This field must be selected." ControlToValidate="txtStartDate" ForeColor="#FF3300" Font-Bold="True"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:Label ID="lblEndDate" runat="server" Font-Bold="True">End Date:</asp:Label>
            <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="validRequiredEndDate" runat="server" ErrorMessage="This field must be selected" ControlToValidate="txtEndDate" ForeColor="#FF3300" Font-Bold="True"></asp:RequiredFieldValidator>
            <br />
            <asp:CompareValidator ID="validCompareDates" runat="server" ErrorMessage="End date should not be before Start date." Font-Bold="True" Operator="GreaterThanEqual" ControlToCompare="txtStartDate" ControlToValidate="txtEndDate" ForeColor="Red"></asp:CompareValidator>
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="btnConfirm" runat="server" Text="Confirm" Font-Bold="True" ForeColor="White" BackColor="#009933" OnClick="btnConfirm_Click" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="Button2" runat="server" Text="Cancel" BackColor="Red" ForeColor="White" Font-Bold="True" OnClick="btnCancel_Click" CausesValidation="False" />
       <%-- </ContentTemplate>--%>
    </asp:Panel>
       <%-- </div>--%>
 <%--   <div id="updatePane21Div" class="modalPopup">--%>
      <asp:LinkButton ID="lnkBtn2" runat="server"></asp:LinkButton>
      <cc1:ModalPopupExtender ID="mPop2" runat="server" BackgroundCssClass="modalBackground" PopupControlID="UpdatePanel2" TargetControlID="lnkBtn2" >
    </cc1:ModalPopupExtender>
    <asp:Panel ID="UpdatePanel2" runat="server" CssClass="modalPopup" align="center" >
        <%--<ContentTemplate>--%>
            <asp:Label ID="lblFailApprover" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#009933"></asp:Label>
            <asp:Label ID="lblFailApproverSubtitle1" runat="server" Font-Bold="True" Font-Size="Medium" >, has outstanding requisition(s).</asp:Label>
            <br />
            <br />
            <asp:Label ID="lblFailApproverSubtitle2" runat="server" Font-Bold="True" Font-Size="Medium">Proceed to Department Requisition page to approve the pending requisition(s) before delegation? </asp:Label>
            <br />
            <br />
               <asp:Button ID="btnConfirmProceed" runat="server" Text="Confirm" Font-Bold="True" ForeColor="White" BackColor="#009933" OnClick="btnConfirmProceed_Click" CausesValidation="False" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Button ID="btnCancelProceed" runat="server" Text="Cancel" BackColor="Red" ForeColor="White" Font-Bold="True" OnClick="btnCancelProceed_Click" CausesValidation="False" />
       <%--     </ContentTemplate>--%>
    </asp:Panel>
  <%--  </div>--%>
</asp:Content>
