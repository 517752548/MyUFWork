<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<%@ page import="java.lang.String"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
<script type="text/javascript" src="jslib/jquery.js"></script>
<script type="text/javascript">
</script>
</head>
<body>

<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>  
<a class="link" href="sql.do?action=init">SQL查询</a>
<br/>
	<c:choose>
		<c:when test="${error_msg ne null}">
			<span id="error_msg" class="error_msg">${error_msg}</span>
		</c:when>
	</c:choose>
<br/>
	<c:choose>
		<c:when test="${result ne null}">
			<a class="link" href="${result}">${result}点击下载</a>
		</c:when>
	</c:choose>		
<div style="clear: both;"></div>
<form  method="post" name="form1"
	action="sql.do?action=query" onsubmit="return true;">
<table name='tab_1' class="detail" style="width:50%;" cellspacing="0"
	cellpadding="0" border="0">
	<tbody>
		<tr>
			<td colspan="4" class="header">请输入查询语句</td>
		</tr>
        <tr>
			<td colspan="3"><textarea id="sql" cols="80" rows="5" name="sql"></textarea></td>
		</tr>
		<tr>
			<td colspan="4"  class="bottom">
				<input class="butcom" id="submit" type="submit"	value="<%= lang.readGm(GMLangConstants.COMMON_SUBMIT)%>" /> 
				<span style="padding: 10px;" />
				<input id="reset" type="reset" class="butcom" value="<%= lang.readGm(GMLangConstants.RESET)%>" />
           </td>
		</tr>
	</tbody>
</table>
</form>
</div>

<div style="clear: both;">
<font color=red size=16>注意，一些复杂语句不要频繁查询，会影响线上性能滴！</font>
<br/>
<br/><br/>职业性别分布：<br/>
select templateId, count(1) as num from t_pet_info where petType=1 group by templateId;
<br/><br/>宠物成长分布：<br/>
select growthColor, count(1) as num from t_pet_info where petType=2 group by growthColor;
</div>

<script type="text/javascript">
</script>
</body>
</html>