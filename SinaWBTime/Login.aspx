<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>微博登陆</title>
		<link rel="stylesheet" type="text/css" href="css/reset.css" />
	<link rel="stylesheet" type="text/css" href="css/stylesheet.css" />
	<script type="text/javascript" src="scripts/jquery-1.7.2.js"></script>

</head>
<body>
    <form id="form1" runat="server">
	<div id="header">
		<div id="header_wrap" class="row">
			<p id="logo">
				<a href="#"><span>个人微博时间轴</span>测试版</a>
			</p>
			
		</div>
	</div>
	<div id="content_wrap" class="row">
		<div id="content_left_wrap">
			<div class="panel">
				<h2 class="title">用户登录</h2>
				<div class="box">
				<asp:HyperLink id="authUrl" runat="server">
				<img src="images/240.png" alt="点击此处进行授权"/>
			</asp:HyperLink>
				</div>
			</div>
			<div class="panel">
				<h2 class="title">联系我：jshiying@gmail.com</h2>
				<div class="box">
					<ul>
						<li>CopyRight @2013-2020 版权所有</li>
						<li>开发者：蒋世银</li>
						<li>单位：<a href="http://www.las.ac.cn">中科院国家科学图书馆</a></li>
					</ul>
				</div>
			</div>
		</div>
		
	</div>
    </form>
</body>
</html>
