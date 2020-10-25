<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title></title>
<script type="text/javascript">
$().ready(function(){

});
</script>
</head>
<body>
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

<div id="man_zone">

<div class="topnav"><a href="homePage.do?action=welcome">
<%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>&gt;&gt;
<%= lang.readGm(GMLangConstants.GAME_LOG) %>&gt;&gt;
<a href="user.do?action=init"><%= lang.readGm(GMLangConstants.ROLEACCOUNT) %></a>&gt;&gt;
<%= lang.readGm(GMLangConstants.LOCK_NUM)%>
</div>

<div id="nav">
    <ul>  
        <li id="man_nav_1"  onclick="list_sub_nav(id)"  class="bg_image_onclick"><%= lang.readGm(GMLangConstants.LOCK_NUM)%></li>
     </ul>
</div>

<div id="sub_info">
</div>

<form name="form1" method="post" action="user.do?action=lockUser&id=${userInfo.id}"  onsubmit="return is_ok();">
<input name="userId" type="hidden" value="${userInfo.id}">
<table class="detail" style="width:50%;" cellspacing="0" cellpadding="0" border="0" >
  <tbody><tr>
    <th colspan="2"><%= lang.readGm(GMLangConstants.LOCK_NUM)%></th>
   </tr>
   <tr>
	<td class="label"><%= lang.readGm(GMLangConstants.REASON)%></td>
    <td>     
       <textarea id="lockReason" name="lockReason" rows="3" cols="20"></textarea>
    </td>
   </tr>
   <tr>
   <td colspan="2" align="right">
	 <input id="submit" type="submit" value="<%= lang.readGm(GMLangConstants.LOCK)%>" class="butcom"/>&nbsp;&nbsp;
	 <input id="return" type="button" value="<%= lang.readGm(GMLangConstants.RETURN)%>" onclick="javascript:window.location.href='user.do?action=init'" class="butcom"/>&nbsp;&nbsp;
   </td>
  </tr>
</tbody></table>
</form>
<script type="text/javascript">
function is_ok(){
	var reason=$("#lockReason").val();
	if(is_null(reason)==true){
		alert('<%= lang.readGm(GMLangConstants.REASON_NOT_NULL)%>');
		$("#lockReason").focus();
		return false;
	}
	return true;
}

</script>
</div>
</body>
</html>