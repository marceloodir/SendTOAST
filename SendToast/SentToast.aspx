<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SentToast.aspx.cs" Inherits="SendToast.SentToast" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            Entre com a URI:
        </div>
        <asp:TextBox ID="TextBoxUri" runat="server" Width="666px"></asp:TextBox>
        <br />
        <br />
        Título:<br />
        <asp:TextBox ID="TextBoxTitle" runat="server"></asp:TextBox>
        <br />
        <br />
        Subtítulo:<br />
        <asp:TextBox ID="TextBoxSubTitle" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="ButtonSendToast" runat="server" OnClick="ButtonSendToast_Click"
            Text="Enviando Notificação Toast" />
        <br />
        <br />
        Resposta:<br />
        <asp:TextBox ID="TextBoxResponse" runat="server" Height="78px" Width="199px"></asp:TextBox>
    </form>
</body>
</html>
