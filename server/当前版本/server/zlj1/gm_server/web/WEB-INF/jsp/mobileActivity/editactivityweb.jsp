<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<%@ page import="java.lang.String"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<link rel="stylesheet" type="text/css"
	href="jslib/jsTimePicker/timepicker.css" />
<script type="text/javascript" src="jslib/jsTimePicker/timepicker.js"></script>
<title>Insert title here</title>
<script type="text/javascript">
$().ready(function(){
	   if("${mobileActivityShowData.mobilePrizeGrepsId}"==""){
		   $("#activity0").attr("selected","selected");
	   }else{
		   $("#activity${mobileActivityShowData.mobilePrizeGrepsId}").attr("selected","selected");
	   }
	   if("${mobileActivityShowData.useOrNot}"==""){
		   $("#activityUsableoption0").attr("selected","selected");
	   }else{
		   $("#activityUsableoption${mobileActivityShowData.useOrNot}").attr("selected","selected");
	   }
	   
	   var info = $("#activityPrize").val();
	   $("#activityPrize").val("");
	   $("#activityPrize").append(info);
});
</script>
</head>
<body>
<form action="mobileActivity.do?action=updateMobileActivityDo" method="post">
<div id="man_zone">
<div class="topnav">
<%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %>>><%= lang.readGm(GMLangConstants.MOBILE_ACTIVITY_ACTIVY_WEB_NAME) %>
</div>
<br/>
<c:choose>
<c:when test="${error_msg ne null}">
<span id="error_msg" class="error_msg">${error_msg}</span>
</c:when>
</c:choose>

<br/>
<div class="nofloat">
<table name='tab_1' class="detail" style="width:50%;" cellspacing="0" cellpadding="0" border="0">
	<tr>
		<td colspan="2" class="header"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_ACTIVY_WEB_NAME)%></td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.ACTIVITY_WEB_NAME)%><%=lang.readGm(GMLangConstants.CEO_WAR_CRAFT_ID)%></td>
		<td> &nbsp;${mobileActivityShowData.id}
		<input id="content" name="content" type="hidden" value="${mobileActivityShowData.id}"/>
		<input id="forceEnd" name="forceEnd" type="hidden" value="${mobileActivityShowData.forceEndOrNot}"/>
		</td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_ACTIVY_WEB_NAME)%><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_START_TIME)%></td>
		 <td>
         	<span><%=lang.readGm(GMLangConstants.DATE)%>:<input id="dateStart" name="dateStart"type="text" class="limitWidth" value="${mobileActivityShowData.startDate}" /> 
				<img id="dateStartImg" src="jslib/jscalendar/img.gif" /> <script
				type="text/javascript" language="javascript">
			Calendar.setup(
				    {
				      inputField  : "dateStart",         // ID of the input field
				      ifFormat    :  "%Y-%m-%d",       // format of the input field
				      showsTime   :  false,
				      timeFormat  :  "24",
				      onClose  :  function (cal){
				    	          cal.hide();
			                     },
				      button   : "dateStartImg"     // ID of the button
				    }
			    );
				</script>
			</span>&nbsp;&nbsp;	
			
			<span><%=lang.readGm(GMLangConstants.START_TIME)%>：<input
				id="startTime" name="startTime" value="${mobileActivityShowData.startTime}" class="time_gap" />
			<img id="startTimeImg" src="jslib/jscalendar/img.gif" /> <script
				type="text/javascript" language="javascript">
			$('#startTimeImg').timepicker({
			    defaultTime: new Date()
			});
			</script> 
			</span>
         </td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_ACTIVY_WEB_NAME)%><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_END_TIME)%></td>
		 <td>
         	<span><%=lang.readGm(GMLangConstants.DATE)%>:<input id="dateEnd" name="dateEnd"type="text" class="limitWidth" value="${mobileActivityShowData.endDate}" /> 
				<img id="dateEndImg" src="jslib/jscalendar/img.gif" /> <script
				type="text/javascript" language="javascript">
			Calendar.setup(
				    {
				      inputField  : "dateEnd",         // ID of the input field
				      ifFormat    :  "%Y-%m-%d",       // format of the input field
				      showsTime   :  false,
				      timeFormat  :  "24",
				      onClose  :  function (cal){
				    	          cal.hide();
			                     },
				      button   : "dateEndImg"     // ID of the button
				    }
			    );
				</script>
			</span>&nbsp;&nbsp;	
			
			<span><%=lang.readGm(GMLangConstants.END_TIME)%>：<input id="endTime"
				name="endTime" value="${mobileActivityShowData.endTime}" class="time_gap" /> <img
				id="endTimeImg" src="jslib/jscalendar/img.gif" /> <script
				type="text/javascript" language="javascript">
			$('#endTimeImg').timepicker({
			    defaultTime: new Date()
			});
			</script> 
			</span>
         </td>
	</tr> 
	<!-- 活动类型 -->
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_TYPE)%></td>
		<td>
			<span><%= lang.readGm(GMLangConstants.MOBILE_ACTIVITY_TYPE)%>
				<select id="activityType" name="activityType" onchange="javaScript:doAjaxQueryGroupsPrize()">
				 <c:forEach items="${mobileActivityGroupsNameList}" var="mobileActivityGroupsName">
					<option id="activity${mobileActivityGroupsName.id}" value="${mobileActivityGroupsName.id}">${mobileActivityGroupsName.name}</option>
				 </c:forEach>
			</select></span>
		</td>
	</tr>
	<!-- 活动列表名称图标 -->
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_NAME_ICON)%></td>
		<td>
		<textarea id="nameIcon" cols="10" rows="1" name="nameIcon">${mobileActivityShowData.nameIcon}</textarea>
		</td>
	</tr>
	<!-- 活动标题名称图标 -->
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_TITLE_ICON)%></td>
		<td>
		<textarea id="titleIcon" cols="10" rows="1" name="titleIcon">${mobileActivityShowData.titleIcon}</textarea>
		</td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_NAME)%></td>
		<td>
		<textarea id="activityName" cols="80" rows="5" name="activityName" >${mobileActivityShowData.name}</textarea>
		</td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_DESC)%></td>
		<td>
		<textarea id="activityDesc" cols="80" rows="5" name="activityDesc" >${mobileActivityShowData.descMobileActivity}</textarea>
		</td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.ACTIVITY_WEB_ACTIVY_USE_OR_NOT)%></td>
		<td>
			<span><%= lang.readGm(GMLangConstants.ACTIVITY_WEB_ACTIVIT_NAME_EFFECT)%>
				<select id="activityUsable" name="activityUsable">
				<% Map activityUsable1 = Mask.getMap("mobileActivityUse");
					for(Iterator i=activityUsable1.keySet().iterator();i.hasNext();){
					int key=(Integer)i.next();
					if(key == -1){
						continue;
					}
					Integer value=(Integer)activityUsable1.get(key);
				%>
				<option id="activityUsableoption<%=key%>"  value="<%=key%>"><%= lang.readGm(value)%></option>
				<%}%>
			</select></span>
		</td>
	</tr>
	 <tr>
		<td class="label"><%=lang.readGm(GMLangConstants.COMMON_OPERATION)%></td>
		<td>
        <input class="butcom" type="submit" onclick="return is_ok();" value="<%=lang.readGm(GMLangConstants.COMMON_OPERATION)%>"/>
        <input class="butcom" type="button" onclick="goBackAcvitvity();" value="<%=lang.readGm(GMLangConstants.ACTIVITY_WEB_GO_BACK)%>"/>
        <c:if test="${mobileActivityShowData.forceEndOrNot eq 0}">
				<input class="butcom" type="button" value="<%= lang.readGm(GMLangConstants.ACTIVITY_WEB_ACTIVY_FORCEEND)%>" onClick="javaScript:window.location.href='mobileActivity.do?action=forceEndActivity&Id=${mobileActivityShowData.id}';"/>
		</c:if>	
        </td>
	</tr>
</table>
</div>
</div>
</form>
<script type="text/javascript">
     function goBackAcvitvity(){
      	  window.location.href="mobileActivity.do?action=init";
      }
     function is_ok(){
     	  return true;
     }
     function forceEnd(id){
     	  window.location.href="mobileActivity.do?action=forceEndActivity&Id="+id;
     }
     
     function doAjaxQueryGroupsPrize(){
   	  	var activityTypes = $("#activityType").val();
		$.ajaxSettings.async= false;
		$.post("mobileActivity.do?action=ajaxQueryGroupsPrizes",{activityType:activityTypes},function(info){
			info = $.trim(info);
			$("#activityPrize").val("");
			$("#activityPrize").append(info);
		});
		$.ajaxSettings.async= true;
	}
</script>

</body>
</html>