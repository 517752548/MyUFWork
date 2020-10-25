<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<%@ include file="../../../common/taglibs.jsp"%>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
</head>
<script type="text/javascript">
$().ready(function(){
	  var type="${searchType}";
	  $("#option"+type).attr("selected","selected");
	});
</script>
<body>
<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>&gt;&gt;
<a class="link" href="role.do?action=init"><%=lang.readGm(GMLangConstants.ROLE_MANAGE)%></a>&gt;&gt;
<%=lang.readGm(GMLangConstants.BATCH_SEARCH_LASTLOGIN)%></div>

		<div id="nav">
<ul>
	<li id="man_nav_1" 
		class="bg_image_onclick"><%=lang.readGm(GMLangConstants.BATCH_SEARCH_LASTLOGIN)%></li>
</ul>
		</div>
		
		<div id="sub_info">
		</div>
		
<form  method="post" name="form1"
	action="role.do?action=batchSearchInit">
<table id='tab_1' class="detail" style="width:50%;" cellspacing="0"
	cellpadding="0" border="0">
	<tbody>
		<tr>
			<td class="header" align="center" nowrap="nowrap" ><%=lang.readGm(GMLangConstants.BATCH_SEARCH_LASTLOGIN)%><%=lang.readGm(GMLangConstants.CARDTYPE)%></td>
			<td ><select id="searchType" name="searchType">
				<option value="1" selected="selected"><%=lang.readGm(GMLangConstants.COMMON_LASTLOGONDATE)%></option>
				<option value="2" ><%=lang.readGm(GMLangConstants.WHOLE_REGION_SEARCH)%></option>
			</select>
			</td>
			<td rowspan="3" class="label"><%=lang.readGm(GMLangConstants.RESULT)%></td>
            <td rowspan="3" ><textarea id="results" cols="40" rows="5" name="results">${results}</textarea></td>
		</tr>
		<tr>
			<td class="label"><%=lang.readGm(GMLangConstants.COMMON_SEARCH)%><%=lang.readGm(GMLangConstants.COMMON_SEARCH_ROLE)%></td>
            <td><textarea id="roleNames" cols="40" rows="5" name="roleNames" >${roleNames }</textarea>
			</td>
		</tr>
		<tr>
			<td class="label"><%=lang.readGm(GMLangConstants.DETAIL)%><%=lang.readGm(GMLangConstants.COMMON_SEARCH)%></td>
			<td ><input type="submit" value="<%=lang.readGm(GMLangConstants.COMMON_SEARCH)%>"></td>
		</tr>
	</tbody>
</table>
</form>
</div>
</body>
</html>