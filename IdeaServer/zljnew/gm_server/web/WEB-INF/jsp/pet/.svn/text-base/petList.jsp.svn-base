<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
<script type="text/javascript">
$().ready(function(){
  var type="${searchType}";
  if(type=="userId"){
	$("#searchType").val("userId");
	$("#man_nav_1").attr("class","bg_image");
    $("#man_nav_2").attr("class","bg_image_onclick");
   }
});
function list_sub_nav(Id,sortname){
	$("li[id^='man_nav']").each(function(){
    	  $(this).attr("class","bg_image");
     });
   if($("#"+Id).attr("class")=="bg_image"){
	   $("#"+Id).attr("class","bg_image_onclick");
   }
   showInnerText(Id);
}

function showInnerText(Id){
    var switchId = parseInt(Id.substring(8));
	var showText = "";
	switch(switchId){
	    case 1:
		   $("#searchType").val("roleId");
		   break;
	    case 2:
		   $("#searchType").val("userId");
		   break;
	}
}
function search(){
	var searchType=$("#searchType").val();
	var searchValue=$("#searchValue").val();
	window.location.href="role.do?action=init&searchType="+searchType+"&searchValue="+searchValue;
}
</script>
</head>
<body>
<div id="man_zone">
<div id="nav">
<ul>
	<li id="man_nav_1"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.ROLE_ID)%>')"
		class="bg_image_onclick"><%=lang.readGm(GMLangConstants.ROLE_ID)%></li>
	<li id="man_nav_2"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.USER_ID)%>')"
		class="bg_image"><%=lang.readGm(GMLangConstants.USER_ID)%></li>
</ul>
</div>
<div id="sub_info">
<span id="show_text">
	<input	id='searchValue' type='text' value="${searchValue}" />
</span>
 <input id="searchType" type="hidden" value="roleId"/> 
<input id="search" type="button" style="margin-left: 1em;" 	value="<%=lang.readGm(GMLangConstants.COMMON_SEARCH)%>"
	onClick="javaScript:search();" /></div>
<p id="data">
<table class="detail" width="90%" cellspacing="0" cellpadding="0"
	border="0" align="center">
	<tbody>
		<tr>
			<th><%=lang.readGm(GMLangConstants.ROLE_ID)%></th>
			<th><%=lang.readGm(GMLangConstants.USER_ID)%></th>
			<th><%=lang.readGm(GMLangConstants.USER_NAME)%></th>
			<th><%=lang.readGm(GMLangConstants.COMMON_STATE)%></th>
			<th><%=lang.readGm(GMLangConstants.COMMON_OPERATION)%></th>
		</tr>
		<c:forEach items="${userInfoList}" var="u">
			<tr>
				<td><a href="role.do?action=roleBasicInfo&id=${u.id}" class="link">${u.id}<a></td>
				<td><a
					href="user.do?action=init&searchType=userId&searchValue=${u.passportId}"
					class="link">${u.passportId}<a></td>
				<td>${u.name}</td>
				<td><c:choose>
					<c:when test="${u.deleted eq 1}">
						<span class="red"><%=lang.readGm(GMLangConstants.COMMON_DELETED)%></span>
                &nbsp;<span>${u.deleteDate}</span>
					</c:when>
					<c:otherwise>
						<span><%=lang.readGm(GMLangConstants.COMMON_NOR)%></span>
					</c:otherwise>
				</c:choose></td>
				<td><img src="images/b_edit.png" /></td>
			</tr>
		</c:forEach>
	</tbody>
</table>
</p>
</div>
</body>
</html>