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
	if("${cmd}"=="true"){
		$("#CSVResult").show();
	}else{
		$("#CSVResult").hide();
	}
});

</script>
</head>
<body>
<c:if test="${cmd eq true}">
<script type="text/javascript">
alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
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
<%= lang.readGm(GMLangConstants.IMPORT_CSV) %>
</div>

<div id="nav">
    <ul>  
        <li id="man_nav_1" class="bg_image_onclick"><%= lang.readGm(GMLangConstants.IMPORT_CSV) %></li>
     </ul>
</div>

<div id="sub_info">
</div>

<form name="form1" method="post" action='user.do?action=importCSV'  onsubmit="return is_ok();" enctype="multipart/form-data">
<table class="detail" style="width:50%;" cellspacing="0" cellpadding="0" border="0" >
  <tbody><tr>
    <th colspan="2">CSV<%= lang.readGm(GMLangConstants.UPLOAD)%></th>
   </tr>
   <tr>
	<td class="label">CSV<%= lang.readGm(GMLangConstants.FILE)%></td>
    <td>     
       <input id="uploadFile" type="file" size="20" name="csvFile"/>
       <input type="submit" value="<%= lang.readGm(GMLangConstants.UPLOAD)%>" class="butcom"/>
    </td>
   </tr>
   <tr>
	<td class="label red"><%= lang.readGm(GMLangConstants.ATTENTIONS)%></td>
  	<td><%= lang.readGm(GMLangConstants.CSVRULE)%></td>
   </tr> 
   <tr>
   <td colspan="2" align="right">
		<input id="return" type="button" value="<%= lang.readGm(GMLangConstants.RETURN)%>" onclick="javascript:window.location.href='user.do?action=init'" class="butcom"/>&nbsp;&nbsp;
   </td>
  </tr>
</tbody></table>
</form>
 <table id="CSVResult" class="detail" style="width:50%;" cellspacing="0" cellpadding="0" border="0" >
   <tbody>
   <tr>
    <th colspan="2"><%= lang.readGm(GMLangConstants.UPLOAD)%><%= lang.readGm(GMLangConstants.RESULT)%></th>
   </tr>
   <tr>
	<td class="label"><%= lang.readGm(GMLangConstants.USER_ID)%></td>
    <td>     
       ${userIdList}
    </td>
   </tr>
   <tr>
   <td colspan="2" align="right">
		<input id="batch_lock_users" type="button" value="<%= lang.readGm(GMLangConstants.BATCH_LOCK_USERS)%>" onclick="javascript:window.location.href='user.do?action=batchLockUserInit&userIds=${userIdList}'" class="butcom"/>
  		&nbsp;&nbsp;
  		<input id="unBatchLockUser" type="button" value="<%= lang.readGm(GMLangConstants.BATCH_UNLOCK_USERS)%>" onclick="javascript:unBatchLockUser();" class="butcom"/>&nbsp;&nbsp; 
  </td>
  </tr>
</tbody>
</table>
<script type="text/javascript">
function is_ok(){
	var uploadFile=$("#uploadFile").val();
	var startPoint = uploadFile.lastIndexOf(".");
	var len = uploadFile.length;
	var sufix = uploadFile.substr(startPoint+1,len);
	if(sufix!="csv"){
		alert("<%= lang.readGm(GMLangConstants.FILE_NOT_OK)%>");
		return false;
	}
	return true;
}
function unBatchLockUser(){
	var userIds ="${userIdList}";
	$.post("user.do?action=unBatchLockUser",{userIds:userIds},function(info){
		var data=$.trim(info);  
		if(data=="true"){
			alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
			window.location = "user.do?action=init";
		}else{
			alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
			window.location = "user.do?action=init";
		}
	});
 }
</script>
</div>
</body>
</html>