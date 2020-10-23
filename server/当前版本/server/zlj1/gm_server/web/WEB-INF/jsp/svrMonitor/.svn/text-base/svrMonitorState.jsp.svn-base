<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>mop</title>
</head>
<body>
<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>  
<a class="link" href="svrMonitor.do?action=init"><%=lang.readGm(GMLangConstants.ALARM_MONITOR)%><a>>>
<%=lang.readGm(GMLangConstants.COMMON_SERVER)%><%=lang.readGm(GMLangConstants.COMMON_STATE)%></div>
<div class="nofloat" />
<table class="detail no_bottom"  width="90%" cellspacing="0" cellpadding="0" border="0" align="center">
  <tbody><tr>
    <th><%= lang.readGm(GMLangConstants.COMMON_SERVER)%><%= lang.readGm(GMLangConstants.COMMON_NAME)%></th>
    <th><%= lang.readGm(GMLangConstants.CARDTYPE)%></th>
	<th><%= lang.readGm(GMLangConstants.IP_ADDRESS)%></th>
	<th><%= lang.readGm(GMLangConstants.PORT)%></th>
	<th><%= lang.readGm(GMLangConstants.ONLINE_NUM)%></th>
	<th><%= lang.readGm(GMLangConstants.FREEMEMORY)%></th>
 	<th><%= lang.readGm(GMLangConstants.USEDMEMORY)%></th>
 	<th><%= lang.readGm(GMLangConstants.TOTALMEMORY)%></th>
    <th><%= lang.readGm(GMLangConstants.CPURATE)%></th>
    <th><%= lang.readGm(GMLangConstants.UPDATE_TIME)%></th>
 	<th><%= lang.readGm(GMLangConstants.VERSION_NUM)%></th>
  </tr>
  <c:forEach items="${gameServerList}" var="s">
      <tr>
        <td>&nbsp;${s.serverName}</td>
        <td>&nbsp;<%=lang.readGm(GMLangConstants.GAMESERVER)%></td>
	    <td>&nbsp;${s.ip}</td>
        <td>&nbsp;${s.port}</td>
        <td>&nbsp;${s.onlineNum}</td>
        <td>&nbsp;${s.freeMemory}</td>
        <td>&nbsp;${s.usedMemory}</td>
        <td>&nbsp;${s.totalMemory}</td>
        <td>&nbsp;${s.cpuRate}</td>
        <td>&nbsp;${s.timestamp}</td>
		<td>&nbsp;${s.version}</td> 
      </tr>
 	</c:forEach>
</tbody></table>

<table class="detail no_bottom"  width="90%" cellspacing="0" cellpadding="0" border="0" align="center">
  <tbody><tr>
    <th width="30%"><%= lang.readGm(GMLangConstants.TOTAL_ONLINE_NUM)%></th>
    <th>&nbsp;${totalOnlineNum}</th>
  </tr>
</tbody></table>

<table class="detail no_bottom"   width="90%" cellspacing="0" cellpadding="0" border="0" align="center">
  <tbody><tr>
    <th><%= lang.readGm(GMLangConstants.COMMON_SERVER)%><%= lang.readGm(GMLangConstants.COMMON_NAME)%></th>
    <th><%= lang.readGm(GMLangConstants.CARDTYPE)%></th>
	<th><%= lang.readGm(GMLangConstants.IP_ADDRESS)%></th>
	<th><%= lang.readGm(GMLangConstants.PORT)%></th>
	<th><%= lang.readGm(GMLangConstants.FREEMEMORY)%></th>
 	<th><%= lang.readGm(GMLangConstants.USEDMEMORY)%></th>
 	<th><%= lang.readGm(GMLangConstants.TOTALMEMORY)%></th>
    <th><%= lang.readGm(GMLangConstants.CPURATE)%></th>
    <th><%= lang.readGm(GMLangConstants.COMMON_STATE)%></th>
    <th><%= lang.readGm(GMLangConstants.UPDATE_TIME)%></th>
    <th><%= lang.readGm(GMLangConstants.VERSION_NUM)%></th>
  </tr>
  <c:forEach items="${dbsList}" var="s">
      <tr>
        <td>&nbsp;${s.serverName}</td>
        <td><%=lang.readGm(GMLangConstants.DBSSERVER)%></td>
		<td>&nbsp;${s.ip}</td>
        <td>&nbsp;${s.port}</td>
        <td>&nbsp;${s.freeMemory}</td>
        <td>&nbsp;${s.usedMemory}</td>
        <td>&nbsp;${s.totalMemory}</td>
        <td>&nbsp;${s.cpuRate}</td>
        <td>&nbsp;${s.agentStatus}</td>
        <td>&nbsp;${s.timestamp}</td>
		<td>&nbsp;${s.version}</td> 
      </tr>
 	</c:forEach>
</tbody></table>

<table  class="detail no_bottom"  width="90%" cellspacing="0" cellpadding="0" border="0" align="center">
  <tbody><tr>
    <th><%= lang.readGm(GMLangConstants.COMMON_SERVER)%><%= lang.readGm(GMLangConstants.COMMON_NAME)%></th>
    <th><%= lang.readGm(GMLangConstants.CARDTYPE)%></th>
	<th><%= lang.readGm(GMLangConstants.IP_ADDRESS)%></th>
	<th><%= lang.readGm(GMLangConstants.PORT)%></th>
	<th><%= lang.readGm(GMLangConstants.FREEMEMORY)%></th>
 	<th><%= lang.readGm(GMLangConstants.USEDMEMORY)%></th>
 	<th><%= lang.readGm(GMLangConstants.TOTALMEMORY)%></th>
    <th><%= lang.readGm(GMLangConstants.CPURATE)%></th>
    <th><%= lang.readGm(GMLangConstants.PET_CACHE_STATUS)%></th>
	<th><%= lang.readGm(GMLangConstants.ITEM_CACHE_STATUS)%></th>
	<th><%= lang.readGm(GMLangConstants.WALLOW_CONTROLLED)%></th>
	<th><%= lang.readGm(GMLangConstants.UPDATE_TIME)%></th>
	<th><%= lang.readGm(GMLangConstants.VERSION_NUM)%></th>
  </tr>
  <c:forEach items="${wsList}" var="s">
      <tr>
        <td>&nbsp;${s.serverName}</td>
        <td>&nbsp;<%=lang.readGm(GMLangConstants.WSSERVER)%></td>
		<td>&nbsp;${s.ip}</td>
        <td>&nbsp;${s.port}</td>
        <td>&nbsp;${s.freeMemory}</td>
        <td>&nbsp;${s.usedMemory}</td>
        <td>&nbsp;${s.totalMemory}</td>
        <td>&nbsp;${s.cpuRate}</td>
		<td>&nbsp;${s.petCacheStatus}</td>
		<td>&nbsp;${s.itemCacheStatus}</td>
		<td>&nbsp;
		 <c:choose>
          <c:when test="${s.wallowControlled eq 'false'}">
            <%= lang.readGm(GMLangConstants.CLOSE)%>
          </c:when>
		  <c:when test="${s.wallowControlled eq 'true'}">
            <%= lang.readGm(GMLangConstants.OPEN)%>
          </c:when>
        </c:choose>
		</td>
		<td>&nbsp;${s.timestamp}</td>
		<td>&nbsp;${s.version}</td> 
      </tr>
 	</c:forEach>
</tbody></table>

<table class="detail no_bottom"  width="90%" cellspacing="0" cellpadding="0" border="0" align="center">
  <tbody><tr>
    <th><%= lang.readGm(GMLangConstants.COMMON_SERVER)%><%= lang.readGm(GMLangConstants.COMMON_NAME)%></th>
    <th><%= lang.readGm(GMLangConstants.CARDTYPE)%></th>
	<th><%= lang.readGm(GMLangConstants.IP_ADDRESS)%></th>
	<th><%= lang.readGm(GMLangConstants.PORT)%></th>
	<th><%= lang.readGm(GMLangConstants.FREEMEMORY)%></th>
 	<th><%= lang.readGm(GMLangConstants.USEDMEMORY)%></th>
 	<th><%= lang.readGm(GMLangConstants.TOTALMEMORY)%></th>
    <th><%= lang.readGm(GMLangConstants.CPURATE)%></th>
	<th><%= lang.readGm(GMLangConstants.UPDATE_TIME)%></th>
	<th><%= lang.readGm(GMLangConstants.VERSION_NUM)%></th>
    <th><%= lang.readGm(GMLangConstants.FIREWALL_STATUS)%></th>
  </tr>
  <c:forEach items="${lsList}" var="s">
      <tr>
        <td>&nbsp;${s.serverName}</td>
        <td><%=lang.readGm(GMLangConstants.LSSERVER)%></td>
		<td>&nbsp;${s.ip}</td>
        <td>&nbsp;${s.port}</td>
        <td>&nbsp;${s.freeMemory}</td>
        <td>&nbsp;${s.usedMemory}</td>
        <td>&nbsp;${s.totalMemory}</td>
        <td>&nbsp;${s.cpuRate}</td>
        <td>&nbsp;${s.timestamp}</td>
		<td>&nbsp;${s.version}</td> 
		<td>&nbsp;
        <c:choose>
          <c:when test="${s.loginWallEnabled eq 'false'}">
            <%= lang.readGm(GMLangConstants.CLOSE)%>
          </c:when>
		  <c:when test="${s.loginWallEnabled eq 'true'}">
            <%= lang.readGm(GMLangConstants.OPEN)%>
          </c:when>
        </c:choose>
		</td>
      </tr>
 	</c:forEach>
</tbody></table>

<table class="detail no_bottom"  width="90%" cellspacing="0" cellpadding="0" border="0" align="center">
  <tbody><tr>
    <th><%= lang.readGm(GMLangConstants.COMMON_SERVER)%><%= lang.readGm(GMLangConstants.COMMON_NAME)%></th>
    <th><%= lang.readGm(GMLangConstants.CARDTYPE)%></th>
	<th><%= lang.readGm(GMLangConstants.IP_ADDRESS)%></th>
	<th><%= lang.readGm(GMLangConstants.PORT)%></th>
	<th><%= lang.readGm(GMLangConstants.FREEMEMORY)%></th>
 	<th><%= lang.readGm(GMLangConstants.USEDMEMORY)%></th>
 	<th><%= lang.readGm(GMLangConstants.TOTALMEMORY)%></th>
    <th><%= lang.readGm(GMLangConstants.CPURATE)%></th>
    <th><%= lang.readGm(GMLangConstants.UPDATE_TIME)%></th>
	<th><%= lang.readGm(GMLangConstants.VERSION_NUM)%></th>
  </tr>
  <c:forEach items="${asList}" var="s">
      <tr>
        <td>&nbsp;${s.serverName}</td>
        <td>&nbsp;<%=lang.readGm(GMLangConstants.AGENTSERVER)%></td>
		<td>&nbsp;${s.ip}</td>
        <td>&nbsp;${s.port}</td>
        <td>&nbsp;${s.freeMemory}</td>
        <td>&nbsp;${s.usedMemory}</td>
        <td>&nbsp;${s.totalMemory}</td>
        <td>&nbsp;${s.cpuRate}</td>
        <td>&nbsp;${s.timestamp}</td>
		<td>&nbsp;${s.version}</td> 
      </tr>
 	</c:forEach>
</tbody></table>

<table class="detail no_bottom"  width="90%" cellspacing="0" cellpadding="0" border="0" align="center">
  <tbody><tr>
    <th><%= lang.readGm(GMLangConstants.COMMON_SERVER)%><%= lang.readGm(GMLangConstants.COMMON_NAME)%></th>
    <th><%= lang.readGm(GMLangConstants.CARDTYPE)%></th>
	<th><%= lang.readGm(GMLangConstants.IP_ADDRESS)%></th>
	<th><%= lang.readGm(GMLangConstants.PORT)%></th>
	<th><%= lang.readGm(GMLangConstants.FREEMEMORY)%></th>
 	<th><%= lang.readGm(GMLangConstants.USEDMEMORY)%></th>
 	<th><%= lang.readGm(GMLangConstants.TOTALMEMORY)%></th>
    <th><%= lang.readGm(GMLangConstants.CPURATE)%></th>
    <th><%= lang.readGm(GMLangConstants.UPDATE_TIME)%></th>
	<th><%= lang.readGm(GMLangConstants.VERSION_NUM)%></th>
  </tr>
  <c:forEach items="${logList}" var="s">
      <tr>
        <td>&nbsp;${s.serverName}</td>
        <td><%=lang.readGm(GMLangConstants.LOGSERVER)%></td>
		<td>&nbsp;${s.ip}</td>
        <td>&nbsp;${s.port}</td>
        <td>&nbsp;${s.freeMemory}</td>
        <td>&nbsp;${s.usedMemory}</td>
        <td>&nbsp;${s.totalMemory}</td>
        <td>&nbsp;${s.cpuRate}</td>
        <td>&nbsp;${s.timestamp}</td>
		<td>&nbsp;${s.version}</td> 
      </tr>
 	</c:forEach>
</tbody></table>

<table class="detail no_bottom"  width="90%" cellspacing="0" cellpadding="0" border="0" align="center">
  <tbody><tr>
   <th><%= lang.readGm(GMLangConstants.COMMON_SERVER)%><%= lang.readGm(GMLangConstants.COMMON_NAME)%></th>
   <th><%= lang.readGm(GMLangConstants.IP_ADDRESS)%></th>
	<th><%= lang.readGm(GMLangConstants.PORT)%></th>
   <th><%= lang.readGm(GMLangConstants.CONNECT_STATUS)%></th>
   <th><%= lang.readGm(GMLangConstants.CONNECT_TIME)%></th>
   <th><%= lang.readGm(GMLangConstants.VERSION_NUM)%></th>	
  </tr>
  <tr>
   <td>&nbsp;${dbServer.dbServerName}</td>
   <td>&nbsp;${dbServer.dbIp}</td>
   <td>&nbsp;${dbServer.dbport}</td>
   <td>&nbsp;
   <c:choose>
    <c:when test="${dbServer.connectStatus eq true}">
      <%= lang.readGm(GMLangConstants.CONNECT_SUCCESS)%>
    </c:when>
    <c:otherwise>
     <%= lang.readGm(GMLangConstants.CONNECT_FAIL)%>
    </c:otherwise>
   </c:choose>
   </td>
   <td>&nbsp;${dbServer.connectTime} <%= lang.readGm(GMLangConstants.MS)%></td>
   <td>&nbsp;${dbVersion}</td>	
  </tr>
</tbody></table>

</div>
</body>
</html>