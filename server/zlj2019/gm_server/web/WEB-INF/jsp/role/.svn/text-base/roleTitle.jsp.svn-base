<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ page import="com.imop.lj.db.model.HumanEntity"%>
<%
	HumanEntity charaInfo= (HumanEntity)request.getAttribute("c");
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
<script type="text/javascript">
$().ready(function(){
  $("table[name^='tab']").each(function(){
	  	  $(this).hide();
   });
  $("table[name^='tab_1']").each(function(){
	  	  $(this).show();
   });
});
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
function switchTab(id){
	$("h2[id^='tab']").each(function(){
    	  $(this).attr("class","tab");
     });
   if($("#"+id).attr("class")=="tab"){
	   $("#"+id).attr("class","selected tab");
   }
   $("table[name^='tab']").each(function(){
	  	  $(this).hide();
	});
   $("table[name^='"+id+"']").each(function(){
	  	  $(this).show();
   });
}

</script>
</head>
<body>
<div id="man_zone">
<div id="nav">
<ul>
	<li id="man_nav_1" class="bg_image"
		onclick="javaScript:window.location='role.do?action=roleBasicInfo&id=${c.id}';"
		 ><%=lang.readGm(GMLangConstants.C_BASIC_INFO)%></li>
	<li id="man_nav_2"
		onclick="javaScript:window.location='role.do?action=rolePet&id=${c.id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.PET)%></li>
    <li id="man_nav_3"
		onclick="javaScript:window.location='role.do?action=roleItem&id=${c.id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.ITEM)%></li>
    <li id="man_nav_4"
		onclick="javaScript:window.location='role.do?action=roleTask&id=${c.id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.TASK)%></li>
   <li id="man_nav_5"
		onclick="javaScript:window.location='role.do?action=roleTitle&id=${c.id}';"
		class="bg_image_onclick"><%=lang.readGm(GMLangConstants.LOG_TYPE_TITLE)%></li>
   <li id="man_nav_6"
		onclick="javaScript:window.location='role.do?action=roleSkill&id=${c.id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.SKILL)%></li>
   <li id="man_nav_7"
		onclick="javaScript:window.location='role.do?action=roleXinfa&id=${id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.XINFA)%></li>
   <li id="man_nav_8"
		onclick="javaScript:window.location='role.do?action=roleFriend&id=${id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.SOCIAL_RELATION)%></li>
   <li id="man_nav_9"
		onclick="javaScript:window.location='role.do?action=roleBuff&id=${id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.BUFINFO)%></li>
   <li id="man_nav_10"
		onclick="javaScript:window.location='role.do?action=roleRaid&id=${id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.RAID)%></li>
</ul>
</div>
<div id="sub_info">&nbsp;&nbsp;<img src="images/hi.gif" />&nbsp;
<span id="show_text">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>
<a  href="role.do?action=init" class="link"><%=lang.readGm(GMLangConstants.ROLE_MANAGE)%></a>>>
<%=lang.readGm(GMLangConstants.ROLE)%>#${c.id}</span>
</div>

<div class="nofloat" />
<table name='tab_1' class="detail roleBasicInfo no_bottom"  cellspacing="0" cellpadding="0" style="width: 30%;"
	border="0" >
	<tbody>
        <tr>
         <th colspan="2">&nbsp;<%=lang.readGm(GMLangConstants.C_BASIC_INFO)%></th>
        </tr>
		<tr>
		 <td class="label">&nbsp;<%=lang.readGm(GMLangConstants.CUR_TITLE)%></td>
         <td>&nbsp;&nbsp;
			${curTile}
        </td>
		</tr>
	</tbody>
</table>
<table name='tab_1' class="detail roleBasicInfo no_bottom"  cellspacing="0" cellpadding="0" style="width: 30%;"
	border="0" >
	<tbody>
        <tr>
         <th colspan="2">&nbsp;<%=lang.readGm(GMLangConstants.GET_TITLES)%></th>
        </tr>
		<tr>
		 <td class="label ">&nbsp;${titles}</td>
		</tr>
	</tbody>
</table>
</div>
</body>
</html>