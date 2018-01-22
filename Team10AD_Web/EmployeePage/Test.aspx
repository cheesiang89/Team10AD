<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="Team10AD_Web.EmployeePage.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblFirstName" runat="server" Text="FirstName "></asp:Label>
            <br /><br />
            <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label>
            <br /><br />
            <asp:Button ID="btnAutoEmail" runat="server" Text="Auto" OnClick="btnAutoEmail_Click" />
            <%--<asp:Hyperlink id="lnkEmail" runat="server" navigateurl="mailto:user@example.com?subject=MessageTitle&body=MessageContent" target="" text="a@example.com" xmlns:asp="#unknown"/>--%>
        
        </div>
    </form>
</body>
</html>
