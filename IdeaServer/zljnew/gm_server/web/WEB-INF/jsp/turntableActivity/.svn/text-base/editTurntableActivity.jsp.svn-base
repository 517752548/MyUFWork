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
	  
});
</script>
</head>
<body>
<form action="turntableActivity.do?action=updateMobileActivityDo" method="post">
<div id="man_zone">
<div class="topnav">
<%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %>>><%= lang.readGm(GMLangConstants.TURNTABLE_ACTIVITY_DESC) %>
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
		<td colspan="2" class="header"><%=lang.readGm(GMLangConstants.TURNTABLE_ACTIVITY_DESC)%></td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.ACTIVITY_WEB_NAME)%><%=lang.readGm(GMLangConstants.CEO_WAR_CRAFT_ID)%></td>
		<td> &nbsp;${mobileActivityShowData.id}
		<input id="content" name="content" type="hidden" value="${mobileActivityShowData.id}"/>
		
		</td>
	</tr>
	
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.ACTIVITY_TYPE)%></td>
		<td> <select id="fType" name="fType">
			<c:forEach items="${fTypeMap}" var="m">
			<option value="${m.key}">${m.value}</option>
			</c:forEach>
		</select>
		</td>
	</tr>
	
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.TURNTABLE_ACTIVITY_DESC)%><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_START_TIME)%></td>
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
		<td class="label"><%=lang.readGm(GMLangConstants.TURNTABLE_ACTIVITY_DESC)%><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_END_TIME)%></td>
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
	
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.ACTIVITY_WEB_SERVERIDS)%>
		<input class="butcom" type="button" id="selectAll" onclick="javascript:hh();"
           value="<%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%><%=lang.readGm(GMLangConstants.COMMON_SERVER)%>"/>
		</td>
		<td><%int aa=0; %>
		<c:forEach items="${checkBox}" var="checkboxone">
				<c:if test="${checkboxone.selectecd eq 1}">
				 	 <input id="sId" name="sId" type="checkbox" value="${checkboxone.serverId}" checked="checked"/>
				   	${checkboxone.serverName}
				</c:if>	
				<c:if test="${checkboxone.selectecd eq 0}">
				 	 <input id="sId" name="sId" type="checkbox" value="${checkboxone.serverId}"/>
				   	${checkboxone.serverName}
				</c:if>	
				<%aa=aa+1;if(aa%10==0){%>
					<br/>
				<%}%>
            </c:forEach>
		</td>
	</tr> 
	
	 <tr>
		<td class="label"><%=lang.readGm(GMLangConstants.COMMON_OPERATION)%></td>
		<td>
        <input class="butcom" type="submit" onclick="return is_ok();" value="<%=lang.readGm(GMLangConstants.COMMON_OPERATION)%>"/>
        <input class="butcom" type="button" onclick="goBackAcvitvity();" value="<%=lang.readGm(GMLangConstants.ACTIVITY_WEB_GO_BACK)%>"/>
        </td>
	</tr>
</table>
</div>
</div>
</form>
<script type="text/javascript">
function hh(){
    var selAll = $("#selectAll").attr("selAll");
    if(selAll=="false"){
         $("input[name=sId]").each(function(){
              $(this).attr("checked",false);
           });
         $("#selectAll").attr("selAll","true");
         $("#selectAll").val("<%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%><%=lang.readGm(GMLangConstants.COMMON_SERVER)%>");  
     }else{
   	  $("input[name=sId]").each(function(){
             $(this).attr("checked",true);
          });
   	    $("#selectAll").attr("selAll","false");
   	    $("#selectAll").val("<%=lang.readGm(GMLangConstants.COMMON_SElECT_NONE)%><%=lang.readGm(GMLangConstants.COMMON_SERVER)%>");  
       }
}

     function goBackAcvitvity(){
      	  window.location.href="turntableActivity.do?action=init";
      }
     function is_ok(){
     	  return true;
     }
     function forceEnd(id){
     	  window.location.href="turntableActivity.do?action=forceEndActivity&Id="+id;
     }
     
     function doAjaxQueryGroupsPrize(){
   	  	var activityTypes = $("#activityType").val();
		$.ajaxSettings.async= false;
		$.post("turntableActivity.do?action=ajaxQueryGroupsPrizes",{activityType:activityTypes},function(info){
			info = $.trim(info);
			$("#activityPrize").val("");
			$("#activityPrize").append(info);
		});
		$.ajaxSettings.async= true;
	}
</script>

</body>
</html>