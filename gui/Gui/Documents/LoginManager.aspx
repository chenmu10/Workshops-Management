<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginManager.aspx.cs" Inherits="gui.Gui.Documents.LoginManager" %>

<%@ Register src="nav.ascx" tagname="nav" tagprefix="uc1" %>

<!DOCTYPE html>
<html lang="en">

<head>
	<meta charset="utf-8">
	<title>כניסת ניהול</title>

	<!-- Google Fonts -->
	<link href='https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700|Lato:400,100,300,700,900' rel='stylesheet' type='text/css'>
    <link href="../../css/animate.css" rel="stylesheet" />
    <link href="../../css/Loginstyle.css" rel="stylesheet" />
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
</head>

<body >
	<div class="container">
        <form runat="server">
        
		<div class="top">
			<h1 id="title" class="hidden"><span id="logo">ממשק ניהול</span></h1>
		    <uc1:nav ID="nav1" runat="server" />
		</div>
        
		<div runat="server" id="divBox" class="login-box animated fadeInUp">
			<div class="box-header">
				<h2 style="color:white">התחברות</h2>
			</div>
			<asp:label runat="server" ID="usernameLabel" for="username">שם משתמש</asp:label>
			<br/>
			<asp:TextBox runat="server" ID="username"></asp:TextBox>
			<br/>
			<asp:label runat="server" ID="passwordLabel"  for="password">סיסמא</asp:label>
			<br/>
			<asp:TextBox runat="server" ID="password"></asp:TextBox>
			<br/>
            <asp:Button runat="server" CssClass="mybtn1212" ID="submitButton" Text="כניסה" OnClick="Login_Click"  ForeColor="White" />
            <br/>
           <asp:Label runat="server" ID="msg"></asp:Label>
			<br/>
		</div>
            </form>
	</div>
</body>

<script>
	$(document).ready(function () {
    	$('#logo').addClass('animated fadeInDown');
    	$("input:text:visible:first").focus();
	});
	$('#username').focus(function() {
		$('label[for="username"]').addClass('selected');
	});
	$('#username').blur(function() {
		$('label[for="username"]').removeClass('selected');
	});
	$('#password').focus(function() {
		$('label[for="password"]').addClass('selected');
	});
	$('#password').blur(function() {
		$('label[for="password"]').removeClass('selected');
	});
</script>

</html>
