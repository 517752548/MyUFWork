<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<link rel="stylesheet" type="text/css"
	href="jslib/jsTimePicker/timepicker.css" />
<script type="text/javascript" src="jslib/jsTimePicker/timepicker.js"></script>
<title></title>
<script type="text/javascript">
	
   $().ready(function(){
	   
   });
   function doExport(){
		  var cdkeyPlansId = $("#cdkeyPlansId").val();
		  var cdkeyGiftId = $("#cdkeyGiftId").val();
		  var cdkeyGroupId =$("#cdkeyGroupId").val();
		  if(datacheck()){
			  $.ajaxSettings.async= false;
				 $.post("cdkey.do?action=doExport",{cdkeyPlansId:cdkeyPlansId,cdkeyGiftId:cdkeyGiftId,cdkeyGroupId:cdkeyGroupId},function(info){
					 info = $.trim(info);
					 if(info!="ok"){
						 alert(info);
					 }else
					 {
						var download = $("#download");
						download.attr("disabled",false);
						download.attr("class", "butcom");
						alert("<%=lang.readGm(GMLangConstants.DOWNLOAD_FILE_HINT)%>");
					 }
				 });
				$.ajaxSettings.async= true;
		  }
		  }
	function datacheck(){
	   	if(!validEndTime())
	   	{
		   	return false;
		 }
		return true;
	}
   function validEndTime(){
	    var cdkeyPlansId = $.trim($("#cdkeyPlansId").val());
		var cdkeyGiftId = $.trim($("#cdkeyGiftId").val());
		var cdkeyGroupId = $.trim($("#cdkeyGroupId").val());
		
		if(is_null(cdkeyPlansId)==true)
		{
			alert('<%=lang.readGm(GMLangConstants.CDKEY_PLANS_ID_CAN_NOT_NULL)%>');
			$("#cdkeyPlansId").focus();
			return false;
		}
		if(is_null(cdkeyGiftId)==true){
			alert('<%=lang.readGm(GMLangConstants.CDKEY_GIFT_ID_CAN_NOT_NULL)%>');
			$("#cdkeyGiftId").focus();
			return false;
		}
		if(is_null(cdkeyGroupId)==true){
			$("#cdkeyGroupId").focus();
			return false;
		}
		return true;
	}
</script>
</head>
<body>
<div id="man_zone">
<div class="topnav">
<a class="link"	href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>&gt;&gt;
<%= lang.readGm(GMLangConstants.CDKEY_EXPORT) %>&gt;&gt;
<%=lang.readGm((Integer) m.get("LogType").get((String) request.getAttribute("logType")))%>
</div>

<div id="nav">
	<ul>
		<li id="man_nav_1" class="bg_image_onclick"><%=lang.readGm(GMLangConstants.EXPORT)%>
		</li>
	</ul>
</div>
			
<div id="sub_info">
	&nbsp;&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_PLANS_ID)%><input id="cdkeyPlansId" type="text" class="limitWidth"/>
	&nbsp;&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_GIFT_ID)%>：<input id="cdkeyGiftId" type="text" class="limitWidth" />
	&nbsp;&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_GROUP_ID)%><input id="cdkeyGroupId" type="text" class="limitWidth"/>
	&mdash;&mdash;
	<input id="export" class="butcom" name="export" type="button" style="margin-left: 1em;"	value="<%=lang.readGm(GMLangConstants.EXPORT)%>"
		onclick="javaScript:doExport()" />
	<input id="download" name="download" type="button" style="margin-left: 1em;"
		value="<%=lang.readGm(GMLangConstants.DOWNLOAD)%>"
		onclick="javaScript:window.location='result.xls'" disabled="disabled"/>
</div>
<div>
	<p>
		<br></br>
	</p>
	&nbsp;&nbsp;<font color="#FF0000"><%=lang.readGm(GMLangConstants.EXPORT_WARNING)%></font>
</div>
</div>
</body>
</html>