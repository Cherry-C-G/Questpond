<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisplayStock.aspx.cs" Inherits="DisplayStock" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnIncreaseStock" runat="server" OnClick="btnIncreaseStock_Click"
            Text="Increase Stock" />&nbsp;<br />
        <asp:TextBox ID="txtStockValue" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnDecreaseStock" runat="server" OnClick="btnDecreaseStock_Click"
            Text="Decrease Stock" /></div>
    </form>
</body>
</html>
