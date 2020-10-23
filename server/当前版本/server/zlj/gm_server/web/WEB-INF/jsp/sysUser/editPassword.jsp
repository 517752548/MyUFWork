<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
<script type="text/javascript" src="jslib/jquery.js"></script>
</head>
<body>
<c:if test="${savePassword eq true}">
	<script type="text/javascript">
		alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
		window.location = "sysUser.do?action=init";
	</script>
</c:if>
<c:if test="${savePassword eq false}">
	<script type="text/javascript">
		alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
	</script>
</c:if>
<c:if test="${psError eq true}">
	<script type="text/javascript">
		alert("<%=lang.readGm(GMLangConstants.OLDPS_NOT_VALID)%>");
	</script>
</c:if>
<div id="man_zone">
<div class="topnav"><a href="homePage.do?action=welcome">
<%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>&gt;&gt;
<%= lang.readGm(GMLangConstants.SYS) %>&gt;&gt;
<%=lang.readGm(GMLangConstants.EDIT)%><%=lang.readGm(GMLangConstants.COMMON_PASSWORD)%>
</div>

<div id="nav">
<ul>
	<li id="man_nav_1" class="bg_image_onclick"><%=lang.readGm(GMLangConstants.EDIT)%><%=lang.readGm(GMLangConstants.COMMON_PASSWORD)%></li>
</ul>
</div>

<div id="sub_info">
</div>

<form  method="post"
	action="sysUser.do?action=savePassword&id=${id}" onsubmit="return is_ok();">
<table id='tab_1' class="detail" style="width:50%;" cellspacing="0"
	cellpadding="0" border="0">
	<tbody>
		<tr>
			
			<th colspan="2"><%=lang.readGm(GMLangConstants.EDIT)%><%=lang.readGm(GMLangConstants.COMMON_PASSWORD)%></th>
		</tr>
		<tr>
			<td class="label"><%=lang.readGm(GMLangConstants.OLD)%><%=lang.readGm(GMLangConstants.COMMON_PASSWORD)%></td>
			<td ><input id="oldPassword" type="password" name="oldPassword" /></td>
		</tr>
		<tr>
			<td class="label"><%=lang.readGm(GMLangConstants.NEW)%><%=lang.readGm(GMLangConstants.COMMON_PASSWORD)%>
			</td>
			<td><input id="newPassword" type="password" name="newPassword" /></td>
		</tr>
		<tr>
			<td class="label"><%=lang.readGm(GMLangConstants.CONFIRM)%><%=lang.readGm(GMLangConstants.NEW)%><%=lang.readGm(GMLangConstants.COMMON_PASSWORD)%>
			</td>
			<td><input type="password" id="confirmPassword" /></td>
		</tr>
		<tr>
			<td colspan="4" align="right"><input
				id="submit" type="submit" class="butcom"
				value="<%= lang.readGm(GMLangConstants.COMMON_SUBMIT)%>" />
				&nbsp;&nbsp;<input id="reset" type="reset" class="butcom"
				value="<%= lang.readGm(GMLangConstants.RESET)%>" />&nbsp;&nbsp;
			 </td>
		</tr>
	</tbody>
</table>
</form>
</div>
<script type="text/javascript" language="javascript">
function is_ok(){
	if(is_null($("#oldPassword").val())==true){
		alert('<%= lang.readGm(GMLangConstants.OLDPS_NOT_NULL)%>');
		$("#oldPassword").focus();
		return false;
	}
	if(is_null($("#newPassword").val())==true){
		alert('<%= lang.readGm(GMLangConstants.NEWPS_NOT_NULL)%>');
		$("#newPassword").focus();
		return false;
	}
	if($("#newPassword").val()!=$("#confirmPassword").val()){
		alert('<%= lang.readGm(GMLangConstants.PS_DIFF)%>');
		$("#confirmPassword").focus();
		return false;
	}
		return true;
	}
</script>
</body>
</html>