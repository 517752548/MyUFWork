<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
</head>
<body>
<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>>><%= lang.readGm(GMLangConstants.DAILY_MAINTENANCE) %>>><%= lang.readGm(GMLangConstants.ACTIVITY_MANAGE) %>
</div>
<br/>
<c:choose>
<c:when test="${error_msg ne null}">
<span id="error_msg" class="error_msg">${error_msg}</span>
</c:when>
</c:choose>
<br/>
<div class="nofloat"/>
<form action="activity.do?action=viewActivityStatus" method="post">
<table cellspacing="" class="welcome" style="width: 40%;margin-left: 1em;" cellpadding="20" >
	<tr>
		<td colspan="2" class="header"><%=lang.readGm(GMLangConstants.CMD_MANAGE)%></td>
	</tr>
<!--	<tr>-->
<!--		<td class="label"><%=lang.readGm(GMLangConstants.CMD)%></td>-->
<!--		<td><input type="text" id="cmd" name="cmd" size="50"/></td>-->
<!--	</tr>-->
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.COMMON_SERVER)%></td>
		<td>
			<c:forEach items="${serverList}" var="s">
			   <input id="sId" name="sId" type="checkbox" value="${s.id}"/>
				${s.dbServerName}
                </c:forEach> 
		</td>
	</tr>
<!--	<tr>-->
<!--			<td class="label"><%= lang.readGm(GMLangConstants.ACTIVITYID)%>-->
<!--			</td>-->
<!--			<td colspan="3" ><input type="text" id="activity_id" name="activity_id" size="50"/></td>-->
<!--		</tr>	-->
<!--    <tr>-->
<!--	<tr>-->
<!--			<td class="label"><%= lang.readGm(GMLangConstants.COMMAND_DETAIL)%>-->
<!--			</td>-->
<!--			<td colspan="3" ><textarea id="command_content" cols="80" rows="5" name="command_content"></textarea></td>-->
<!--		</tr>	-->
    <tr>
		<td class="label"><%=lang.readGm(GMLangConstants.COMMON_OPERATION)%></td>
		<td><input class="butcom" type="button" id="selectAll" onclick="javascript:hh();"
           value="<%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%><%=lang.readGm(GMLangConstants.COMMON_SERVER)%>"/>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input  class="butcom" type="submit" onclick="return is_ok();" value="<%=lang.readGm(GMLangConstants.COMMON_SEND)%><%=lang.readGm(GMLangConstants.CMD)%>"/></td>
	</tr>
</table>
</form>

<table name='tab_1' class="detail"  cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
		<tr>
		
		 <th>&nbsp;活动id</th>
         <th>&nbsp;活动名称</th>
		 <th>&nbsp;活动状态</th>
		 
		
		</tr>
     <c:forEach items="${activityInfos}" var="activityInfo">
     	<c:forEach items="${activityInfo.value}" var="activityStatusVo">
        <tr>
		 
		 <td>&nbsp;${activityStatusVo.activityId}</td>
          <td>&nbsp;${activityStatusVo.name}</td>
		 <td>&nbsp;${activityStatusVo.status}
         <c:choose>
				<c:when test="${activityStatusVo.status eq 4}">
					活动完毕
				</c:when>
				<c:otherwise>
					活动正常
				</c:otherwise>
			</c:choose>	
			</td>
		</tr>
		 </c:forEach>
     </c:forEach>
     <tr>
   
  </tr>
   </tbody>
</table>

</div>

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
 		//命令
 		//if(is_null($("#cmd").val())){
 		//	alert('<%=lang.readGm(GMLangConstants.CMD_ALERT)%>');
 		//	return false;
 		//}
 		//服务器
 		var svr="";
 		 $("input[name=sId]").each(function(){
               var svrChecked = $(this).attr("checked");
               if(svrChecked==true){
             	  svr+=$(this).val();
                 }
           });
 		if(svr==""){
 			alert('<%=lang.readGm(GMLangConstants.CMD_NSERVER_ALERT)%>');
			    return false;
		      }
		return true;
	}
</script>

</body>
</html>