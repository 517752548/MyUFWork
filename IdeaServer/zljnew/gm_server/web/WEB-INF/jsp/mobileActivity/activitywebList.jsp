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
<%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_ACTIVY_WEB_NAME)%>

</div>
<table class="detail" cellspacing="0" cellpadding="0" border="0" >
	<tbody>
		<tr>
		 <th width="5%"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_ID)%></th>
		 <th width="10%"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_START_TIME)%></th>
 		 <th width="10%"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_END_TIME)%></th>
 		 <!-- 
		 <th width="20%"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_PRIZE_NAME)%></th>
		  -->
		 <th width="10%"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_NAME)%></th>
		 <th width="20%"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_DESC)%></th>
		 <th width="5%"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_USE_OR_NOT)%></th>
		
		 <th width="5%"><%=lang.readGm(GMLangConstants.CEO_WAR_CRAFT_OPERATION)%></th>
		 <th width="5%"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_CURRENT_COPY)%></th>
		  <th width="10%"><%=lang.readGm(GMLangConstants.ACTIVITY_WEB_SERVERIDS)%></th>
		</tr>
     <c:forEach items="${mobileActivityShowData}" var="mobileActivityShow">
        <tr>
        <c:choose>
        <%-- 强制关闭 --%>
        <c:when test="${mobileActivityShow.forceEndOrNot eq 1}">
        	<td bgcolor="ffff00">&nbsp;${mobileActivityShow.id}</td>
        </c:when>
        <%-- 没发奖 --%>
        <c:when test="${mobileActivityShow.givePrizeOrNot eq 1}">
        	<td bgcolor="#0000ff">&nbsp;${mobileActivityShow.id}</td>
        </c:when>
        <%-- 发完奖 --%>
         <c:when test="${mobileActivityShow.givePrizeOrNot eq 2}">
        	<td bgcolor="00ff00">&nbsp;${mobileActivityShow.id}</td>
        </c:when>
        <c:otherwise>
        	<td bgcolor="00ffff">&nbsp;${mobileActivityShow.id}</td>
        </c:otherwise>
        </c:choose>
		 <td>&nbsp;${mobileActivityShow.startDate}&nbsp;${mobileActivityShow.startTime}</td>
		 <td>&nbsp;${mobileActivityShow.endDate}&nbsp;${mobileActivityShow.endTime}</td>
         <!-- 
         <td>&nbsp;${mobileActivityShow.mobilePrizeGrepsName}</td>
          -->
         <td>&nbsp;${mobileActivityShow.name}</td>
         <td>&nbsp;${mobileActivityShow.descMobileActivity}</td>
         <!-- 未关闭的活动才能操作 -->
         <c:if test="${mobileActivityShow.isClosed eq 0}">
          <c:choose>
          	<%-- 可用--%>
              	<c:when test="${mobileActivityShow.useOrNot eq 1}">
              	<td bgcolor="00ff00">&nbsp;
              	<%-- 不可用按钮  --%>
              	<input class="butcom" type="button" value="<%= lang.readGm(GMLangConstants.MOBILE_ACTIVITY_NOT_USE)%>" onClick="javaScript:window.location.href='mobileActivity.do?action=updateUseOrNotNotUse&Id=${mobileActivityShow.id}';"/>
        	 	 </td>
        	  	</c:when> 
        	  	<%-- 不可用--%>
        	  	<c:when test="${mobileActivityShow.useOrNot eq 0}">
        	  	<td bgcolor="ff0000">&nbsp;
        	  	<%-- 可用按钮  --%>
              		<input class="butcom" type="button" value="<%= lang.readGm(GMLangConstants.MOBILE_ACTIVITY_USE)%>" onClick="javaScript:window.location.href='mobileActivity.do?action=updateUseOrNotUse&Id=${mobileActivityShow.id}';"/>
        	  	 </td>
        	  	</c:when> 
        	  	<%-- 其他  --%>
        	  	<c:otherwise>
        	  	<td>&nbsp;
        	  		<%-- 可用按钮  --%>
              		<input class="butcom" type="button" value="<%= lang.readGm(GMLangConstants.MOBILE_ACTIVITY_USE)%>" onClick="javaScript:window.location.href='mobileActivity.do?action=updateUseOrNotUse&Id=${mobileActivityShow.id}';"/>
        	  		<%-- 不可用按钮  --%>
              		<input class="butcom" type="button" value="<%= lang.readGm(GMLangConstants.MOBILE_ACTIVITY_NOT_USE)%>" onClick="javaScript:window.location.href='mobileActivity.do?action=updateUseOrNotNotUse&Id=${mobileActivityShow.id}';"/>
        	  	 </td>
        	  	</c:otherwise>
         	</c:choose>
         	</c:if>	
         	 <c:if test="${mobileActivityShow.isClosed eq 1}">
         	 <td>&nbsp;</td>
         	 </c:if>	
         <td>&nbsp;
         <!-- 未关闭的活动才能操作 -->
         <c:if test="${mobileActivityShow.isClosed eq 0}">
		<input class="butcom" type="button" value="<%= lang.readGm(GMLangConstants.CEO_WAR_CRAFT_OPERATION_STR)%>" onClick="javaScript:window.location.href='mobileActivity.do?action=updateMobileActivity&Id=${mobileActivityShow.id}';"/>
		</c:if>	
		</td>	
		<td>&nbsp;
		<!-- 强制关闭的活动不能复制 -->
		<c:if test="${mobileActivityShow.forceEndOrNot eq 0}">
		<input class="butcom" type="button" value="<%= lang.readGm(GMLangConstants.MOBILE_ACTIVITY_CURRENT_COPY)%>" onClick="javaScript:window.location.href='mobileActivity.do?action=copyMobileActivity&Id=${mobileActivityShow.id}';"/>
		</c:if>	
		</td>
		
		<td>${mobileActivityShow.sIds}</td>
		</tr>
     </c:forEach>
      <tr>
      <td style="border-bottom: 0px;">
     		<input class="butcom" type="button" value="<%= lang.readGm(GMLangConstants.CLOSE_ALL_GOING_ACTIVITY)%>" 
		 				onClick="javascript:if(window.confirm('确认关闭所有正在进行的精彩活动吗？'))window.location.href='mobileActivity.do?action=closeAllGoingActivity';"/>
    	</td>
       <td height="30" colspan="3" style="border-bottom: 0px;">
     		<input  class="butcom" type="button" value="<%= lang.readGm(GMLangConstants.CEOWAR_CRAFT_INSERT)%>" onClick="insertMobileActivity();"/>
    	</td>
    	
    	<td height="30" colspan="3" style="border-bottom: 0px;">
     		<input  class="butcom" type="button" value="<%= lang.readGm(GMLangConstants.START_PRESET_ACTIVITY)%>" onClick="editPresetActivity();"/>
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
	window.location.href="mobileActivity.do?action=insertMobileActivity";
}

function closeAllGoingActivity(){
	window.location.href="mobileActivity.do?action=closeAllGoingActivity";
}

function editPresetActivity(){
	window.location.href="mobileActivity.do?action=editPresetActivity";
}
</script>
</body>
</html>