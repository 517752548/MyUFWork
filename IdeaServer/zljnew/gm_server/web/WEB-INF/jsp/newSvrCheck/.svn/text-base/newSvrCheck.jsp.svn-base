<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
</script>
</head>
<body>
<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>>><%= lang.readGm(GMLangConstants.SELF_CHECK_REPORT) %>
</div>
<div class="nofloat" />
<form id="timeNotice" name="timeNotice" method="post" action="timeNotice.do?action=addTimeNotice" onsubmit="return is_ok();">
<table name='tab_1' class="detail no_bottom" style="width:50%;" cellspacing="0"
	cellpadding="0" border="0">
	<tbody>
		<tr>
			<td colspan="4" class="header">&nbsp;<%=lang.readGm(GMLangConstants.COMMON_SERVER)%><%=lang.readGm(GMLangConstants.C_BASIC_INFO)%></td>
		</tr>
        <tr>
			<th>&nbsp;<%= lang.readGm(GMLangConstants.CHECK_CONTENT)%></th>
			<th>&nbsp;<%= lang.readGm(GMLangConstants.CHECK_DATA)%></th>
			<th>&nbsp;<%= lang.readGm(GMLangConstants.SELF_CHECK)%></th>
			<th>&nbsp;<%= lang.readGm(GMLangConstants.S1_TO_RESULT)%></th>
		</tr>  
		<tr>
			<td class="label" >&nbsp;<%= lang.readGm(GMLangConstants.COMMON_SERVER)%><%= lang.readGm(GMLangConstants.VERSION_NUM)%>
			</td>
			<td>&nbsp;${serVersion}</td>
            <td class="label" align="center" >&nbsp;<c:choose>
              	<c:when test="${serVersion ne null&& dBVersion ne null && fn:substring(serVersion.trim(),0,5) eq fn:substring(dBVersion.trim(),0,5)}">
					<img src="images/s_okay.png" border="0" title="<%= lang.readGm(GMLangConstants.VERSION_CORRECT)%>">
              	</c:when>
 				<c:otherwise>
					<img src="images/b_drop.png" border="0" title="<%= lang.readGm(GMLangConstants.VERSION_WRONG1)%>">
 				</c:otherwise>
              </c:choose>
            </td>
            <td>&nbsp;
              <c:choose>
	              	<c:when test="${s1SerVersion ne null&& serVersion ne null && serVersion.trim()  eq s1SerVersion.trim()}">
						<img src="images/s_okay.png" border="0" title="<%= lang.readGm(GMLangConstants.VERSION_CORRECT)%>">
	              	</c:when>
	 				<c:otherwise>
						<font class="red">${s1SerVersion}</font>&nbsp; &nbsp;<img src="images/b_drop.png" border="0" >
	 				</c:otherwise>
               </c:choose>
            </td> 
		</tr>
		<tr>
			<td class="label">&nbsp;<%= lang.readGm(GMLangConstants.DB)%><%= lang.readGm(GMLangConstants.VERSION_NUM)%>
			</td>
			<td>&nbsp;${dBVersion}</td>
			<td class="label" align="center" >&nbsp;
				<c:choose>
	              	<c:when test="${serVersion ne null&& dBVersion ne null && fn:substring(dBVersion.trim(),0,5) eq fn:substring(serVersion.trim(),0,5)}">
						<img src="images/s_okay.png" border="0" title="<%= lang.readGm(GMLangConstants.VERSION_CORRECT)%>">
	              	</c:when>
	 				<c:otherwise>
						<img src="images/b_drop.png" border="0" title="<%= lang.readGm(GMLangConstants.VERSION_WRONG)%>">
	 				</c:otherwise>
               </c:choose>
			</td>
			<td>&nbsp;
				<c:choose>
	              	<c:when test="${s1DbVersion ne null&& dBVersion ne null && dBVersion.trim()  eq s1DbVersion.trim()}">
						<img src="images/s_okay.png" border="0" title="<%= lang.readGm(GMLangConstants.VERSION_CORRECT)%>">
	              	</c:when>
	 				<c:otherwise>
						<font class="red">${s1DbVersion}</font> &nbsp; &nbsp;<img src="images/b_drop.png" border="0">
	 				</c:otherwise>
               </c:choose>
			</td>
		</tr>
		<tr>
		<td class="label" >&nbsp;<%= lang.readGm(GMLangConstants.SELF_INCRE_ID)%></td>
		<td>&nbsp;${autoIncrement}</td><td>&nbsp;</td><td>&nbsp;</td>
		</tr>
	</tbody>
</table>
<table name='tab_1' class="detail no_bottom" style="width:50%;" cellspacing="0"
	cellpadding="0" border="0">
	<tbody>
		<tr>
			<td colspan="4" class="header">&nbsp;<%=lang.readGm(GMLangConstants.COMMON_SERVER)%><%=lang.readGm(GMLangConstants.SYN_DATA)%></td>
		</tr>
        <tr>
			<th>&nbsp;<%= lang.readGm(GMLangConstants.CHECK_CONTENT)%></th>
			<th>&nbsp;<%= lang.readGm(GMLangConstants.SELF_CHECK_DATA)%></th>
			<th>&nbsp;<%= lang.readGm(GMLangConstants.S1_TO_DATA)%></th>
			<th>&nbsp;<%= lang.readGm(GMLangConstants.COMPARE_RESULT)%></th>
		</tr>  
		<tr>
			<td class="label" >&nbsp;<%= lang.readGm(GMLangConstants.WEL_TIME_NOTICE)%></td>
			<td>&nbsp;<c:choose>
	              	<c:when test="${timeNoticeNum eq s1TimeNoticeNum}">
						${timeNoticeNum}<%= lang.readGm(GMLangConstants.GE)%>
	              	</c:when>
	 				<c:otherwise>
						 <font class="red">${timeNoticeNum}<%= lang.readGm(GMLangConstants.GE)%></font>
	 				</c:otherwise>
               </c:choose>
			</td>
			<td>&nbsp;${s1TimeNoticeNum}<%= lang.readGm(GMLangConstants.GE)%></td>
			<td>&nbsp;<c:choose>
			     <c:when test="${timeNoticeNum eq s1TimeNoticeNum}">
					<%= lang.readGm(GMLangConstants.NOT_NEED_SYN)%>
			     </c:when>
				 <c:otherwise>
				   <font class="red"><%= lang.readGm(GMLangConstants.NEED_SYN)%></font>
				 </c:otherwise>
			    </c:choose>
            </td>
		</tr>
		<tr>
			<td class="label" >&nbsp;<%= lang.readGm(GMLangConstants.GAME)%><%= lang.readGm(GMLangConstants.NOTICE)%></td>
			<td>&nbsp;<c:choose>
	              	<c:when test="${gameNoticeNum eq s1GameNoticeNum}">
						${gameNoticeNum}<%= lang.readGm(GMLangConstants.GE)%>
	              	</c:when>
	 				<c:otherwise>
						 <font class="red">${gameNoticeNum}<%= lang.readGm(GMLangConstants.GE)%></font>
	 				</c:otherwise>
               </c:choose>
			</td>
			<td>&nbsp;${s1GameNoticeNum}<%= lang.readGm(GMLangConstants.GE)%></td>
			<td>&nbsp;<c:choose>
			     <c:when test="${gameNoticeNum eq s1GameNoticeNum}">
					<%= lang.readGm(GMLangConstants.NOT_NEED_SYN)%>
			     </c:when>
				 <c:otherwise>
				   <font class="red"><%= lang.readGm(GMLangConstants.NEED_SYN)%></font>
				 </c:otherwise>
			    </c:choose>
            </td>
		</tr>
		<tr>
			<td class="label" >&nbsp;<%= lang.readGm(GMLangConstants.GAME)%><%= lang.readGm(GMLangConstants.ACTIVITY)%></td>
			<td>&nbsp;<c:choose>
	              	<c:when test="${actNum eq s1ActNum}">
						${actNum}<%= lang.readGm(GMLangConstants.GE)%>
	              	</c:when>
	 				<c:otherwise>
						 <font class="red">${actNum}<%= lang.readGm(GMLangConstants.GE)%></font>
	 				</c:otherwise>
               </c:choose>
			</td>
			<td>&nbsp;${s1ActNum}<%= lang.readGm(GMLangConstants.GE)%></td>
			<td>&nbsp;<c:choose>
			     <c:when test="${actNum eq s1ActNum}">
					<%= lang.readGm(GMLangConstants.NOT_NEED_SYN)%>
			     </c:when>
				 <c:otherwise>
				   <font class="red"><%= lang.readGm(GMLangConstants.NEED_SYN)%></font>
				 </c:otherwise>
			    </c:choose>
            </td>
		</tr>
		<tr>
			<td class="label" >&nbsp;<%= lang.readGm(GMLangConstants.PRIZE)%></td>
			<td>&nbsp;<c:choose>
	              	<c:when test="${prizeNum eq s1PrizeNum}">
						${prizeNum}<%= lang.readGm(GMLangConstants.GE)%>
	              	</c:when>
	 				<c:otherwise>
						 <font class="red">${prizeNum}<%= lang.readGm(GMLangConstants.GE)%></font>
	 				</c:otherwise>
               </c:choose>
			</td>
			<td>&nbsp;${s1PrizeNum}<%= lang.readGm(GMLangConstants.GE)%></td>
			<td>&nbsp;<c:choose>
			     <c:when test="${prizeNum eq s1PrizeNum}">
					<%= lang.readGm(GMLangConstants.NOT_NEED_SYN)%>
			     </c:when>
				 <c:otherwise>
				   <font class="red"><%= lang.readGm(GMLangConstants.NEED_SYN)%></font>
				 </c:otherwise>
			    </c:choose>
            </td>
		</tr>
	</tbody>
</table>
</form>
</div>
</body>
</html>