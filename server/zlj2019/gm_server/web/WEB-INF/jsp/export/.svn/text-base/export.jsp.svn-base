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
Request = {
	QueryString : function(key){
	var svalue = window.location.search.match(new RegExp("[\?\&]"+key+"=([^\&]*)(\&?)","i"));
	return svalue ? svalue[1] : svalue;
}
};
   $().ready(function(){
	   
   });
   function doExport(){
	  	  var logType=Request.QueryString("logType");
		  var roleID = $("#roleID").val();
		  var date = $("#date").val();
		  var startTime=$("#startTime").val();
		  var date1 = $("#date1").val();
		  var endTime=$("#endTime").val();
		  var reason=$("#reason").val();
		  if(datacheck()){
			  $.ajaxSettings.async= false;
				 $.post("export.do?action=doExport",{logType:logType,roleID:roleID,date:date,time:startTime,date1:date1,time1:endTime,reason:reason},function(info){
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
	    var date = $.trim($("#date").val());
		var date1 = $.trim($("#date1").val());
		var startTime = $.trim($("#startTime").val());
		var endTime = $.trim($("#endTime").val());
		if(is_null(endTime)==true){
			alert('<%=lang.readGm(GMLangConstants.ENDTIME_NOT_NULL)%>');
			$("#endTime").focus();
			return false;
		}
		if(is_null(date1)==true)
		{
			alert('<%=lang.readGm(GMLangConstants.ENDTIME_NOT_NULL)%>');
			$("#date1").focus();
			return false;
		}
		if(is_null(startTime)==true){
			alert('<%=lang.readGm(GMLangConstants.STARTTIME_NOT_NULL)%>');
			$("#startTime").focus();
			return false;
		}
		if(is_null(date)==true){
			alert('<%=lang.readGm(GMLangConstants.STARTTIME_NOT_NULL)%>');
			$("#date").focus();
			return false;
		}
		if(validTime(endTime)==false){
			alert('<%=lang.readGm(GMLangConstants.ENDTTIME_NOT_CORRECT)%>');
			$("#endTime").focus();
			return false;
		}
		if(validDate(date1)==false)
		{
			alert('<%=lang.readGm(GMLangConstants.ENDTTIME_NOT_CORRECT)%>');
			$("#date1").focus();
			return false;
		}
		if(validTime(startTime)==false){
			alert('<%=lang.readGm(GMLangConstants.STARTTTIME_NOT_CORRECT)%>');
			$("#startTime").focus();
			return false;
		}
		if(validDate(date)==false){
			alert('<%=lang.readGm(GMLangConstants.STARTTTIME_NOT_CORRECT)%>');
			$("#date").focus();
			return false;
		}
		if(date1<date)
		{
			alert('<%=lang.readGm(GMLangConstants.END_MORE_START)%>');
			$("#date1").focus();
			return false;
		}
		else if(date1==date)
		{
			if(endTime<=startTime){
				alert('<%=lang.readGm(GMLangConstants.END_MORE_START)%>');
				$("#endTime").focus();
				return false;
			}
		}
		return true;
	}
</script>
</head>
<body>
<div id="man_zone">
			<div class="topnav"><a class="link"
				href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>&gt;&gt;
				<%= lang.readGm(GMLangConstants.GAME_LOG) %>&gt;&gt;
			<%=lang.readGm((Integer) m.get("LogType").get(
							(String) request.getAttribute("logType")))%>
			</div>

			<div id="nav">
				<ul>
					<li id="man_nav_1" class="bg_image_onclick"><%=lang.readGm(GMLangConstants.EXPORT)%>
					</li>
				</ul>
			</div>
			
			<div id="sub_info">
				&nbsp;&nbsp;<%=lang.readGm(GMLangConstants.ROLE_ID)%><input
	id="roleID" type="text" class="limitWidth"/>
				&nbsp;&nbsp;<span><%=lang.readGm(GMLangConstants.START_TIME)%>：
<input id="date" name="date" type="text" class="limitWidth"
	value="${date}" /> <img id="dateImg" src="jslib/jscalendar/img.gif" />
<script type="text/javascript" language="javascript">
Calendar.setup(
	    {
	      inputField  : "date",         // ID of the input field
	      ifFormat    :  "%Y-%m-%d",       // format of the input field
	      showsTime   :  false,
	      timeFormat  :  "24",
	      onClose  :  function (cal){
		              if(cal.date>new Date()){
		            	  alert("<%=lang.readGm(GMLangConstants.DATE_ERR)%>");
			             }
	    	          cal.hide();
                     },
	      button   : "dateImg"     // ID of the button
	    }
    );

</script></span><span><input id="startTime" name="startTime"
	value="${startTime}" class="time_gap" /> <img id="startTimeImg"
	src="jslib/jscalendar/img.gif" /> <script type="text/javascript"
	language="javascript">
$('#startTimeImg').timepicker({
    defaultTime: new Date()
});
</script></span>&mdash;&mdash;
<span><%=lang.readGm(GMLangConstants.END_TIME)%>：
<input id="date1" name="date1" type="text"
	class="limitWidth" value="${date1}" /> <img id="dateImg1"
	src="jslib/jscalendar/img.gif" /> <script type="text/javascript"
	language="javascript">
	Calendar.setup(
		    {
		      inputField  : "date1",         // ID of the input field
		      ifFormat    :  "%Y-%m-%d",       // format of the input field
		      showsTime   :  false,
		      timeFormat  :  "24",
		      onClose  :  function (cal){
			              if(cal.date>new Date()){
			            	  alert("<%=lang.readGm(GMLangConstants.DATE_ERR)%>");
				             }
		    	          cal.hide();
	                     },
		      button   : "dateImg1"     // ID of the button
		    }
	    );
</script></span> <span><input id="endTime" name="endTime" value="${endTime}"
	class="time_gap" /> <img id="endTimeImg"
	src="jslib/jscalendar/img.gif" /> <script type="text/javascript"
	language="javascript">
	$('#endTimeImg').timepicker( {
		defaultTime :new Date()
	});
</script> </span>
&nbsp;&nbsp;<span><%=lang.readGm(GMLangConstants.REASON)%>：
<select id="reason">
	<option id="option-1" value="-1"><%=lang.readGm(GMLangConstants.REASON_ALL)%></option>
	<c:forEach items="${logReasons}" var="logType" varStatus="count"
		begin="0">
		<option id="option${logType.key}" value="${logType.key}">${logType.value}</option>
	</c:forEach>
</select></span>&nbsp;&nbsp;
<input id="export" class="butcom"
	name="export" type="button" style="margin-left: 1em;"
	value="<%=lang.readGm(GMLangConstants.EXPORT)%>"
	onclick="javaScript:doExport()" />
<input id="download"
	name="download" type="button" style="margin-left: 1em;"
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