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
<%=lang.readGm(GMLangConstants.DIRTY_WORLDS_NET)%>

</div>
<table class="detail" cellspacing="0" cellpadding="0" border="0" >
	<tbody>
		<tr>
		 <th width="5%"><%=lang.readGm(GMLangConstants.DIRTY_WORLDS_NET_ID)%></th>
		 <th width="10%"><%=lang.readGm(GMLangConstants.DIRTY_WORLDS_NET_CONTENT)%></th>
 		 <th width="10%"><%=lang.readGm(GMLangConstants.DIRTY_WORLDS_NET_TIME)%></th>

		 <th width="5%"><%=lang.readGm(GMLangConstants.CEO_WAR_CRAFT_OPERATION)%></th>
		 
		</tr>
        <tr>
		 <td>&nbsp;${dirtyWorldsType.id}</td>
		 <td>&nbsp;${dirtyWorldsType.showDataType}</td>
         <td>&nbsp;${dirtyWorldsType.updateTimeStr}</td>
         <td>&nbsp;
		<input class="butcom" type="button" value="<%= lang.readGm(GMLangConstants.CEO_WAR_CRAFT_OPERATION)%>" onClick="javaScript:window.location.href='dirtyWorlds.do?action=editView&Id=${dirtyWorldsType.id}';"/>
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
</script>
</body>
</html>