<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title></title>
</head>
<body>
<div id="man_zone">
<c:if test="${cmd eq true}">
<script type="text/javascript">
alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
window.location="petLog.do?action=init";
</script>
</c:if>
<c:if test="${cmd eq false}">
<script type="text/javascript">
alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
</script>
</c:if>
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>  
<a class="link" href="petLog.do?action=init"><%=lang.readGm(GMLangConstants.PET)%><%=lang.readGm(GMLangConstants.LOG)%></a>>><%=lang.readGm(GMLangConstants.RECOVER_PET)%></div>
<div style="clear: both;"/>
<form name="form1" method="post" action="petLog.do?action=petRecover"  onsubmit="return is_ok();">
<input name="date" type="hidden" value="${date}">
<input name="id" type="hidden" value="${id}">
<table class="detail" style="width:30%;" cellspacing="0" cellpadding="0" border="0" >
  <tbody><tr>
    <th colspan="2"><%= lang.readGm(GMLangConstants.RECOVER_PET)%></th>
   </tr>
   <tr>
	<td class="label"><%= lang.readGm(GMLangConstants.USER_ID)%></td>
    <td>     
       <input id="accountId" name="accountId" value="${accountId}" />
    </td>
   </tr>
   <tr>
	<td class="label"><%= lang.readGm(GMLangConstants.USER_PRIZE_NAME)%></td>
    <td>     
       <input id="userPrizeName" name="userPrizeName" value="${userPrizeName}"/>
    </td>
   </tr>
   <tr>
   <td colspan="2" class="bottom">
	 <input id="submit" type="submit" value="<%= lang.readGm(GMLangConstants.RECOVER_PET)%>" class="butcom"/> 
	 <span style="padding: 10px;"/><input id="return" type="button" value="<%= lang.readGm(GMLangConstants.RETURN)%>" onclick="javascript:window.location.href='petLog.do?action=init'" class="butcom"/>
   </td>
  </tr>
</tbody></table>
</form>
</div>
<script type="text/javascript">
function is_ok(){
	var accountId=$("#accountId").val();
	if(is_null(accountId)==true){
		alert('<%= lang.readGm(GMLangConstants.ACCOUNTID_NOT_NULL)%>');
		$("#accountId").focus();
		return false;
	}
	 if(is_int(accountId)==false){
			alert('<%= lang.readGm(GMLangConstants.USERID_IS_NUM)%>');
			$("#accountId").focus();
			return false;
	 }
	var userPrizeName=$("#userPrizeName").val();
	if(is_null(userPrizeName)==true){
		alert('<%= lang.readGm(GMLangConstants.USER_PRIZE_NAME_NOT_NULL)%>');
		$("#userPrizeName").focus();
		return false;
	}
	return true;
}

</script>
</body>
</html>