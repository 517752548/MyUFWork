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
<a href="homePage.do?action=welcome"><%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>>><%=lang.readGm(GMLangConstants.GAME)%><%=lang.readGm(GMLangConstants.NOTICE)%>
</div>
<div class="nofloat" />
<table class="detail"  cellspacing="0" 
	cellpadding="0" border="0">
	<tbody>
		<tr>
			<th><input id="download"
	name="download" type="button" style="margin-left: 1em;"
	value="<%=lang.readGm(GMLangConstants.VIEW)%>"
	onclick="javaScript:window.location='game_notice.txt?t='+ new Date().getTime()" class="butcom" /> </th>
			
			<c:if test="${DBType eq 1}">
			<th><%=lang.readGm(GMLangConstants.COMMON_OPERATION)%>
                <img 
				class="pointer link" src="images/add.gif" title="<%=lang.readGm(GMLangConstants.ADD)%><%=lang.readGm(GMLangConstants.GAME)%><%=lang.readGm(GMLangConstants.NOTICE)%>"
				onclick="javaScript:window.location='gameNotice.do?action=editGameNotice'" /></th>
			</c:if>
		</tr>
		<c:forEach items="${gameNoticeList}" var="notice">
			<tr>
				<td>&nbsp;${notice.id}</td>
				<td>&nbsp;${notice.serverIds}</td>
				<td>&nbsp;<c:if test="${notice.status eq 0}">
						<%=lang.readGm(GMLangConstants.NOREFRESH)%>
						</c:if>
						<c:if test="${notice.status eq 1}">
							<%=lang.readGm(GMLangConstants.REFRESH)%>
						</c:if>
				</td>
			    <c:if test="${DBType eq 1}">
				<td>&nbsp;<img class="pointer" src="images/b_edit.png" title="<%=lang.readGm(GMLangConstants.EDIT)%>" 
					onclick="javaScript:window.location='gameNotice.do?action=editGameNotice&id=${notice.id}'" />
				<span style="padding: 10px;" /> <img class="pointer" title="<%=lang.readGm(GMLangConstants.COMMON_DELETE)%>" 
					src="images/b_drop.png"
					onclick="javaScript:delGameNotice('${notice.id}');" /> <img 
					border="0" title="<%=lang.readGm(GMLangConstants.RELEASE)%>"
					src="images/notice.gif"
					onclick="javaScript:releaseGameNotice('${notice.id}');"  />
				</c:if>
              </td>
			</tr>
		</c:forEach>
        <tr>
			<td height="30" colspan="4" style="border-bottom: 0px;"><jsp:include
				page="../page.jsp"></jsp:include>
			</td>
		</tr>
	</tbody>
</table>
</div>
<script type="text/javascript">
function delGameNotice(id){
	var con= confirm("<%=lang.readGm(GMLangConstants.CONFRIM_DEL)%>?");
	if(con){
		$.post("gameNotice.do?action=delGameNotice",{id:id},function(){
	        alert("<%=lang.readGm(GMLangConstants.DEL_SUCCESS)%>");
	        window.location='gameNotice.do?action=init';
		  });
	}
}
function releaseGameNotice(id){
	$.post("gameNotice.do?action=releaseGameNotice",{id:id},function(info){
		var data = $.trim(info);
		if("true"==data){
			 alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
		}else{
			 alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
			 	}
		        window.location='gameNotice.do?action=init';
		    });
	}
function goTo(i){
	  window.location.href="gameNotice.do?action=init&currentPage="+i;
}
</script>
</body>
</html>