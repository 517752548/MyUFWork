<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
<script type="text/javascript" src="jslib/jquery.js"></script>

<script type="text/javascript">
   $().ready(function(){
	  
   });
   function selectAll(){
	   var sel=$("#selBut").attr("checked");
	   if(sel){
         $("input[name='serverId']").each(function(){
			$(this).attr("checked",true);
          });
	   }else{
		   $("input[name='serverId']").each(function(){
				$(this).attr("checked",false);
	       });
	  }
   }
  
</script>
</head>
<body>
<c:if test="${fail eq true}">
	<script type="text/javascript">
		alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
	</script>
</c:if>
<c:if test="${exist eq true}">
	<script type="text/javascript">
		alert("<%=lang.readGm(GMLangConstants.USER_EXIST)%>");
	</script>
</c:if>

<div id="man_zone">

<div class="topnav"><a class="link" href="homePage.do?action=welcome">
<%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>&gt;&gt;
<%= lang.readGm(GMLangConstants.SYS)%>&gt;&gt;
<%=lang.readGm(GMLangConstants.SYSUSER)%>
</div>

<div id="nav">
<ul>
	<li id="man_nav_1" class="bg_image_onclick"><%=lang.readGm(GMLangConstants.SYSUSER)%></li>
</ul>
</div>

<div id="sub_info">
</div>

<form  method="post"
	action="sysUser.do?action=addSysUser" onsubmit="return is_ok();">
<table id='tab_1' class="detail" style="width:50%;" cellspacing="0"
	cellpadding="0" border="0">
	<tbody>
		<tr>
			<th colspan="4"><%=lang.readGm(GMLangConstants.SYSUSER)%></th>
		</tr>
		<tr>
			<td class="label"><%= lang.readGm(GMLangConstants.SYSUSER_NAME)%></td>
			<td style="width: 200px;"><input id="userName" name="userName" value="${userName}"
				type="text"></td>
			<td class="label"><%= lang.readGm(GMLangConstants.COMMON_PASSWORD)%></td>
			<td style="width: 200px;"><input id="password" name="password" value="${password}"
				type="password"></td>
		</tr>
		<tr>
			<td class="label"><%= lang.readGm(GMLangConstants.RIGHT)%></td>
			<td colspan="3"><select id="right" name="right">
				<c:forEach items="${roleList}" var="role">
					   <c:choose>
		                    <c:when test="${right eq role}">
								  <option selected="selected" value="${role}">
			                    	    <c:choose>
									  		<c:when test="${role eq 'super_admin'}">
									  			<%=lang.readGm(GMLangConstants.SUPER_ADMIN) %>
									  		</c:when>
									  		<c:when test="${role eq 'admin'}">
									  			<%=lang.readGm(GMLangConstants.ADMIN) %>
									  		</c:when>
									  		<c:when test="${role eq 'maintain'}">
									  			<%=lang.readGm(GMLangConstants.MAINTAIN) %>
									  		</c:when>
									  		<c:when test="${role eq 'normal_custom_service'}">
									  			<%=lang.readGm(GMLangConstants.NORMAL_CUSTOM_SERVICE) %>
									  		</c:when>
									  		<c:when test="${role eq 'advanced_custom_service'}">
									  			<%=lang.readGm(GMLangConstants.ADVANCED_CUSTOM_SERVICE) %>
									  		</c:when>
									  		<c:when test="${role eq 'operation'}">
									  			<%=lang.readGm(GMLangConstants.OPERATION) %>
									  		</c:when>
									  		<c:when test="${role eq 'advanced_operation'}">
									  			<%=lang.readGm(GMLangConstants.ADVANCED_OPERATION) %>
									  		</c:when>
									  		<c:when test="${role eq 'kaiying'}">
									  			<%=lang.readGm(GMLangConstants.KAIYING) %>
									  		</c:when>
									  		<c:when test="${role eq 'developer'}">
									  			<%=lang.readGm(GMLangConstants.DEVELOPER) %>
									  		</c:when>
									  	</c:choose>
								  </option>
		                    </c:when>
		                    <c:otherwise>
		                    	    <option  value="${role}">
			                    	    <c:choose>
									  		<c:when test="${role eq 'super_admin'}">
									  			<%=lang.readGm(GMLangConstants.SUPER_ADMIN) %>
									  		</c:when>
									  		<c:when test="${role eq 'admin'}">
									  			<%=lang.readGm(GMLangConstants.ADMIN) %>
									  		</c:when>
									  		<c:when test="${role eq 'maintain'}">
									  			<%=lang.readGm(GMLangConstants.MAINTAIN) %>
									  		</c:when>
									  		<c:when test="${role eq 'normal_custom_service'}">
									  			<%=lang.readGm(GMLangConstants.NORMAL_CUSTOM_SERVICE) %>
									  		</c:when>
									  		<c:when test="${role eq 'advanced_custom_service'}">
									  			<%=lang.readGm(GMLangConstants.ADVANCED_CUSTOM_SERVICE) %>
									  		</c:when>
									  		<c:when test="${role eq 'operation'}">
									  			<%=lang.readGm(GMLangConstants.OPERATION) %>
									  		</c:when>
									  		<c:when test="${role eq 'advanced_operation'}">
									  			<%=lang.readGm(GMLangConstants.ADVANCED_OPERATION) %>
									  		</c:when>
									  		<c:when test="${role eq 'kaiying'}">
									  			<%=lang.readGm(GMLangConstants.KAIYING) %>
									  		</c:when>
									  		<c:when test="${role eq 'developer'}">
									  			<%=lang.readGm(GMLangConstants.DEVELOPER) %>
									  		</c:when>
									  	</c:choose>
									</option>
		                    </c:otherwise>
                  		</c:choose>
				</c:forEach>
			</select></td>
		</tr>
		<tr>
			<td class="label"><%= lang.readGm(GMLangConstants.COMMON_REGION)%>
			</td>
			<td class="label" colspan="4">
				<input type="radio" name="sRegionId" value="${defaultRegionId}" checked="checked">${defaultRegionName}   &nbsp;&nbsp;&nbsp;&nbsp;           
				<c:if test="${canAll eq true}">
				<input type="radio" name="sRegionId" value="<%= SystemConstants.ALL_REGION_PRIVILEGE %>"><%= SystemConstants.ALL_REGION_PRIVILEGE %><br/>
				</c:if>
			</td>
		</tr>
		<tr>
			<td colspan="4" align="right"><input class="butcom"
				id="submit" type="submit"
				value="<%= lang.readGm(GMLangConstants.COMMON_SUBMIT)%>" />&nbsp;&nbsp;
				<input id="reset" type="reset" class="butcom" value="<%= lang.readGm(GMLangConstants.RESET)%>" />&nbsp;&nbsp;
           </td>
		</tr>
	</tbody>
</table>
</form>
</div>
<script type="text/javascript" language="javascript">
function is_ok(){
	if(is_null($("#userName").val())==true){
		alert('<%= lang.readGm(GMLangConstants.USER_NOT_NULL)%>');
		$("#userName").focus();
		return false;
	}
	if(is_null($("#password").val())==true){
		alert('<%= lang.readGm(GMLangConstants.PASSWORD_NOT_NULL)%>');
		$("#endTime").focus();
		return false;
	}
	
	return true;
    var ser_cont = 0;
    $("input[name='serverId']").each(function(){
		var s_checked= $(this).attr("checked");
		if(s_checked){
			ser_cont=+1;
		}
      });
    if(ser_cont==0){
    	alert("<%= lang.readGm(GMLangConstants.CMD_NSERVER_ALERT)%>");
			return false;
		}
		return true;

	}
</script>
</body>
</html>