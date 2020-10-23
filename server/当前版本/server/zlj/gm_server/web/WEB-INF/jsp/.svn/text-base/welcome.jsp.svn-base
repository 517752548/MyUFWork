<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
</head>
<body id="mainBody">
<div id="man_zone">
<div class="topnav">
<%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %>&gt;&gt;
<%= lang.readGm(GMLangConstants.WELCOMEPAGE) %>
</div>
<br/>

<table cellspacing="" class="welcome" cellpadding="20" width="600px;" align="center">
	<tr>
		<td colspan="2" class="header"><%= lang.readGm(GMLangConstants.WEL_USER_INFO) %></td>
	</tr>
	<tr>
		<td class="label"><%= lang.readGm(GMLangConstants.WEL_USER_ID)%></td>
		<td>${s.id}</td>
	</tr>
	<tr>
		<td class="label"><%= lang.readGm(GMLangConstants.WEL_USER_ROLE)%></td>
		<td>${s.role}</td>
	</tr>
	<tr>
		<td class="label"><%= lang.readGm(GMLangConstants.WEL_USER_LAST_LOGIN_TIME)%></td>
		<td><fmt:formatDate pattern="yyyy-MM-dd HH:mm:ss" value="${s.lastLogonDate}" /></td>
	</tr>
	<tr>
		<td class="label"><%= lang.readGm(GMLangConstants.WEL_COMMON_LINK)%></td>
		<td>
		<table cellspacing="5" cellpadding=5">
			<tr>
				<td nowrap=true><a href="user.do?action=init"><%= lang.readGm(GMLangConstants.WEL_USER_ACCOUNT)%></a></td>
				<td nowrap=true><a href="timeNotice.do?action=init"><%= lang.readGm(GMLangConstants.WEL_TIME_NOTICE)%></a></td>
				<td nowrap=true><a href="svrSYN.do?action=init"><%= lang.readGm(GMLangConstants.WEL_SERVER_SYN)%></a></td>
			</tr>
			<tr>
				<td nowrap=true><a href="svrStatus.do?action=init"><%= lang.readGm(GMLangConstants.SVR_STATUS)%></a></td>
                <c:if test="${s.role ne 'gm'}">
					<td nowrap=true><a href="svrMonitor.do?action=init"><%= lang.readGm(GMLangConstants.ALARM_MONITOR)%></a></td>
					<td nowrap=true><a href="accessControl.do?action=init"><%= lang.readGm(GMLangConstants.ACCESS_CONTROL)%></a></td>
				</c:if>				
				</tr>
		</table>
	</tr>
	<tr>
		<td class="label"><%= lang.readGm(GMLangConstants.WEL_SERVERS)%></td>
		<td>
		<table cellspacing="0" cellpadding="0">
			<tr><td nowrap=true>
               <c:forEach items="${serverList}" var="s">
			    <input id="sId" type="checkbox" checked=true disabled=true />
				${s.dbServerName}
                </c:forEach> </td>
			<tr>
			</tr>
		</table>
		</td>
	</tr>
</table>
</div>
</body>
</html>