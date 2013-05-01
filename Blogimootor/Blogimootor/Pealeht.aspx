<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pealeht.aspx.cs" Inherits="Blogimootor.Pealeht" %>
<!--Blogimootor. Autor: Martin Arusalu-->
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Blogimootor</title>
    <link rel="stylesheet" type="text/css" href="Admin/global.css" />
</head>
<body>
    <header>
        <h1>Blogi</h1>
        <a href="Login.aspx">Logi sisse</a>
    </header>
    <form id="form1" runat="server">
            <asp:DataList ID="DataList1" runat="server">
                <ItemTemplate>
                    <asp:Panel ID="Panel1" runat="server" CssClass="postitus">
                        <asp:Label ID="HeaderLabel" runat="server" CssClass="pealkiri" Text='<%# Eval("pealkiri") %>' /><br /><br />
                        <asp:Label ID="TextLabel" runat="server" CssClass="tekst" Text='<%# Eval("tekst") %>' /><br /><br />
                        <asp:Label ID="timeWrittenLabel" runat="server" CssClass="aeg" Text='<%# Eval("aeg") %>' />
                    </asp:Panel>  
                </ItemTemplate>
            </asp:DataList>
    </form>
</body>
</html>
