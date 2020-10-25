<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

<title>Insert title here</title>

<script  type="text/javascript">
$().ready(function(){
	var Id = $("#role").val();
 if($("#"+Id).attr("class") == "bg_image"){
	  $("#"+Id).attr("class","bg_image_onclick");
 }});

function list_sub_nav(Id){
    $("li[id^='man_nav']").each(function(){
    	  $(this).attr("class","bg_image");
        });
   if($("#"+Id).attr("class") == "bg_image"){
	  $("#"+Id).attr("class","bg_image_onclick");
   }
   
   var switchId = parseInt(Id.substring(8));
	switch(switchId){
    case 1:
    	window.location="sysUser.do?action=viewRight&role=super_admin&id=man_nav_1";
	   break;
    case 2:
    	window.location="sysUser.do?action=viewRight&role=admin&id=man_nav_2";
	   break;
    case 3:
    	window.location="sysUser.do?action=viewRight&role=maintain&id=man_nav_3";
 	   break;
     case 4:
    	 window.location="sysUser.do?action=viewRight&role=normal_custom_service&id=man_nav_4";
 	   break;
     case 5:
    	 window.location="sysUser.do?action=viewRight&role=advanced_custom_service&id=man_nav_5";
  	   break;
     case 6:
    	 window.location="sysUser.do?action=viewRight&role=operation&id=man_nav_6";
  	   break;
     case 7:
    	 window.location="sysUser.do?action=viewRight&role=advanced_operation&id=man_nav_7";
  	   break;
     case 8:
    	 window.location="sysUser.do?action=viewRight&role=kaiying&id=man_nav_8";
  	   break;
     case 9:
    	 window.location="sysUser.do?action=viewRight&role=developer&id=man_nav_9";
  	   break;
  	 default:
  	   break;
	}
}
</script>

</head>
<body>
<div id="man_zone">
	<div class="topnav"><a href="homePage.do?action=welcome">
	<%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>&gt;&gt;
	<%= lang.readGm(GMLangConstants.SYS) %>&gt;&gt;
	<%= lang.readGm(GMLangConstants.RIGHT)%><%= lang.readGm(GMLangConstants.VIEW)%>
	</div>
	
	<div id="nav">
	    <ul>  
	        <li id="man_nav_1"  onclick="list_sub_nav(id)"  class="bg_image" >
	        <%= lang.readGm(GMLangConstants.SUPER_ADMIN)%></li>
	        
			<li id="man_nav_2"  onclick="list_sub_nav(id)"  class="bg_image" >
			<%= lang.readGm(GMLangConstants.ADMIN)%></li>
			
			<li id="man_nav_3"  onclick="list_sub_nav(id)"  class="bg_image" >
			<%= lang.readGm(GMLangConstants.MAINTAIN)%></li>
			
			<li id="man_nav_4"  onclick="list_sub_nav(id)"  class="bg_image" >
			<%= lang.readGm(GMLangConstants.NORMAL_CUSTOM_SERVICE)%></li>
			
			<li id="man_nav_5"  onclick="list_sub_nav(id)"  class="bg_image" >
			<%= lang.readGm(GMLangConstants.ADVANCED_CUSTOM_SERVICE)%></li>
			
			<li id="man_nav_6"  onclick="list_sub_nav(id)"  class="bg_image" >
			<%= lang.readGm(GMLangConstants.OPERATION)%></li>
			
			<li id="man_nav_7"  onclick="list_sub_nav(id)"  class="bg_image" >
			<%= lang.readGm(GMLangConstants.ADVANCED_OPERATION)%></li>
			<li id="man_nav_8"  onclick="list_sub_nav(id)"  class="bg_image" >
			<%= lang.readGm(GMLangConstants.KAIYING)%></li>
			<li id="man_nav_9"  onclick="list_sub_nav(id)"  class="bg_image" >
			<%= lang.readGm(GMLangConstants.DEVELOPER)%></li>
			
	     </ul>
	</div>
	
	<div id="sub_info">
		<input id="role" type="hidden" value="${Id}"></input>
	</div>
	
<div class="nofloat" />
<table class="detail no_bottom"  cellspacing="0" cellpadding="0" border="0">
  <tbody>
  			        <tr>
		         <th align="center" colSpan="5">&nbsp;<%= lang.readGm(GMLangConstants.RIGHT)%><%= lang.readGm(GMLangConstants.VIEW)%></th>
		        </tr>
 	   <c:forEach items="${treeNodeList}" var="treeNode" varStatus="count" begin="0">
	<c:if test="${count.index%5 eq 0}"><tr align="left"></c:if>
<td align=center>${treeNode.name}
		</td>
    <c:if test="${count.index%5 eq 4}"></tr></c:if>
    <c:if test="${(count.last) and (count.index%5 lt 4)}"></tr></c:if>
    </c:forEach>
</tbody></table>
</div>
</div>
</body>
</html>