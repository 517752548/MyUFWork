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
<c:if test="${fail eq true}">
	<script type="text/javascript">
		alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
	</script>
</c:if>
<c:if test="${exist eq true}">
	<script type="text/javascript">
		alert("<%=lang.readGm(GMLangConstants.USER_EXIST)%>");
	</script>
</c:if>

<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>
<a class="link" href="cdkeyPlans.do?action=init"><%=lang.readGm(GMLangConstants.CDKEY_PLANS)%></a>>><%=lang.readGm(GMLangConstants.NEW_ADD)%></div>
<div style="clear: both;"></div>
<form method="post" name="form1" action="cdkeyPlans.do?action=addCDKeyPlans" onsubmit="retrun is_ok();">
<table class="detail" style="width:50%;" cellspacing="0" cellpadding="0" border="0">
	<tbody>
		<tr>
			<td colspan="4" class="header"><%=lang.readGm(GMLangConstants.CDKEY_PLANS)%></td>
		</tr>
		<tr>
			<th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_PLANS_ID)%></th><td><input id="plansId" name="plansId"/></td>
			<th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_PLANS_NAME)%></th><td><input id="plansName" name="plansName"/></td>
		</tr>
		<tr>
		<th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_PLANS_START_TIME)%></th>
			<td>
				<input id="startTime" name="startTime" type="text" class="limitWidth" value="${startTime}" />
			 	<img id="startdateImg" src="jslib/jscalendar/img.gif" />
				<script	type="text/javascript" language="javascript" charset="UTF-8">
				Calendar.setup(
					{
						inputField  : "startTime",         // ID of the input field
						ifFormat    : "%Y-%m-%d",       // format of the input field
						showsTime   : true,
						timeFormat  : "24",
						button   : "startdateImg"   // ID of the button
					});
				</script>
			</td>
			<th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_PLANS_END_TIME)%></th>
		 	<td>
			 	<input id="endTime" name="endTime" type="text" class="limitWidth" value="${endTime}" />
			 	<img id="enddateImg" src="jslib/jscalendar/img.gif" />
				<script	type="text/javascript" language="javascript" charset="UTF-8">
				Calendar.setup(
						{
							inputField  : "endTime",         // ID of the input field
					      	ifFormat    : "%Y-%m-%d",       // format of the input field
					      	showsTime   : true,
					      	timeFormat  : "24",
					      	button   : "enddateImg"     // ID of the button
					    });
				</script>
			</td>
		</tr>
		<tr>
			<td colspan="4"  class="bottom">
				<input class="butcom" id="submit" type="submit"	value="<%= lang.readGm(GMLangConstants.COMMON_SUBMIT)%>" /> 
				<span style="padding: 10px;" />
				<input id="reset" type="reset" class="butcom" value="<%= lang.readGm(GMLangConstants.RESET)%>" />
            	<span style="padding: 10px;" />
            	<input id="return" type="button" class="butcom"	value="<%= lang.readGm(GMLangConstants.RETURN)%>"  onclick="javaScript:window.location='cdkeyPlans.do?action=init';"/>
           </td>
		</tr>
	</tbody>
</table>
</form>
</div>
<script type="text/javascript">
function is_ok(){
	alert("1111") ;
	var plansId = $.trim($("#plansId").val());
	if(is_null(plansId)==true){
		alert('<%= lang.readGm(GMLangConstants.CDKEY_PLANS_ID_NOT_NULL)%>');
		$("#plansId").focus();
		return false;
	}
	if(plansId.length>9){
		alert('<%= lang.readGm(GMLangConstants.TOO_LONG)%>');
		$("#plansId").focus();
		return false;
	}
	if(is_int(plansId)==false){
		alert("<%= lang.readGm(GMLangConstants.CDKEY_PLANS_ID_IS_INT)%>");
		$("#plansId").focus();
		return false;
	}
	
	var plansName=$.trim($("#plansName").val());
	if(is_null(plansName)==true){
		alert('<%= lang.readGm(GMLangConstants.CDKEY_PLANS_NAME_NOT_NULL)%>');
		$("#plansName").focus();
		return false;
	}

	var startTime = $.trim($("#startTime").val());
	var endTime = $.trim($("#endTime").val());
	
	if(is_null(startTime)==true){
		alert('<%= lang.readGm(GMLangConstants.CDKEY_PLANS_START_TIME_NOT_NULL)%>');
		$("#startTime").focus();
		return false;
	}
	
	if(is_null(endTime)==true){
		alert('<%= lang.readGm(GMLangConstants.CDKEY_PLANS_END_TIME_NOT_NULL)%>');
		$("#endTime").focus();
		return false;
	}
	
	if(startTime >= endTime) {
		alert("<%= lang.readGm(GMLangConstants.CDKEY_CREATE_EFFECTIVE_TIME_ERROR)%>");
		return false;
	}
	
	// 同步后台数据校验
	if(!asynDataCheck()){
		return false;
	}else{
		alert("DATACHECK SUCCES");
	}
	 
	// 设置提交按钮不可点
	$("#submit").attr("disabled",true);
	return true;
}
//校验同步数据
function asynDataCheck(){
	var plansId = $.trim($("#plansId").val());
	var flag =true;
	 $.ajaxSettings.async= false;
	 $.post("cdkeyPlans.do?action=checkData",{plansId:plansId},function(info){
		 info = $.trim(info);
		 if(info!="ok"){
			 alert(info);
			 flag = false;
		 }
	 });
	$.ajaxSettings.async= true;
	return flag;
}
</script>
</body>
</html>