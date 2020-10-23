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
<a class="link" href="homePage.do?action=welcome"><%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>>><%= lang.readGm(GMLangConstants.ACCESS_CONTROL) %>
</div>
<br/>
<c:choose>
<c:when test="${error_msg ne null}">
<span id="error_msg" class="error_msg">${error_msg}</span>
</c:when>
</c:choose>
<br/>
<div class="nofloat"/>
<form action="accessControl.do?action=sendCmd" method="post">
<table cellspacing="0" class="welcome" style="width: 40%;margin-left: 1em;" cellpadding="1" >
	<tr>
		<td colspan="2" class="header" style="height: 30px;"><%=lang.readGm(GMLangConstants.ACCESS_CONTROL)%></td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.RIGHT_OPTION)%></td>
		<td><select id="accessRight" name="accessRight" >
				<option  value="1"><%=lang.readGm(GMLangConstants.OPEN_ACCESS)%></option>
				<option  value="2"><%=lang.readGm(GMLangConstants.RIGHT_ACCESS)%></option>
			</select></td>
	</tr>
	<tr>
		<td class="label" style="height: 20px;"><%=lang.readGm(GMLangConstants.COMMON_SERVER)%></td>
		<td>
		<table cellspacing="0" cellpadding="0" width="100%;" height="100%;">
			<tr>
			<c:forEach items="${serverList}" var="s">
			    <td style="background-color: ${s.prvColor};text-align:left"  width="20%" ><input id="sId" name="sId" type="checkbox" value="${s.id}"></td>
				<td style="background-color: ${s.prvColor}">${s.dbServerName}</td>
                </c:forEach> 
			<tr>
		</table>
		</td>
	</tr>
    <tr>
		<td style="background-color: #9C9C9C" colspan="2" cellpadding="0"><%=lang.readGm(GMLangConstants.ACC_CON_HINT)%>
		<input class="butcom" type="button" id="selectAll" onclick="javascript:hh();"
           value="<%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%><%=lang.readGm(GMLangConstants.COMMON_SERVER)%>"/>
        &nbsp;&nbsp;<input  class="butcom" type="submit" onclick="return is_ok();" value="<%=lang.readGm(GMLangConstants.EDIT)%>"/></td>
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