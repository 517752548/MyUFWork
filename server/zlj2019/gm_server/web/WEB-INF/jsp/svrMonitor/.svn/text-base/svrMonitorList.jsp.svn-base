<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<%@ page import="com.imop.lj.gm.service.db.DBFactoryService"%>
<%@ page import="com.imop.lj.gm.service.maintenance.SvrMonitorService"%>
<%@ page import="com.imop.lj.gm.constants.SystemConstants"%>
<%
	DBFactoryService dbFaSvr = (DBFactoryService) (wac.getBean("dbFactoryService"));
	SvrMonitorService svrMon = (SvrMonitorService) (wac.getBean("svrMonitorService"));
	pageContext.setAttribute("dbFaSvr",dbFaSvr);
	pageContext.setAttribute("svrMon",svrMon);
	boolean chechSwitchBln = SystemConstants.getScanState();
%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>mop</title>
<script type="text/javascript">
	$().ready(function(){
		var checkswitch=$.trim($("#checkswitch").val());
		if(checkswitch=="true"){
			$("#switchBut").val("<%=lang.readGm(GMLangConstants.STOP_SCAN)%>");
		}else if(checkswitch=="false"){
			$("#switchBut").val("<%=lang.readGm(GMLangConstants.START_SCAN)%>");
		}
	  });
</script>
</head>
<body>
<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>
<%=lang.readGm(GMLangConstants.ALARM_MONITOR)%></div>
<div class="nofloat"></div>
<table class="detail no_bottom" style="width:20%;margin-left:5px;float: left" cellspacing="0" cellpadding="0" border="0">
  <tbody><tr>
    <td class="header" colspan="2"><%= lang.readGm(GMLangConstants.OPERATION_IN_REGION)%></td>
  </tr>
  <tr>
      <td><input id="checkswitch" type='hidden' name='checkswitch' value="<%= chechSwitchBln %>" />
		<input id="switchBut" type="button" onclick="switchBut();" class="butcom" name="switchBut" value="<%=lang.readGm(GMLangConstants.STOP_SCAN)%>"/></td>
      <td><input id="scanAll"  type="button" onclick="scanAll();"  class="butcom" name="scanAll" value="<%= lang.readGm(GMLangConstants.SCAN_ALL)%>"/></td>
  </tr>
  </tbody></table>
<table class="detail no_bottom" style="width:60%;margin-left:5px;float: left"" cellspacing="0" cellpadding="0" border="0">
  <tbody><tr>
    <td class="header" colspan="2"><%= lang.readGm(GMLangConstants.OPERATION_MSG)%></td>
  </tr>
  <tr>
      <td width="12%" class="label"><%= lang.readGm(GMLangConstants.ATTENTIONS)%></td>
      <td><%= lang.readGm(GMLangConstants.MONITOR_MSG)%></td>
  </tr>
  </tbody></table>
<div class="nofloat"></div>
<c:forEach items="${svrGroupList}" var="svrGroupMap" varStatus="status">
<c:if test="${status.index %4 eq 0}"><div class="nofloat"></div></c:if>
<table class="detail no_bottom"  style="width:20%;margin-left:5px;float: left" cellspacing="0" cellpadding="0" border="0">
  <tbody>
	<tr>
    	<th  colspan="2" id="header${status.index}">
		<a style="text-decoration: underline;" href="#" onclick="javascript:window.open('svrMonitor.do?action=showDetail&id=${svrGroupMap.key}','newwindow','width=1400,height=700,top=0,left=0,toolbar=no,menubar=no,scrollbars=yes,resizable=no,location=no,status=no');">${dbFaSvr.getServer(svrGroupMap.key).dbServerName}</a>
		 <span style="margin-left: 20px;;color: #0033FF"><%= lang.readGm(GMLangConstants.ONLINE_NUM)%>:${svrGroupMap.value.onlineNum}</span>
         </th>
		</tr>
	<tr onclick="switchSvr($(this),'${status.index}');" hideFlag="true" style="cursor: pointer;">
		<td class="header"><img id="switchImg${status.index}"  src="images/arrow_unfold.png" /> <%= lang.readGm(GMLangConstants.COMMON_SERVER)%><%= lang.readGm(GMLangConstants.COMMON_NAME)%></td>
		<td class="header"><%= lang.readGm(GMLangConstants.COMMON_STATE)%>
			<c:choose>
  	     	<c:when test="${svrMon.getLoginWallStatus(svrGroupMap.key) eq 'true'}">
  	     	  <span style="color: yellow;">(<%= lang.readGm(GMLangConstants.FIREWALL_OPEN)%>)</span>
  	     	</c:when>
			<c:otherwise>
  	     	   (<%= lang.readGm(GMLangConstants.FIREWALL_CLOSE)%>)
  	     	</c:otherwise>
  	     </c:choose>
		</td>
	</tr>
	<tr>
		<td class="label">${svrGroupMap.value.serverName}</td>
		<td><c:choose>
			<c:when test="${svrGroupMap.value.state eq true}">
			 <%= lang.readGm(GMLangConstants.CONNECT_SUCCESS)%>
			</c:when>
			<c:otherwise>
			 <span class="red"><%= lang.readGm(GMLangConstants.CONNECT_FAIL)%></span>
			  <script>
				 $("#header${status.index}").attr("style","background-color: red");
				 $("#header${status.index}").attr("red","red");
			  </script>
			</c:otherwise>
			</c:choose>
			<c:choose>
			  <c:when test="${svrGroupMap.value.svrVersion eq null}">
			  </c:when>
			  <c:when test="${svrGroupMap.value.svrVersion eq s1Version}">
			  	(${svrGroupMap.value.svrVersion})
			  </c:when>
              <c:otherwise>
                <span class="red">(${svrGroupMap.value.svrVersion})</span>
				<script>
				 var color = $("#header${status.index}").attr("red");
			     if(color!='red'){
			    	 $("#header${status.index}").attr("style","background-color: yellow");
				 }
			  	</script>
			  </c:otherwise>
			</c:choose>
			</td>
     </tr>
   <c:forEach items="${svrGroupMap.value.svrList}" var="svrObj" >
    <tr name="svrList_${status.index}" style="display: none;">
		<td class="label">${svrObj.serverName}</td>
		<td>
		<c:choose>
			<c:when test="${svrObj.state eq true}">
			 <%= lang.readGm(GMLangConstants.CONNECT_SUCCESS)%>
			</c:when>
			<c:otherwise>
			 <span class="red"><%= lang.readGm(GMLangConstants.CONNECT_FAIL)%></span>
			  <script>
				 $("#header${status.index}").attr("style","background-color: red");
				 $("#header${status.index}").attr("red","red");
			  </script>
			</c:otherwise>
		</c:choose>
        <c:if test="${svrObj.type eq 'gs'}">(${svrObj.onlineNum})</c:if>
		</td>
	</tr>
   </c:forEach>
	<tr>
		<td class="label">${svrGroupMap.value.dbServer.serverName}</td>
		 <td><c:choose>
					<c:when test="${svrGroupMap.value.dbServer.state eq true}">
					 <%= lang.readGm(GMLangConstants.CONNECT_SUCCESS)%>
					</c:when>
					<c:otherwise>
					 <span class="red"><%= lang.readGm(GMLangConstants.CONNECT_FAIL)%></span>
					  <script>
						 $("#header${status.index}").attr("style","background-color: red");
						 $("#header${status.index}").attr("red","red");
					  </script>
					</c:otherwise>
				</c:choose>
				<c:choose>
				  <c:when test="${svrGroupMap.value.dbServer.svrVersion eq s1dbVersion}">
				  	(${svrGroupMap.value.dbServer.svrVersion})
				  </c:when>
	              <c:otherwise>
	                <span class="red">(${svrGroupMap.value.dbServer.svrVersion})</span>
					<script>
					 var color = $("#header${status.index}").attr("red");
				     if(color!='red'){
				    	 $("#header${status.index}").attr("style","background-color: yellow");
					 }
				  	</script>
				  </c:otherwise>
				</c:choose>
		</td>
     <tr>
</tbody></table>
</c:forEach>
</div>
<script type="text/javascript">
function scanAll(){
	$.post("svrMonitor.do?action=scanAll",function(info){
	  info = $.trim(info);
      if(info=="ok"){
    	  alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
    	  window.location="svrMonitor.do?action=init";
      }else{
    	  alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
      }
	});
}

function switchBut(){
	var checkswitch = $("#checkswitch").val();
	$.post("svrMonitor.do?action=setSwitchBut",{scanBut:checkswitch},function(){
      window.location="svrMonitor.do?action=init";
	});
}

function switchSvr(obj,wsId){
	  var  flag= $(obj).attr("hideFlag");
	  $("tr[name='svrList_"+wsId+"']").each(function(){
		  if(flag=="false"){
			  $(this).hide();
		  }else{
			  $(this).show();
		 }
	  });
	  if(flag=="false"){
		  $(obj).attr("hideFlag","true");
		  $("#switchImg"+wsId).attr("src","images/arrow_unfold.png")
	  }else{
		  $(obj).attr("hideFlag","false");
		  $("#switchImg"+wsId).attr("src","images/arrow_fold.png")
	 }
}


</script>
</body>
</html>