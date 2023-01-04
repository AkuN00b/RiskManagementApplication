<%@ Page Title="" Language="C#" MasterPageFile="~/Layouts/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RiskManagementApplication.Views.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login | RiskManagementApplication</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <img class="wave" src="../Assets/Login/img/wave.png">

	<div class="container">
		<div class="img">
			<img src="../Assets/Login/img/bg.svg">
		</div>

		<div class="login-content">
			<form action="#" method="post" runat="server">
				<img src="../Assets/Login/img/avatar.svg">
				<h2 class="title">Welcome</h2>

           		<div class="input-div one">
           		   <div class="i">
           		   		<i class="fas fa-user"></i>
           		   </div>
           		   <div class="div">
           		   		<h5>Username</h5>
                        <asp:TextBox runat="server" ID="username" CssClass="input" />
           		   </div>
           		</div>

           		<div class="input-div pass">
           		   <div class="i">
           		    	<i class="fas fa-lock"></i>
           		   </div>
           		   <div class="div">
           		    	<h5>Password</h5>
                        <asp:TextBox runat="server" TextMode="Password" ID="password" CssClass="input" />
            	   </div>
            	</div>

                <asp:Button Text="Login" runat="server" CssClass="btn" id="btnLogin" OnClientClick="validateEmpty()" OnClick="btnLogin_Click" />
            </form>
        </div>
    </div>
    <script type="text/javascript" src="../Assets/Login/js/main.js"></script>
</asp:Content>
