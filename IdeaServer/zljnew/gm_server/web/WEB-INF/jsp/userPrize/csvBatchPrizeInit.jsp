<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>mmo</title>
</head>
<body>
<div id="man_zone">
<div class="topnav"><a href="homePage.do?action=welcome">
<%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>>>
<a class="link" href="userPrize.do?action=init"><%=lang.readGm(GMLangConstants.GM_USER_PRIZE)%></a>>>
<%= lang.readGm(GMLangConstants.CSV_BATCH_PRIZE) %>
</div>
<div style="clear: both;"/>
<form name="form1" method="post" action='userPrize.do?action=importCSV'  onsubmit="return is_ok();" enctype="multipart/form-data">
<table class="detail" style="width:30%;" cellspacing="0" cellpadding="0" border="0" >
  <tbody><tr>
    <th colspan="2"><%= lang.readGm(GMLangConstants.CSV_BATCH_PRIZE)%></th>
   </tr>
   <tr>
	<td class="label">Excel<%= lang.readGm(GMLangConstants.FILE)%></td>
    <td>     
       <input id="uploadFile" type="file" size="20" name="csvFile"/>
       <input type="submit" value="<%= lang.readGm(GMLangConstants.UPLOAD)%>"/>
    </td>
   </tr>
   <tr>
   <td colspan="2" class="bottom">
		<input id="return" type="button" value="<%= lang.readGm(GMLangConstants.RETURN)%>" onclick="javascript:window.location.href='userPrize.do?action=init'" class="butcom"/>
   </td>
  </tr>
</tbody></table>
</form>
</div>
<script type="text/javascript">
function is_ok(){
	var uploadFile=$("#uploadFile").val();
	var startPoint = uploadFile.lastIndexOf(".");
	var len = uploadFile.length;
	var sufix = uploadFile.substr(startPoint+1,len);
	if(sufix!="xls"){
		alert("<%= lang.readGm(GMLangConstants.FILE_NOT_OK)%>");
		return false;
	}
	return true;
}
</script>
</body>
</html>