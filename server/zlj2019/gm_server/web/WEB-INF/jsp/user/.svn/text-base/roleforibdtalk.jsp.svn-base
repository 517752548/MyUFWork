<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<link rel="stylesheet" type="text/css" href="jslib/jsTimePicker/timepicker.css" />
<script type="text/javascript" src="jslib/jsTimePicker/timepicker.js"></script>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
</head>
<body>
<div id="man_zone">
<div class="topnav">
<a href="homePage.do?action=welcome"><%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>>>
<%=lang.readGm(GMLangConstants.FORBID)%>

</div>
<div class="nofloat" />
<table class="detail"    cellspacing="0" cellpadding="0" 
	border="0" >
	<tbody>
		<tr>
		 <th width="10%"><%=lang.readGm(GMLangConstants.USER_ID)%></th>
		 <th width="10%"><%=lang.readGm(GMLangConstants.USER_NAME)%></th>
		 <th width="30%"><%=lang.readGm(GMLangConstants.FORIBD_TALK_MESSAGE)%></th>
 		 <th width="10%"><%=lang.readGm(GMLangConstants.COMMON_OPERATION)%></th>
		</tr>
        <tr>
		 <!--  <td>&nbsp;${broseruRLS.terminalType}</td>userInfo.passportId-->
		 <td>&nbsp;&nbsp;${userInfo.id}</td>
		 <td>&nbsp;&nbsp;${userInfo.name}</td>
         <td><%=lang.readGm(GMLangConstants.DATE)%>:<input id="date" type="text" class="limitWidth" value="${timedate}" /> 
				<img id="dateImg" src="jslib/jscalendar/img.gif" /> <script
				type="text/javascript" language="javascript">
			Calendar.setup(
				    {
				      inputField  : "date",         // ID of the input field
				      ifFormat    :  "%Y-%m-%d",       // format of the input field
				      showsTime   :  false,
				      timeFormat  :  "24",
				      onClose  :  function (cal){
				    	          cal.hide();
			                     },
				      button   : "dateImg"     // ID of the button
				    }
			    );
				</script>
			&nbsp;&nbsp;&nbsp;&nbsp;<%=lang.readGm(GMLangConstants.TIME)%>:<input
				id="startTime" name="startTime" value="${timedateTwo}" class="time_gap" />
			<img id="startTimeImg" src="jslib/jscalendar/img.gif" /> 
			<script type="text/javascript" language="javascript">
			$('#startTimeImg').timepicker({
			    defaultTime: new Date()
			});
			</script> 
         </td>
         <td><!-- <a href="#" class="link pointer" onclick="javaScript:forbidtalk('${userInfo.id}');"><%=lang.readGm(GMLangConstants.FORBID)%></a>-->
         	&nbsp;
				<c:if test="${time < userInfo.foribedTalkTime}"><a href="#" class="link pointer" onclick="javaScript:cancleforbidtalk('${userInfo.id}');"><%=lang.readGm(GMLangConstants.FORIBD_TALK_RESET)%></c:if>
				<c:if test="${time >= userInfo.foribedTalkTime}"><a href="#" class="link pointer" onclick="javaScript:forbidtalk('${userInfo.id}');"><%=lang.readGm(GMLangConstants.FORBID)%></c:if>
         
         </td>
		</tr>
    <tr>
   </tbody>
</table>
</div>
<script type="text/javascript">
function forbidtalk(id){
	var forbidedate = $("#date").val();
	var forbidetime = $("#startTime").val();
	var con= confirm("<%=lang.readGm(GMLangConstants.FORIBD_TALK_APPLAY)%>?");
	if(con){
		$.post("user.do?action=foribdtalkdo",{id:id,forbidedate:forbidedate,forbidetime:forbidetime},function(info){
			var data = $.trim(info);
			if("true"==data){
				 alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
			}else{
				 alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
			}
	        window.location='user.do?action=init';
		  });	

	}
}
function cancleforbidtalk(id){
	var con= confirm("<%=lang.readGm(GMLangConstants.FORIBD_TALK_RESET)%>?");
	if(con){
		$.post("user.do?action=cancleforibdtalkdo",{id:id},function(info){
			var data = $.trim(info);
			if("true"==data){
				 alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
			}else{
				 alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
			}
	        window.location='user.do?action=init';
		  });	

	}
}
function goTo(i){
	  window.location.href="user.do?action=init&currentPage="+i;
}
</script>
</body>
</html>