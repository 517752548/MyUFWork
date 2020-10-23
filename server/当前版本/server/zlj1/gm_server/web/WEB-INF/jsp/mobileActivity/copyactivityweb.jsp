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
	   $("#activityType").attr("disabled","true");
	   
	   if("${mobileActivityShowData.useOrNot}"==""){
		   $("#activityUsableoption0").attr("selected","selected");
	   }else{
		   $("#activityUsableoption${mobileActivityShowData.useOrNot}").attr("selected","selected");
	   }
	   $("#activityUsable").attr("disabled","true");
	   
	   var info = $("#activityPrize").val();
	   $("#activityPrize").val("");
	   $("#activityPrize").append(info);
});
</script>
</head>
<body>
<form action="mobileActivity.do?action=copyMobileActivityDo" method="post">
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
         	<span><%=lang.readGm(GMLangConstants.DATE)%>:<input id="dateStart" name="dateStart" type="text" readonly="true" class="limitWidth" value="${mobileActivityShowData.startDate}" /> 
			</span>&nbsp;&nbsp;	
			
			<span><%=lang.readGm(GMLangConstants.START_TIME)%>：<input
				id="startTime" name="startTime" readonly="true" value="${mobileActivityShowData.startTime}" class="time_gap" />
			</span>
         </td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_ACTIVY_WEB_NAME)%><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_END_TIME)%></td>
		 <td>
         	<span><%=lang.readGm(GMLangConstants.DATE)%>:<input id="dateEnd" name="dateEnd"type="text" class="limitWidth" readonly="true" value="${mobileActivityShowData.endDate}" /> 
			</span>&nbsp;&nbsp;	
			
			<span><%=lang.readGm(GMLangConstants.END_TIME)%>：<input id="endTime"
				name="endTime" readonly="true"  value="${mobileActivityShowData.endTime}" class="time_gap" /> 
			</span>
         </td>
	</tr> 
	<!-- 活动类型 -->
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_TYPE)%></td>
		<td>
			<span><%= lang.readGm(GMLangConstants.MOBILE_ACTIVITY_TYPE)%>
				<select id="activityType" name="activityType">
				 <c:forEach items="${mobileActivityGroupsNameList}" var="mobileActivityGroupsName">
					<option id="activity${mobileActivityGroupsName.id}" value="${mobileActivityGroupsName.id}">${mobileActivityGroupsName.name}</option>
				 </c:forEach>
			</select></span>
		</td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_GROUPS_PRIZE)%></td>
		<td>
		<textarea id="activityPrize" cols="80" rows="5" name="activityPrize" readonly="true" >${mobileActivityShowData.mobileActivityPrize}</textarea>
		</td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_NAME)%></td>
		<td>
		<textarea id="activityName" cols="80" rows="5" name="activityName" readonly="true" >${mobileActivityShowData.name}</textarea>
		</td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_DESC)%></td>
		<td>
		<textarea id="activityDesc" cols="80" rows="5" name="activityDesc" readonly="true" >${mobileActivityShowData.descMobileActivity}</textarea>
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
		<td class="label" bgcolor="ffff00" ><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_CURRENT_SER)%></td>
		<td bgcolor="ffff00">
		&nbsp;&nbsp;&nbsp;${currentSerName}
		</td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.ACTIVITY_WEB_SERVERIDS)%></td>
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
		<input class="butcom" type="button" id="selectAll" onclick="javascript:hh();"
           value="<%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%><%=lang.readGm(GMLangConstants.COMMON_SERVER)%>"/>
        <input class="butcom" type="submit" onclick="return is_ok();" value="<%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_CURRENT_COPY)%>"/>
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
      	  window.location.href="mobileActivity.do?action=init";
      }
     function is_ok(){
    	 var isCheck = false;
		  $("input[name=sId]").each(function(){
			  if( $(this).attr("checked")==true){
				  isCheck = true;
				  return true;
			  }
          });
		   if(isCheck == false){
			   alert("请选择服务器");
			   return false;
		   }
     }
</script>

</body>
</html>