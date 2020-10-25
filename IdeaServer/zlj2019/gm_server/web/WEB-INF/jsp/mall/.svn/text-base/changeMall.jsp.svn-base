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
<body>
	<div id="man_zone">
		<div class="topnav">
			<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>
			<a class="link" href="userPrize.do?action=init"><%=lang.readGm(GMLangConstants.GM_MALL)%></a>>><%=lang.readGm(GMLangConstants.MALL_CHANGE)%></div>
		<div style="clear: both;"></div>
		<form method="post" name="form1" action="mall.do?action=changeMall"
			onsubmit="return true;">
			<table name='tab_1' class="detail" style="width: 50%;"
				cellspacing="0" cellpadding="0" border="0">
				<tbody>
					<tr>
						<td colspan="4" class="header"><%=lang.readGm(GMLangConstants.GM_MALL)%></td>
					</tr>

					<tr>
						<td class="label"><%=lang.readGm(GMLangConstants.MALL_START_TIME_CONFIG)%></td>
						<td class="label"><input id="startTime" name="startTime" /></td>
						<td class="label"><%=lang.readGm(GMLangConstants.MALL_TIME_FMT)%></td>
					</tr>
					<tr>
						<td class="label"><%=lang.readGm(GMLangConstants.MALL_QUEUE_CONFIG)%></td>
						<td class="label"><input id="queue" name="queue" /></td>
						<td class="label"><%=lang.readGm(GMLangConstants.MALL_QUEUE_FMT)%></td>
					</tr>
					<tr>
						<td class="label"><%=lang.readGm(GMLangConstants.COMMON_SERVER)%></td>
						<td><c:forEach items="${serverList}" var="s">
								<input id="sId" name="sId" type="checkbox" value="${s.id}" />${s.dbServerName}
                			</c:forEach>
                		</td>
					</tr>
					<tr>
						<td colspan="4" class="bottom"><input class="butcom"
							id="submit" type="submit"
							value="<%=lang.readGm(GMLangConstants.COMMON_SUBMIT)%>" /> <span
							style="padding: 10px;" /> <input id="reset" type="reset"
							class="butcom" value="<%=lang.readGm(GMLangConstants.RESET)%>" />
							<span style="padding: 10px;" /> <input id="return" type="button"
							class="butcom" value="<%=lang.readGm(GMLangConstants.RETURN)%>"
							onclick="javaScript:window.location='mall.do?action=init';" /></td>
					</tr>
				</tbody>
			</table>
		</form>
	</div>
</body>
</html>