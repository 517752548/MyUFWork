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
<%=lang.readGm(GMLangConstants.BROSORURL_TYPESTRUTCTION)%>

</div>
<div class="nofloat" />
<table class="detail"    cellspacing="0" cellpadding="0" 
	border="0" >
	<tbody>
		<tr>
		 <th width="10%"><%=lang.readGm(GMLangConstants.BROSORURL_TYPE)%></th>
		 <th width="10%"><%=lang.readGm(GMLangConstants.BROSORURL_URLURL)%></th>
 		 <th width="10%"><%=lang.readGm(GMLangConstants.BROSORURL_TIME)%></th>
		 <th width="10%"><%=lang.readGm(GMLangConstants.BROSORURL_OPPERATION)%></th>
		</tr>
     <c:forEach items="${broserEntityList}" var="broseruRLS">
        <tr>
		 <!--  <td>&nbsp;${broseruRLS.terminalType}</td>-->
		 <td>&nbsp;<c:if test="${broseruRLS.terminalType eq 2}"><%=lang.readGm(GMLangConstants.BROSORURL_IOSIPHONE)%></c:if>
			 	<c:if test="${broseruRLS.terminalType eq 3}"><%=lang.readGm(GMLangConstants.BROSORURL_IOSIPAD)%></c:if>
		 		<c:if test="${broseruRLS.terminalType eq 4}"><%=lang.readGm(GMLangConstants.BROSORURL_ANDROID)%></c:if>
		 </td>
         <td>&nbsp;${broseruRLS.brosorUrl}</td>
         <td>&nbsp;${broseruRLS.brosorUrlType}</td>
		 <td>&nbsp;<!-- <img border="0" title="<%=lang.readGm(GMLangConstants.RELEASE)%>"
					src="images/notice.gif"
					onclick="javaScript:releaseTimeNotice('${broseruRLS.id}');"  />  -->
					<input  class="butcom" type="button" value="<%= lang.readGm(GMLangConstants.BROSORURL_UPDATEURLTYPE)%>" onClick="javaScript:window.location.href='borsor.do?action=updateBrosorUrl&Id=${broseruRLS.id}';"/></td>
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
		$.post("borsor.do?action=delTimeNotice",{id:id},function(){
	        alert("<%=lang.readGm(GMLangConstants.DEL_SUCCESS)%>");
	        window.location='borsor.do?action=init';
		  });	

	}
}
function goTo(i){
	  window.location.href="borsor.do?action=init&currentPage="+i;
}
</script>
</body>
</html>