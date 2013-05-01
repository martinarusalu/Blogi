<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminiLeht.aspx.cs" Inherits="Blogimootor.Admin.AdminiLeht" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Blogimootor - administraator</title>
    <link rel="stylesheet" type="text/css" href="global.css" />
</head>
<body>
    <header>
        <h1>Blogi</h1>
    </header>
    <form id="form1" runat="server">
        <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="Redirect" LogoutPageUrl="~/Pealeht.aspx"/><br />
        Tere, <asp:LoginName ID="LoginName1" runat="server" /><br />
        <h2>Uus postitus</h2><br />
        Pealkiri:<br /><asp:TextBox ID="PealkiriTb" Width="500px" runat="server" CssClass="lahtrid"></asp:TextBox><br />
        Sisu:<br /><asp:TextBox ID="TekstTb" TextMode="MultiLine" CssClass="lahtrid" Width="500px" Height="200px" runat="server"></asp:TextBox><br />
        Postitused:<br /><asp:ListBox ID="ListBox1" Width="300px" CssClass="lahtrid" Height="150px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:ListBox><br />
        <asp:Button ID="lisaBtn" runat="server" Text="Lisa" OnClick="lisaBtn_Click"/>
        <asp:Button ID="muudaBtn" runat="server" Text="Muuda" OnClick="muudaBtn_Click" />
        <asp:Button ID="kustutaBtn" runat="server" Text="Kustuta" OnClick="kustutaBtn_Click" /><br />
        <asp:Label ID="VigaLbl" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
