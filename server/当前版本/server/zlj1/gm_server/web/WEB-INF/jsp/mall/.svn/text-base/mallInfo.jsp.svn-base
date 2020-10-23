<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/logCommon.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>mop</title>
<script type="text/javascript">
	
</script>
</head>
<body>
	<div class="topnav">
		<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>><%=lang.readGm(GMLangConstants.GM_MALL)%>
	</div>

	<c:forEach items="${error_msg}" var="msg">
		<span class="error_msg">${msg}</span><br/>
	</c:forEach>

	<table class="detail" cellspacing="0" cellpadding="0" border="0">
		<tbody>
			<tr>
				<th>&nbsp;<%=lang.readGm(GMLangConstants.ID)%></th>
				<th>&nbsp;<%=lang.readGm(GMLangConstants.MALL_QUEUE_CONFIG)%></th>
				<th>&nbsp;<%=lang.readGm(GMLangConstants.MALL_START_TIME_CONFIG)%></th>
				<th>&nbsp;<%=lang.readGm(GMLangConstants.MALL_CURR_QUEUE_UUID)%></th>
				<th>&nbsp;<%=lang.readGm(GMLangConstants.MALL_CURR_START_TIME)%></th>
				<th>&nbsp;<%=lang.readGm(GMLangConstants.MALL_CURR_QUEUE_ID)%></th>
				<th>&nbsp;<%=lang.readGm(GMLangConstants.MALL_CURR_QUEUE)%></th>
				<th>&nbsp;<%=lang.readGm(GMLangConstants.MALL_STOCK)%></th>
				<th>&nbsp;<%=lang.readGm(GMLangConstants.MALL_UPDATE_TIME)%></th>
				
				<th>&nbsp;<%=lang.readGm(GMLangConstants.MALL_CHANGE)%> <img
					class="pointer"
					title="<%=lang.readGm(GMLangConstants.MALL_CHANGE)%>"
					src="images/add.gif"
					onclick="javaScript:window.location='mall.do?action=changeMallInit'" />
				</th>
			</tr>
			<c:forEach items="${mallInfoList}" var="mallInfoVo">
				<tr>
					<td>&nbsp;${mallInfoVo.mall.id}</td>
					<td>&nbsp;${mallInfoVo.mall.queueConfig}</td>
					<td>&nbsp;${mallInfoVo.startConfigTime}</td>
					<td>&nbsp;${mallInfoVo.mall.currQueueUUID}</td>
					<td>&nbsp;${mallInfoVo.currStartTime}</td>
					<td>&nbsp;${mallInfoVo.mall.currQueueId}</td>
					<td>&nbsp;${mallInfoVo.mall.currQueueConfig}</td>
					<td>&nbsp;${mallInfoVo.mall.stockPack}</td>
					<td>&nbsp;${mallInfoVo.updateTime}</td>
				</tr>
			</c:forEach>
			<tr>
				<td height="30" colspan="13"
					style="border-bottom: 0px; width: 100%;">
					<div id="num_style"></div>
				</td>
			</tr>
		</tbody>
	</table>
</body>
</html>