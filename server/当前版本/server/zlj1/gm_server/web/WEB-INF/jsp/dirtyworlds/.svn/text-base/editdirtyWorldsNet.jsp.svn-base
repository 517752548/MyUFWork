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
	   if("${dirtyWorldsType.showTypes}"==""){
		   $("#activity0").attr("selected","selected");
	   }else{
		   $("#activity${dirtyWorldsType.showTypes}").attr("selected","selected");
	   }
});
</script>
</head>
<body>
<form action="dirtyWorlds.do?action=editDo" method="post">
<div id="man_zone">
<div class="topnav">
<%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %>>><%= lang.readGm(GMLangConstants.DIRTY_WORLDS_NET) %>
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
		<td colspan="2" class="header"><%=lang.readGm(GMLangConstants.DIRTY_WORLDS_NET)%></td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.DIRTY_WORLDS_NET_ID)%></td>
		<td> &nbsp;${dirtyWorldsType.id}
		<input id="content" name="content" type="hidden" value="${dirtyWorldsType.id}"/>
		</td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.DIRTY_WORLDS_NET_TIME)%></td>
		<td> &nbsp;${dirtyWorldsType.updateTimeStr}
		</td>
	</tr>
		<!--  -->
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.DIRTY_WORLDS_NET_CONTENT)%></td>
		<td>
			<span><%= lang.readGm(GMLangConstants.DIRTY_WORLDS_NET_CONTENT)%>
				<select id="activityType" name="activityType">
				 <c:forEach items="${mobileActivityGroupsNameList}" var="mobileActivityGroupsName">
					<option id="activity${mobileActivityGroupsName.id}" value="${mobileActivityGroupsName.id}">${mobileActivityGroupsName.name}</option>
				 </c:forEach>
			</select></span>
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
        <input class="butcom" type="submit" onclick="return is_ok();" value="<%=lang.readGm(GMLangConstants.COMMON_OPERATION)%>"/>
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