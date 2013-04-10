<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SinaTime.aspx.cs" Inherits="me" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人微博时间轴</title>
    <script src="time/time/js/jquery.js" type="text/javascript"></script>
    <script src="time/time/js/main.js" type="text/javascript"></script>
    <link href="time/time/css/history.css" rel="stylesheet" type="text/css" />
</head>
<body>
   <form id="Form1" runat="server">
   <!-- 代码 开始 -->
<div class="head-warp">
  <div class="head">
        <div class="nav-box">
          <ul>
              <li class="cur" style="text-align:center; font-size:62px; font-family:'微软雅黑', '宋体';">个人新浪微博时间轴</li>
          </ul>
        </div>
  </div>
</div>
<div class="main">
  <div class="history">
  <!-- 此处添加repeater和item等 -->
  <asp:Repeater ID="rptAll" runat="server" onitemdatabound="rptAll_ItemDataBound1">
  <ItemTemplate>
 
 
    <div class="history-date">
      <ul>
      	<h2 class="first"><a href="#nogo"><%#Eval("Year") %></a></h2>
        <asp:HiddenField id="year" runat="server" Value='<%# Eval("Year") %>' />
       
     <asp:Repeater ID="rptA" runat="server">
        <ItemTemplate>
         <li class="green">
          <h3><%# Eval("SendTime") %><span><%# Eval("YearYear") %></span></h3>
          <dl>
            <dt><%# Eval("Content") %>
	</dt>
          </dl>
        </li>  
        </ItemTemplate>     
        </asp:Repeater>
      </ul>
    </div>
    </ItemTemplate>
  </asp:Repeater>
   <!-- 结束-->
  </div>
</div>

</form>
</body>
</html>
