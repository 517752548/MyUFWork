<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>mmo</title>
<script type="text/javascript">
$().ready(function(){

});
</script>
</head>
<body>
<div id="man_zone">
<c:if test="${cmd eq true}">
<script type="text/javascript">
alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
window.location="user.do?action=init";
</script>
</c:if>
<c:if test="${cmd eq false}">
<script type="text/javascript">
alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
</script>
</c:if>
<div id="nav">
    <ul>  
        <li id="man_nav_1"  onclick="list_sub_nav(id)"  class="bg_image_onclick"><%= lang.readGm(GMLangConstants.USER_PRI)%></li>
     </ul>
</div>
<div id="sub_info">
<span id="show_text">&nbsp;&nbsp;<img
	src="images/hi.gif" />&nbsp;<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>  
<a  href="user.do?action=init" class="link" ><%=lang.readGm(GMLangConstants.USER)%><%=lang.readGm(GMLangConstants.MANAGE)%></a>>>
<%=lang.readGm(GMLangConstants.LOCK_NUM)%><%=lang.readGm(GMLangConstants.USER_ID)%>#${userInfo.id}
</span>
</div>
<div style="clear: both;"/>
<form name="form1" method="post" action="user.do?action=unlockUser&id=${userInfo.id}">
<input name="userId" type="hidden" value="${userInfo.id}">
<table class="detail" style="width:30%;" cellspacing="0" cellpadding="0" border="0" >
  <tbody><tr>
    <th colspan="2"><%= lang.readGm(GMLangConstants.LOCK_NUM)%></th>
   </tr>
   <tr>
	<td class="label"><%= lang.readGm(GMLangConstants.REASON)%></td>
    <td>     
       <textarea id="lockReason" name="lockReason" rows="3" cols="20" disabled="disabled">${reason}</textarea>
    </td>
   </tr>
   <tr>
   <td colspan="2"  class="bottom">
	 <input id="submit" type="submit" value="<%= lang.readGm(GMLangConstants.UNLOCK)%>" class="butcom"/> 
	 <span style="padding: 10px;"/><input id="return" type="button" value="<%= lang.readGm(GMLangConstants.RETURN)%>" onclick="javascript:window.location.href='user.do?action=init'" class="butcom"/>
   </td>
  </tr>
</tbody></table>
</form>
</div>
</body>
</html>