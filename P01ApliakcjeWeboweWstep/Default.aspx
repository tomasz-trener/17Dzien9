<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="P01ApliakcjeWeboweWstep.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <asp:Button ID="Button1" OnClick="Button1_Click" runat="server" Text="Button" />

        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

        <asp:ListBox ID="lbDane" Height="300" runat="server"></asp:ListBox>

    </form>
</body>
</html>
