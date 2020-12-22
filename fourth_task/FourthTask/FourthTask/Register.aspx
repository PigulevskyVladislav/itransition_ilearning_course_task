<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FourthTask.Register" %>

<!DOCTYPE html>

<link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="RegisterForm" class="form-group" runat="server">
        <div class="container">
            <h1>Register</h1>
            <p>Please fill in this form to create an account.</p>
            <hr />

            <label><b>Email</b></label>
            <asp:TextBox ID="EmailTextBox" class="form-control" runat="server"></asp:TextBox>

            <label class="h5 pt-5"><b>Password</b></label>
            <asp:TextBox ID="PasswordTextBox" class="form-control" runat="server"></asp:TextBox>

            <label class="h5 pt-5"><b>Repeat Password</b></label>
            <asp:TextBox ID="RepeatPasswordTextBox" class="form-control" runat="server"></asp:TextBox>

            <label class="h5 pt-5"><b>Name</b></label>
            <asp:TextBox ID="NameTextBox" class="form-control" runat="server"></asp:TextBox>
            <hr />

            <asp:Button ID="SubmitButton" class="btn btn-default" runat="server" Text="Register" OnClick="SubmitButton_Click" />

            <div >
                <p class="h5 pt-5">Already have an account? <a href="Login.aspx">Sign in</a>.</p>
            </div>
        </div> 
    </form>
</body>
</html>
