<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SimpleLinqExample._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:Button ID="cmdSimpleLINQtoSQL" runat="server" 
        onclick="cmdSimpleLINQtoSQL_Click" Text="SimpleLINQtoSQL" />
    <br />
    <br />
    <asp:Button ID="SimpleLINQtoSQlWithQuery" runat="server" 
        onclick="SimpleLINQtoSQlWithQuery_Click" Text="SimpleLINQtoSQlWithQuery" />
    <asp:TextBox ID="txtCustomerCode" runat="server" Width="220px">Enter Customer Code here</asp:TextBox>
    <br />
    <br />
    <asp:Button ID="SimpleLINQtoSQlWithSetGet" runat="server" 
        onclick="SimpleLINQtoSQlWithSetGet_Click" Text="SimpleLINQtoSQlWithSetGet" />
    <br />
    <br />
    <asp:Button ID="LINQtoSQLrelationShipEntitySetAndEntityRef" runat="server" 
        onclick="LINQtoSQLrelationShip_Click" 
        Text="LINQtoSQLrelationShipEntitySetAndEntityRef" />
    <br />
    <br />
    <asp:Button ID="LINQtoSQLusingDataLoadOption" runat="server" 
        onclick="LINQtoSQLusingDataLoadOption_Click" 
        Text="LINQtoSQLusingDataLoadOption" />
    <br />
    <br />
    </form>
</body>
</html>
