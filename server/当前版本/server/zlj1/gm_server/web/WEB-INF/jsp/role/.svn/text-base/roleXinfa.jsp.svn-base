<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/logCommon.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
<script type="text/javascript">

function list_sub_nav(id,sortname){
	$("li[id^='man_nav']").each(function(){
    	  $(this).attr("class","bg_image");
     });
   if($("#"+id).attr("class")=="bg_image"){
	   $("#"+id).attr("class","bg_image_onclick");
   }
   showInnerText(id);
}

function showInnerText(id){
    var switchId = parseInt(id.substring(8));
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

</script>
</head>
<body>
<div id="man_zone">
<div id="nav">
<ul>
	<li id="man_nav_1"
		onclick="javaScript:window.location='role.do?action=roleBasicInfo&id=${id}';"
		class="bg_image" ><%=lang.readGm(GMLangConstants.C_BASIC_INFO)%></li>
	<li id="man_nav_2" 
		onclick="javaScript:window.location='role.do?action=rolePet&id=${id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.PET)%></li>
   <li id="man_nav_3"  
		onclick="javaScript:window.location='role.do?action=roleItem&id=${id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.ITEM)%></li>
   <li id="man_nav_4"  
		onclick="javaScript:window.location='role.do?action=roleTask&id=${id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.TASK)%></li>

   <li id="man_nav_6" 
		onclick="javaScript:window.location='role.do?action=roleSkill&id=${id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.SKILL)%></li>
   <li id="man_nav_7" 
		onclick="javaScript:window.location='role.do?action=roleXinfa&id=${id}';"
		class="bg_image_onclick"><%=lang.readGm(GMLangConstants.XINFA)%></li>
   <li id="man_nav_8" 
		onclick="javaScript:window.location='role.do?action=roleFriend&id=${id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.SOCIAL_RELATION)%></li>
   

     
</ul>
</div>
<div id="sub_info">&nbsp;&nbsp;<img src="images/hi.gif" />&nbsp;
<span id="show_text">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>  
<a class="link" href="role.do?action=init"><%=lang.readGm(GMLangConstants.ROLE_MANAGE)%></a>>>
<%=lang.readGm(GMLangConstants.ROLE)%>#${id}</span>
</div>
<div class="nofloat" />
<input id="selectedTab" type="hidden"/>
<table name='tab_1' class="detail no_bottom"  cellspacing="0" cellpadding="0" style="width: 30%;"
	border="0" >
	<tbody>
		<tr>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.COMMON_NAME)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.XINFA)%><%=lang.readGm(GMLangConstants.LEVEL)%></th>
 		 <th>&nbsp;<%=lang.readGm(GMLangConstants.XINFA)%><%=lang.readGm(GMLangConstants.XINFA_SKILL)%></th>
		</tr>
     <c:forEach items="${xinfas}" var="xinfa">
        <tr>
         <td>&nbsp;
		  ${xinfa.xinfaName}
         </td>
		 <td>&nbsp;${xinfa.xinfaLevel}</td>
		 <td>&nbsp;${xinfa.xinfaValue}</td>
		</tr>
     </c:forEach>
   </tbody>
</table>
</div>
</body>
</html>