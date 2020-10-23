<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<%@ page import="com.imop.lj.gm.config.GmConfig"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
<script type="text/javascript" src="jslib/jquery.js"></script>
</head>
<body onload="hiCurrency()">
<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>
<a class="link" href="userPrize.do?action=init"><%=lang.readGm(GMLangConstants.STATISTICS_INFO)%></a>
</div>
<div class="nofloat"></div>
 <c:forEach items="${infoList}" var="info" varStatus="status">
 	<c:if test="${status.index %4 eq 0}"><div class="nofloat"></div></c:if>
 	<table class="detail no_bottom"  style="width:20%;margin-left:5px;float: left" cellspacing="0" cellpadding="0" border="0">
 	<tbody>
		<tr>
			<c:choose>
				<c:when	test="${info.state) eq 'true'}">
				<td colspan="2" class="header">
					${info.svrName}
				</td>
				</c:when>
				<c:otherwise>
  	     	  	<td colspan="2" class="header" style="background-color: red">
					${info.svrName}
				</td>
  	     		</c:otherwise>
			</c:choose> 
		</tr>
		<tr>
			<td>&nbsp;<%=lang.readGm(GMLangConstants.REGISTER_NUM)%></td>
			<td>${info.registerNum}</td>
		</tr>
		<tr>
			<td>&nbsp;<%=lang.readGm(GMLangConstants.CREATE_ROLE_NUM)%></td>
			<td>${info.createRoleNum}</td>
		</tr>
		<tr>
			<td>&nbsp;<%=lang.readGm(GMLangConstants.CHARGE_ROLE_NUM)%></td>
			<td>${info.chargeRoleNum}</td>
		</tr>
		<tr>
			<td>&nbsp;<%=lang.readGm(GMLangConstants.TOTAL_CHARGE)%></td>
			<td>${info.totalCharge}</td>
		</tr>
		<tr>
			<td>&nbsp;<%=lang.readGm(GMLangConstants.TODAY_CHARGE)%></td>
			<td>${info.todayCharge}</td>
		</tr>
		<tr>
			<td>&nbsp;<%=lang.readGm(GMLangConstants.WEEK_CHARGE)%></td>
			<td>${info.weekCharge}</td>
		</tr>
		<tr>
			<td>&nbsp;<%=lang.readGm(GMLangConstants.MONTH_CHARGE)%></td>
			<td>${info.monthCharge}</td>
		</tr>
		<tr>
			<td>&nbsp;<%=lang.readGm(GMLangConstants.ONLINE_PLAYER_SIZE)%></td>
			<td>${info.onlinePlayerSize}</td>
		</tr>
		<tr>
		</tr>
		
		<tr>
			<td>&nbsp;<%=lang.readGm(GMLangConstants.CREATE_DIV_REGISTER)%></td>
			<td>${info.cdr}</td>
		</tr>
		
		<tr>
			<td>&nbsp;<%=lang.readGm(GMLangConstants.CHARGE_DIV_CREATE)%></td>
			<td>${info.cdc}</td>
		</tr>
		
		<tr>
			<td>&nbsp;<%=lang.readGm(GMLangConstants.ARUP)%></td>
			<td>${info.arup}</td>
		</tr>
	</tbody>
</table>
</c:forEach>
</div>
</body>
</html>