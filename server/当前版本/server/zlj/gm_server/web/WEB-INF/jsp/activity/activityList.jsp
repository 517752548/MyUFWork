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
<a href="homePage.do?action=welcome"><%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>>><%=lang.readGm(GMLangConstants.GAME)%><%=lang.readGm(GMLangConstants.ACTIVITY)%>
</div>
<c:if test="${DBType eq 1}"><div style="text-align: right;margin-right: 2em;margin-top: 0.5em;">
<input type="button" value="<%=lang.readGm(GMLangConstants.PUBLISH)%>" class="butcom" onclick="javaScript:reloadActivity();"/>
</div>
</c:if>
<table class="detail"  cellspacing="0" 	cellpadding="0" border="0">
	<tbody>
		<tr>
			<th><%=lang.readGm(GMLangConstants.ACTIVITY)%><%=lang.readGm(GMLangConstants.ID)%></th>
			<th><%=lang.readGm(GMLangConstants.ACTIVITY_NAME)%></th>
			<th><%=lang.readGm(GMLangConstants.START_DATE)%></th>
			<th><%=lang.readGm(GMLangConstants.END_DATE)%> </th>
			<th><%=lang.readGm(GMLangConstants.ACT_DES)%></th>
			<th><%=lang.readGm(GMLangConstants.WEL_SERVERS)%></th>
			<th><%=lang.readGm(GMLangConstants.COMMON_STATE)%></th>
			<th><%=lang.readGm(GMLangConstants.OPEN_TYPE)%></th>
			<c:if test="${DBType eq 1}">
			<th><%=lang.readGm(GMLangConstants.COMMON_OPERATION)%> <img class="pointer link" src="images/add.gif" title="<%=lang.readGm(GMLangConstants.ADD)%>"
				onclick="javaScript:window.location='activity.do?action=editActivity'" /></th>
            </c:if>
		</tr><c:forEach items="${activityList}" var="activity"><tr><td>&nbsp;${activity.id}</td>
				<td>&nbsp;${activity.name}</td>
				<td>&nbsp;${activity.startDay}</td>
				<td>&nbsp;${activity.endDay}</td>
				<td>&nbsp;${activity.description}</td>
				<td>&nbsp;${activity.serverId}</td>
				<td>&nbsp;<c:choose><c:when test="${activity.status eq 0}"><%=lang.readGm(GMLangConstants.CLOSE)%></c:when>
				 <c:when test="${activity.status eq 1}"><%=lang.readGm(GMLangConstants.OPEN)%></c:when>
				</c:choose>
				</td>
				<td>&nbsp;<c:choose><c:when test="${activity.openType eq 0}">
				 	<%=lang.readGm(GMLangConstants.ALL_OPEN)%>
				 </c:when><c:when test="${activity.openType eq 1}">
				 	<%=lang.readGm(GMLangConstants.PART_OPEN)%>
				 </c:when></c:choose></td>
				<c:if test="${DBType eq 1}">
				<td>&nbsp;<span style="padding: 10px;" /> <img class="pointer" title="<%=lang.readGm(GMLangConstants.COMMON_DELETE)%>" 
					src="images/b_drop.png"
					onclick="javaScript:delActivity('${activity.id}');" /> <img 
					border="0" title="<%=lang.readGm(GMLangConstants.EDIT)%>"
					src="images/b_edit.png"
					onclick="javaScript:window.location='activity.do?action=editActivity&id=${activity.id}'"  />
              	</td>
				</c:if>		
				</tr></c:forEach>
        <tr>
			<td height="30" colspan="10" style="border-bottom: 0px;"><jsp:include
				page="../page.jsp"></jsp:include>
			</td>
		</tr>
	</tbody>
</table>
</div>
<script type="text/javascript">
function reloadActivity(){
	$.post("activity.do?action=reloadActivity",function(info){
		if($.trim(info)=="ok"){
			alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
		}else{
			alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
			}
	});
}
function delActivity(id){
	var con= confirm("<%=lang.readGm(GMLangConstants.CONFRIM_DEL)%>?");
	if(con){
		$.post("activity.do?action=delActivity",{id:id},function(){
	        alert("<%=lang.readGm(GMLangConstants.DEL_SUCCESS)%>");
	        window.location='activity.do?action=init';
		  });
	}
}
function releaseGameactivity(id){
	$.post("gameactivity.do?action=releaseGameactivity",{id:id},function(info){
		var data = $.trim(info);
		if("true"==data){
			 alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
		}else{
			 alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
			 	}
		        window.location='gameactivity.do?action=init';
		    });
	}
function goTo(i){
	  window.location.href="activity.do?action=init&currentPage="+i;
 }
</script>
</body>
</html>