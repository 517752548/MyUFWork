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

<form action="qqMarketTaskTarget.do?action=updateMobileActivityDo" method="post">
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
<div><font color="#ff0000" size=5><%=lang.readGm(GMLangConstants.QQ_MARKETTASK_DESC)%></font></div>
<table name='tab_1' class="detail" style="width:50%;" cellspacing="0" cellpadding="0" border="0">
	<tr>
		<th width="5%"><%=lang.readGm(GMLangConstants.TASK_ID)%></th>
		 <th width="5%"><%=lang.readGm(GMLangConstants.QQ_MARKETTASK_ID)%></th>
		 <th width="10%"><%=lang.readGm(GMLangConstants.QQ_MARKETTASK_TARGET)%></th>
 		 <th width="10%"><%=lang.readGm(GMLangConstants.QQ_MARKETTASK_PARAM1)%></th>
 		  <th width="10%"><%=lang.readGm(GMLangConstants.QQ_MARKETTASK_PARAM2)%></th>
 		  <th width="10%"><%=lang.readGm(GMLangConstants.QQ_MARKETTASK_PARMA3)%></th>
	</tr>
    
    <input id="id" name="id" value="${mobileActivityShow.id}" type="hidden"/>
    <%int aa=0; %>
    <c:forEach items="${mobileActivityShow.targetList}" var="targetInfo">
    	<%aa=aa+1;%>
    		<tr>
    		<td rowspan=2><input id="<%=aa%>cid" name="<%=aa%>cid" type="text" value="${targetInfo.cid}"/></td>
	        <td><input id="<%=aa%>step2Id" name="<%=aa%>step2Id" type="text" class="limitWidth" value="${targetInfo.ctarget.step2Id}" readonly="readonly"/></td>
	        <td><input id="<%=aa%>step2Target" name="<%=aa%>step2Target" type="text" class="limitWidth" value="${targetInfo.ctarget.step2Target}" /></td>
	        <td><input id="<%=aa%>step2param1" name="<%=aa%>step2param1" type="text" class="limitWidth" value="${targetInfo.ctarget.step2param1}" /></td>
	        <td><input id="<%=aa%>step2param2" name="<%=aa%>step2param2" type="text" class="limitWidth" value="${targetInfo.ctarget.step2param2}" /></td>
	        <td><input id="<%=aa%>step2param3" name="<%=aa%>step2param3" type="text" class="limitWidth" value="${targetInfo.ctarget.step2param3}" /></td>
			</tr>
			
			<tr>
	       <td><input id="<%=aa%>step3Id" name="<%=aa%>step3Id" type="text" class="limitWidth" value="${targetInfo.ctarget.step3Id}" readonly="readonly"/></td>
	        <td><input id="<%=aa%>step3Target" name="<%=aa%>step3Target" type="text" class="limitWidth" value="${targetInfo.ctarget.step3Target}" /></td>
	        <td><input id="<%=aa%>step3param1" name="<%=aa%>step3param1" type="text" class="limitWidth" value="${targetInfo.ctarget.step3param1}" /></td>
	        <td><input id="<%=aa%>step3param2" name="<%=aa%>step3param2" type="text" class="limitWidth" value="${targetInfo.ctarget.step3param2}" /></td>
	        <td><input id="<%=aa%>step3param3" name="<%=aa%>step3param3" type="text" class="limitWidth" value="${targetInfo.ctarget.step3param3}" /></td>
			</tr>
    	</c:forEach>
    
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.COMMON_SERVER)%></td>
		<td><input class="butcom" type="button" id="selectAll" onclick="javascript:hh();"
           value="<%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%><%=lang.readGm(GMLangConstants.COMMON_SERVER)%>"/>
        </td>
		<td colspan=3>
			<c:forEach items="${serverList}" var="s">
			   <input id="sId" name="sId" type="checkbox" value="${s.id}"/>
				${s.dbServerName}
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
     function goBackAcvitvity(){
      	  window.location.href="qqMarketTaskTarget.do?action=init";
      }
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
     	  return true;
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