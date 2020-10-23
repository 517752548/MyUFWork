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
    <c:forEach items="${broserEntityList}" var="broserEntity">
        <tr>
		 <!--  <td>&nbsp;${broseruRLS.terminalType}</td>-->
		 <td>&nbsp;<c:if test="${broserEntity.terminalType eq 2}"><%=lang.readGm(GMLangConstants.BROSORURL_IOSIPHONE)%></c:if>
			 	<c:if test="${broserEntity.terminalType eq 3}"><%=lang.readGm(GMLangConstants.BROSORURL_IOSIPAD)%></c:if>
		 		<c:if test="${broserEntity.terminalType eq 4}"><%=lang.readGm(GMLangConstants.BROSORURL_ANDROID)%></c:if>
		 		<input id='terminalType' type='hidden' value="${broserEntity.terminalType}" />
		 </td>
         <td><input id='startLevel' type='text' value="${broserEntity.brosorUrl} "style="width: 200px;" />
         <td><input id='startType' type='text' value="${broserEntity.brosorUrlType}" style="width: 20px;" />
		 <td>&nbsp;<!-- <img border="0" title="<%=lang.readGm(GMLangConstants.RELEASE)%>"
					src="images/notice.gif"
					onclick="javaScript:releaseTimeNotice('${broseruRLS.id}');"  />  -->
					<input class="butcom" id="submit" type="submit" value="<%= lang.readGm(GMLangConstants.RELEASE)%>" onclick="releaseTimeNotice('${broserEntity.id}');"/></td>
		</tr>
     </c:forEach>
    <tr>
    <!--  <td height="30" colspan="8" style="border-bottom: 0px;">
     <jsp:include page="../page.jsp"></jsp:include>-->
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
function releaseTimeNotice(id){
	var startLevell = $("#startLevel").val();
	var startTypel = $("#startType").val();
	var terminalTypel = $("#terminalType").val();
	$.post("borsor.do?action=releaseBorsorUrl",{id:id,startLevel:startLevell,startType:startTypel,terminalType:terminalTypel},function(info){
		var data = $.trim(info);
		if("true"==data){
			 alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
		}else{
			 alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
		}
		 window.location='borsor.do?action=init';
	});
}
</script>
</body>
</html>