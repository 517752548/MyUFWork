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
<c:if test="${type eq 0}">
<%=lang.readGm(GMLangConstants.WEL_TIME_NOTICE)%>
</c:if>
<c:if test="${type eq 1}">
<%=lang.readGm(GMLangConstants.WEL_CHAT_TIME_NOTICE)%>
</c:if>
</div>
<div class="nofloat" />
<table class="detail"    cellspacing="0" cellpadding="0" 
	border="0" >
	<tbody>
		<tr>
         <th width="10%"><%=lang.readGm(GMLangConstants.NOTICE)%><%=lang.readGm(GMLangConstants.ID)%></th>
		 <th width="10%"><%=lang.readGm(GMLangConstants.WEL_SERVERS)%></th>
		 <th width="10%"><%=lang.readGm(GMLangConstants.START_TIME)%></th>
 		 <th width="10%"><%=lang.readGm(GMLangConstants.END_TIME)%></th>
		 <th width="10%"><%=lang.readGm(GMLangConstants.INTERVAL)%></th>
		 <th width="25%"><%=lang.readGm(GMLangConstants.CONTENT)%></th>
		 <c:if test="${type eq 1}">
			 <th width="5%"><%=lang.readGm(GMLangConstants.NOTICE_TYPE)%>
	     </c:if>
		 <th><%=lang.readGm(GMLangConstants.OPEN_TYPE)%></th>
   		 <c:if test="${DBType eq 1}">
			 <th width="10%"><%=lang.readGm(GMLangConstants.COMMON_OPERATION)%>
	         <img  class="pointer" title="<%=lang.readGm(GMLangConstants.ADD)%><%=lang.readGm(GMLangConstants.WEL_TIME_NOTICE)%>" src="images/add.gif" onclick="javaScript:window.location='timeNotice.do?action=editTimeNotice&type=${type}&subType=0'"/></th>
		 </c:if>
		</tr>
     <c:forEach items="${timeNoticeList}" var="notice">
        <tr>
		 <td>&nbsp;${notice.id}</td>
         <td>&nbsp;${notice.serverIds}</td>
         <td>&nbsp;<fmt:formatDate pattern="yyyy-MM-dd HH:mm" value="${notice.startTime}" /></td>
		 <td>&nbsp;<fmt:formatDate pattern="yyyy-MM-dd HH:mm" value="${notice.endTime}" /></td>
         <td>&nbsp;${notice.intervalTime}<%=lang.readGm(GMLangConstants.SECOND)%></td>
         <td>&nbsp;${notice.content}</td>
 		 <c:if test="${type eq 1}">
		 <td>&nbsp;
			<c:choose>
			     <c:when test="${notice.subType eq 0}">
				 	<%=lang.readGm(GMLangConstants.NOTICE_TYPE_NOTICE_SHOW)%>
				 </c:when>
				 <c:when test="${notice.subType eq 1}">
				 	<%=lang.readGm(GMLangConstants.NOTICE_TYPE_GM_SHOW)%>
				 </c:when>
 				<c:when test="${notice.subType eq 2}">
				 	<%=lang.readGm(GMLangConstants.NOTICE_TYPE_NPC_SHOW)%>
				 </c:when>
				 <c:when test="${notice.subType eq 3}">
				 	<%=lang.readGm(GMLangConstants.NOTICE_TYPE_OTHER_SHOW)%>
				 </c:when>
			</c:choose>
		 </td>
	     </c:if>
		 <td>&nbsp;<c:choose><c:when test="${notice.openType eq 0}">
				 	<%=lang.readGm(GMLangConstants.ALL_OPEN)%>
				 </c:when><c:when test="${notice.openType eq 1}">
				 	<%=lang.readGm(GMLangConstants.PART_OPEN)%>
				 </c:when></c:choose>
		 </td>
		<c:if test="${DBType eq 1}">
         <td>&nbsp;
			<img class="pointer" title="<%=lang.readGm(GMLangConstants.EDIT)%>"   src="images/b_edit.png" onclick="javaScript:window.location='timeNotice.do?action=editTimeNotice&id=${notice.id}&type=${type}&subType=${notice.subType}'"/> <span style="padding: 10px;"/>
            <img class="pointer" title="<%=lang.readGm(GMLangConstants.COMMON_DELETE)%>"  src="images/b_drop.png" onclick="javaScript:delTimeNotice('${notice.id}');"/>
			<c:if test="${type eq 1}">
				<img border="0" title="<%=lang.readGm(GMLangConstants.RELEASE)%>"
					src="images/notice.gif"
					onclick="javaScript:releaseTimeNotice('${notice.id}');"  />
			</c:if>
         </td>
		</c:if>
		</tr>
     </c:forEach>
    <tr>
    <td height="30" colspan="8" style="border-bottom: 0px;">
     <jsp:include page="../page.jsp"></jsp:include>
    </td>
  </tr>
   </tbody>
</table>
</div>
<script type="text/javascript">
function delTimeNotice(id){
	var con= confirm("<%=lang.readGm(GMLangConstants.CONFRIM_DEL)%>?");
	if(con){
		$.post("timeNotice.do?action=delTimeNotice",{id:id},function(){
	        alert("<%=lang.readGm(GMLangConstants.DEL_SUCCESS)%>");
	        window.location='timeNotice.do?action=init&type=${type}';
		  });	

	}
}
function goTo(i){
	  window.location.href="timeNotice.do?action=init&type=${type}&currentPage="+i;
}
function releaseTimeNotice(id){
	$.post("timeNotice.do?action=releaseTimeNotice",{id:id},function(info){
		var data = $.trim(info);
		if("true"==data){
			 alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
		}else{
			 alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
			 	}
		        window.location='timeNotice.do?action=init&type=${type}';
		    });
}
</script>
</body>
</html>