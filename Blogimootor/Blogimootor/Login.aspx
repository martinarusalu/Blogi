<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Blogimootor.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Blogimootor - Logi sisse</title>
    <link rel="stylesheet" type="text/css" href="Admin/global.css" />
</head>
<body>
    <header>
        <h1>Blogi</h1>
        <a href="Pealeht.aspx">Pealeht</a>
    </header>
    <form id="form1" runat="server">
        <asp:Login ID="Login1" runat="server" CssClass="login" TitleText="Logi sisse" UserNameLabelText="Kasutajanimi" PasswordLabelText="Parool" DisplayRememberMe="false" OnAuthenticate="Login1_Authenticate">
            <TextBoxStyle CssClass="lahtrid" />
            <ValidatorTextStyle CssClass="lahtrid" />
        </asp:Login>
        <asp:Label ID="vigaLbl" runat="server" Text=""></asp:Label>
        <br />
        kasutaja: martin<br />
        parool: 1234
    </form>
        
</body>
</html>
