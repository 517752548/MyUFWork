<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
</script>
</head>
<body>
<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>>><%= lang.readGm(GMLangConstants.SYN_CLEAR) %>
</div>
<div class="nofloat" />
<form id="timeNotice" name="timeNotice" method="post" action="timeNotice.do?action=addTimeNotice" onsubmit="return is_ok();">
<c:if test="${s1 ne 1}"><table name='tab_1' class="detail no_bottom" style="width:30%;" cellspacing="0"
	cellpadding="0" border="0">
	<tbody>
		<tr>
			<td colspan="4" class="header">&nbsp;<%=lang.readGm(GMLangConstants.NEWSVR_SYN)%></td>
		</tr>
		<tr>
			<td class="label" >&nbsp;<%= lang.readGm(GMLangConstants.NEWSVR_SYN)%>:<span class="red">${svrName}</span></td>
			<td align="center">&nbsp;
			<input type="button" class="butcom" id="newSvrSyn" onclick="javascript:synSvr()"
			value="<%= lang.readGm(GMLangConstants.NEWSVR_SYN)%>"/></td>
		</tr>
	</tbody>
</table>
</c:if>
<table name='tab_2' class="detail no_bottom" style="width:30%;" cellspacing="0"
	cellpadding="0" border="0">
	<tbody>
		<tr>
			<td colspan="4" class="header">&nbsp;<%=lang.readGm(GMLangConstants.NEWSVR_CLEAR)%></td>
		</tr>
		<tr>
			<td class="label" >&nbsp;<%= lang.readGm(GMLangConstants.NEWSVR_CLEAR)%>:<span class="red">${svrName}</span></td>
			<td align="center">&nbsp;
			<input type="button" class="butcom" id="newSvrClear" onclick="javascript:clearSvr()"
			value="<%= lang.readGm(GMLangConstants.NEWSVR_CLEAR)%>"/></td>
		</tr>
	</tbody>
</table>
</form>
</div>
<c:if test="${cmd eq true}">
<script type="text/javascript">
	alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
</script>
</c:if>
<c:if test="${cmd eq false}">
<script type="text/javascript">
	alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
</script>
</c:if>
<c:if test="${canClear eq false}">
<script type="text/javascript">
	alert("<%=lang.readGm(GMLangConstants.NEWSVR_CLEAR_ALERT)%>");
</script>
</c:if>
<c:if test="${wsActive eq true}">
<script type="text/javascript">
	alert("<%=lang.readGm(GMLangConstants.WS_ACTIVE)%>");
</script>
</c:if>
<script type="text/javascript">
function clearSvr(){
	var con=confirm("<%=lang.readGm(GMLangConstants.CONFIRM_CLEAR)%>${svrName}<%=lang.readGm(GMLangConstants.MA)%>?");
	if(con){
		window.location='newSvrClear.do?action=newSvrClear';
	}
}
function synSvr(){
	var con=confirm("<%=lang.readGm(GMLangConstants.CONFIRM_SYN)%>${svrName}<%=lang.readGm(GMLangConstants.MA)%>?");
	if(con){
		window.location='newSvrClear.do?action=newSvrSYN';
	}
}
</script>
</body>

</html>