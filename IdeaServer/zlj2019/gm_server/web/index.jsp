<%@ page contentType="text/html;charset=utf-8" language="java"%>
<%@ include file="common/taglibs.jsp"%>
<%@ page
	import="org.springframework.web.context.support.WebApplicationContextUtils"%>
<%@ page import="org.springframework.web.context.WebApplicationContext"%>
<%@ page import="com.imop.lj.gm.service.db.DBFactoryService"%>
<%@ page import="com.imop.lj.gm.dto.DBServer"%>
<%@ page import="com.imop.lj.gm.dto.Region"%>
<%@ page import="java.util.List"%>
<%@ page import="java.util.Date"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html"
	content="text/html; charset=utf-8" />
<title><%=lang.readGm(GMLangConstants.LZR_GM)%></title>
	<link rel="stylesheet" type="text/css" href="css/${lan}/index.css" />
<script type="text/javascript">
	$().ready(function() {
		var regionID = $("#region_id").val();
		$.post("login.htm?action=index", {
			regionID : regionID
		}, function(info) {
			$("#loginForm").html(info);
		})
	});
	function switchRegion() {
		var regionID = $("#region_id").val();
		$.post("login.htm?action=index", {
			regionID : regionID
		}, function(info) {
			$("#loginForm").html(info);
		})

	}
</script>
</head>
<body id="type-f">
	<c:if test="${noUser eq true}">
		<script type="text/javascript">
			alert("<%=lang.readGm(GMLangConstants.JS_NO_USER)%>");
		</script>
	</c:if>
	<c:if test="${noRight eq true}">
		<script type="text/javascript">
			alert("<%=lang.readGm(GMLangConstants.USER_NO_RIGHT)%>");
		</script>
	</c:if>
	<div id="loginForm"></div>
</body>
</html>
