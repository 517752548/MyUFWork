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
<a class="link" href="homePage.do?action=welcome"><%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>>><%= lang.readGm(GMLangConstants.DAILY_MAINTENANCE) %>>><%= lang.readGm(GMLangConstants.ON_LINE_PLAYER_CMD) %>
</div>
<br/>
<c:choose>
<c:when test="${error_msg ne null}">
<span id="error_msg" class="error_msg">${error_msg}</span>
</c:when>
</c:choose>
<br/>
<div class="nofloat"/>
<form action="onlinePlayerCommand.do?action=sendCmd" method="post">
<table cellspacing="" class="welcome" style="width: 40%;margin-left: 1em;" cellpadding="20" >
	<tr>
		<td colspan="2" class="header"><%=lang.readGm(GMLangConstants.ON_LINE_PLAYER_CMD)%></td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.COMMON_SERVER)%></td>
		<td>
			<c:forEach items="${serverList}" var="s">
			   <input id="sId" name="sId" type="checkbox" value="${s.id}"/>
				${s.dbServerName}
                </c:forEach> 
		</td>
	</tr>
	<tr>
			<td class="label"><%= lang.readGm(GMLangConstants.ON_LINE_PLAYER_CHAR_ID)%>
			</td>
			<td colspan="3" ><input id="char_id" name="char_id" cols="100" rows="5" /></td>
		</tr>	
    <tr>
	<tr>
			<td class="label"><%= lang.readGm(GMLangConstants.COMMAND_DETAIL)%>
			</td>
			<td colspan="3" ><textarea id="command_content" cols="80" rows="5" name="command_content"></textarea></td>
		</tr>	
    <tr>
		<td class="label"><%=lang.readGm(GMLangConstants.COMMON_OPERATION)%></td>
		<td><input class="butcom" type="button" id="selectAll" onclick="javascript:hh();"
           value="<%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%><%=lang.readGm(GMLangConstants.COMMON_SERVER)%>"/>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <input  class="butcom" type="submit" onclick="return is_ok();" value="<%=lang.readGm(GMLangConstants.COMMON_SEND)%><%=lang.readGm(GMLangConstants.CMD)%>"/></td>
	</tr>
</table>
</form>
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
 		if(is_null($("#char_id").val())){
 			alert('<%=lang.readGm(GMLangConstants.ON_LINE_PLAYER_CHAR_ID_CAN_NOT_NULL)%>');
 			return false;
 		}
 		if(is_null($("#command_content").val())){
 			alert('<%=lang.readGm(GMLangConstants.ON_LINE_PLAYER_CMD_CON_CAN_NOT_NULL)%>');
 			return false;
 		}
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