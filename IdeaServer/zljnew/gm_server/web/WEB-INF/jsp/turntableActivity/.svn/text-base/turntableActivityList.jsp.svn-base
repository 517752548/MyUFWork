<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
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
<a href="homePage.do?action=welcome"><%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>>>
<%=lang.readGm(GMLangConstants.TURNTABLE_ACTIVITY_DESC)%>

</div>
<table class="detail" cellspacing="0" cellpadding="0" border="0" >
	<tbody>
	
		<tr>
		<th width="10%"><%=lang.readGm(GMLangConstants.ACTIVITY_TYPE)%>
			<select id="fType" name="fType" onchange="tt(this.value);">
				<c:forEach items="${fTypeMap}" var="m">
				<option value="${m.key}">${m.value}</option>
				</c:forEach>
			</select>
		</th>
		 <th width="5%"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_ID)%></th>
		 <th width="10%"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_START_TIME)%></th>
 		 <th width="10%"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_END_TIME)%></th>
 		  <th width="10%"><%=lang.readGm(GMLangConstants.IS_STARTED)%></th>
 		  <th width="10%"><%=lang.readGm(GMLangConstants.IS_CLOSED)%></th>
 		  <th width="10%"><%=lang.readGm(GMLangConstants.IS_FORCE_END)%></th>
 		  <th width="10%"><%=lang.readGm(GMLangConstants.ACTIVITY_WEB_SERVERIDS)%></th>
		</tr>
     <c:forEach items="${mobileActivityShowData}" var="mobileActivityShow">
        <tr name="arow" sname="arow${mobileActivityShow.fType}">
        <td >&nbsp;${mobileActivityShow.fTypeName}(${mobileActivityShow.fType})</td>
        <c:choose>
        <%-- 强制关闭 --%>
        <c:when test="${mobileActivityShow.forceEndOrNot eq 1}">
        	<td bgcolor="ffff00">&nbsp;${mobileActivityShow.id}</td>
        </c:when>
        <c:otherwise>
        	<td bgcolor="00ffff">&nbsp;${mobileActivityShow.id}</td>
        </c:otherwise>
        </c:choose>
		 <td>&nbsp;${mobileActivityShow.startDate}&nbsp;${mobileActivityShow.startTime}</td>
		 <td>&nbsp;${mobileActivityShow.endDate}&nbsp;${mobileActivityShow.endTime}</td>
		 <td>&nbsp;
		 	<c:if test="${mobileActivityShow.isStarted eq 1}"><%=lang.readGm(GMLangConstants.YES)%></c:if>
		 	<c:if test="${mobileActivityShow.isStarted eq 0}"><%=lang.readGm(GMLangConstants.NO)%></c:if>
		 </td>
		 <td>&nbsp;
		 	<c:if test="${mobileActivityShow.isClosed eq 1}"><%=lang.readGm(GMLangConstants.YES)%></c:if>
		 	<c:if test="${mobileActivityShow.isClosed eq 0}"><%=lang.readGm(GMLangConstants.NO)%></c:if>
		 </td>
		 <td <c:if test="${mobileActivityShow.forceEndOrNot eq 1}">bgcolor="ffff00"</c:if>>&nbsp;
		 	
		 	<c:if test="${mobileActivityShow.forceEndOrNot eq 0}">
		 		<c:choose>
			 	<c:when test="${mobileActivityShow.isClosed eq 1}">
			 		${mobileActivityShow.endDate}&nbsp;${mobileActivityShow.endTime}
				</c:when>
				<c:otherwise>
		 			<input class="butcom" type="button" value="<%= lang.readGm(GMLangConstants.MOBILE_ACTIVITY_FORCE)%>" 
		 				onClick="javascript:if(window.confirm('确认强制关闭该活动吗？id=${mobileActivityShow.id}|${mobileActivityShow.fTypeName}'))window.location.href='turntableActivity.do?action=updateUseOrNotNotUse&Id=${mobileActivityShow.id}';"/>
				</c:otherwise>
				</c:choose>
			</c:if>
		 	<c:if test="${mobileActivityShow.forceEndOrNot eq 1}">
		 		${mobileActivityShow.forceCloseDate}&nbsp;${mobileActivityShow.forceCloseTime}
			</c:if>
		 </td>
		 
		 <td>${mobileActivityShow.sIds}</td>
		
		</tr>
     </c:forEach>
      <tr>
       <td height="30" colspan="30" style="border-bottom: 0px;">
     		<input  class="butcom" type="button" value="<%= lang.readGm(GMLangConstants.CEOWAR_CRAFT_INSERT)%>" onClick="insertMobileActivity();"/></td>
    	</td>
      </tr>
    <tr>
    <td height="30" colspan="30" style="border-bottom: 0px;">
     <jsp:include page="../page.jsp"></jsp:include>
    </td>
  </tr>
   </tbody>
</table>
</div>
<script type="text/javascript">
function insertMobileActivity(){
	window.location.href="turntableActivity.do?action=insertMobileActivity";
}
function forceClose(id) {
	
}

function tt(v) {
	var rowId = "arow"+v;
	//alert(rowId);
	
	var x = document.getElementsByName("arow");
	for (var i=0;i<x.length;i++) {
		//alert(x[i].getAttribute("sname"));
		
		x[i].style.display="none";
		if (x[i].getAttribute("sname") == rowId) {
			x[i].style.display="";
		} 
	}
}
</script>
</body>
</html>