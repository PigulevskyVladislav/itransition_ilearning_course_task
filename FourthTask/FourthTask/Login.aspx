<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FourthTask.Login" %>

<!DOCTYPE html>

<link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet">
<html>
<head runat="server">
    <title></title>
</head>
<body>

<form id="LoginForm" class="form-group" runat="server">
    <div class="container" style="text-align: center;">
        <asp:Login style="width: 400px; margin-left: auto; margin-right:auto;" ID="PersonLogin" runat="server" DestinationPageUrl="~/Default.aspx" TextLayout="TextOnTop" Width="550px">
            <TextBoxStyle CssClass="form-control" />
            <LoginButtonStyle CssClass="btn btn-default" />
            <CheckBoxStyle CssClass="form-check" />
        </asp:Login>
        <div >
            <p class="h5 pt-5">Don't have an account yet? <a href="Register.aspx">Register</a>.</p>
        </div>
   </div>
</form>
</body>
</html>
