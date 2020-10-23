<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>mop</title>
</head>
<body>
<form action="svrSYN.do?action=synchronize" method="post">
<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>>><%= lang.readGm(GMLangConstants.ACT_AND_NOTICE) %>>><%= lang.readGm(GMLangConstants.WEL_SERVER_SYN) %>
</div>
<br/>
<div class="nofloat" />
<table cellspacing="" class="welcome" style="width: 40%;margin-left: 1em;" cellpadding="20" >
	<tr>
		<td  class="header"><%=lang.readGm(GMLangConstants.WEL_SERVER_SYN)%><%=lang.readGm(GMLangConstants.RESULT)%></td>
	</tr>
	<tr>
		<td><textarea  cols="50" rows="20" name="content">${result}</textarea></td>
	</tr>
	<tr><td><input type="button" value="<%=lang.readGm(GMLangConstants.RETURN) %>" onclick="window.location='regionSYN.do?action=init'"/></td></tr>
</table>

</div>
</form>
</body>
</html>