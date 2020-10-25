<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title><%= lang.readGm(GMLangConstants.LZR_GM) %></title>
</head>
<script type="text/javascript">
   function refresh(){
	 window.top.frames.manFrame.location.reload();
	 window.top.frames.leftFrame.location.reload();
   }
   function goToGameServer(){
	   var url=$("#channel").val();
	   window.top.open(url);
   }
</script>
<body  onload="refresh();" style="height: 100%;">
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#ffb00c" style="margin-top: 0px;"> 
  <tr>
    <td width="25%" height="27" align="left" valign="top" bgcolor="#508545"><div align="left"><span class="STYLE3"><img src="images/toptext.gif"></span></div></td>
    <td width="20%" align="right" bgcolor="#508545" class="tlnk"><span class="tlnk STYLE1"><strong><%= lang.readGm(GMLangConstants.GAME_NAME) %></strong>:<%= lang.readGm(GMLangConstants.TR) %></span></td>
    <td width="55%" align="right" bgcolor="#508545" class="tlnk"><span class="tlnk STYLE1">
    <%= lang.readGm(GMLangConstants.COMMON_SERVER) %>：
				<select id="svr" onchange="changeServer(this.options[this.options.selectedIndex].value)">
				<c:forEach items="${dBServerList}" var="dbServer">
                     <c:choose>
                     <c:when test="${dbServer.id eq loginUser.loginServerId}">
                        <option id="${dbServer.id}" selected="selected" value="${dbServer.id}">${dbServer.dbServerName}-${dbServer.serverName}</option>
                     </c:when>
                     <c:otherwise>
                      <option id="${dbServer.id}" value="${dbServer.id}">${dbServer.dbServerName}-${dbServer.serverName}</option>
                     </c:otherwise>
                    </c:choose>
				</c:forEach>
			  </select>
    <%= lang.readGm(GMLangConstants.COMMON_FASTLANE) %>:
       <select id="channel" onchange="goToGameServer()">
				<c:forEach items="${serverList}" var="gameServer">
                    <c:choose>
                     <c:when test="${gameServer.id eq loginUser.loginRegionId}">
                       <option id="${gameServer.id}" selected="selected" value="${gameServer.serverURL}">${gameServer.serverName}</option>
                     </c:when>
                     <c:otherwise>
                       <option id="${gameServer.id}" value="${gameServer.serverURL}">${gameServer.serverName}</option>
                     </c:otherwise>
                    </c:choose>
				</c:forEach>
	 </select>
<%= lang.readGm(GMLangConstants.COMMON_REGION) %>：<select id="region"><option id="region1">${regionName}</option></select>
 <span><%= lang.readGm(GMLangConstants.ROLE) %>：
     <c:choose>
  		<c:when test="${loginUser.role eq 'super_admin'}">
  			<%=lang.readGm(GMLangConstants.SUPER_ADMIN) %>
  		</c:when>
  		<c:when test="${loginUser.role eq 'admin'}">
  			<%=lang.readGm(GMLangConstants.ADMIN) %>
  		</c:when>
  		<c:when test="${loginUser.role eq 'maintain'}">
  			<%=lang.readGm(GMLangConstants.MAINTAIN) %>
  		</c:when>
  		<c:when test="${loginUser.role eq 'normal_custom_service'}">
  			<%=lang.readGm(GMLangConstants.NORMAL_CUSTOM_SERVICE) %>
  		</c:when>
  		<c:when test="${loginUser.role eq 'advanced_custom_service'}">
  			<%=lang.readGm(GMLangConstants.ADVANCED_CUSTOM_SERVICE) %>
  		</c:when>
  		<c:when test="${loginUser.role eq 'operation'}">
  			<%=lang.readGm(GMLangConstants.OPERATION) %>
  		</c:when>
  	</c:choose>	
 </span>
 <span><%= lang.readGm(GMLangConstants.USER) %>：${loginUser.username}</span>
 <span><a href="#" onclick="window.top.location='homePage.do?action=exit'"><%= lang.readGm(GMLangConstants.COMMON_EXIT) %></a>
</span></span></td></tr>
</table>

<script type="text/javascript">
function changeServer(svrid){
	window.top.location.href ='homePage.do?action=changeServer&svrid='+svrid;
}

</script>
</body>
</html>
</body>
</html>