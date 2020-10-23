<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/logCommon.jsp"%>
<%@ page import="com.imop.lj.db.model.ItemEntity"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>mmo</title>
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
function goTo(i){
    window.location="role.do?action=roleRaid&id=${id}&currentPage="+i;
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
	<li id="man_nav_2" 	onclick="javaScript:window.location='role.do?action=rolePet&id=${id}';"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.PET)%>')"
		class="bg_image"><%=lang.readGm(GMLangConstants.PET)%></li>
   <li id="man_nav_3"
		onclick="javaScript:window.location='role.do?action=roleItem&id=${id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.ITEM)%></li>
   <li id="man_nav_4"
		onclick="javaScript:window.location='role.do?action=roleTask&id=${id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.TASK)%></li>
   <li id="man_nav_5"
		onclick="javaScript:window.location='role.do?action=roleTitle&id=${id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.LOG_TYPE_TITLE)%></li>
   <li id="man_nav_6"
		onclick="javaScript:window.location='role.do?action=roleSkill&id=${id}';"
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
		class="bg_image_onclick"><%=lang.readGm(GMLangConstants.RAID)%></li>
</ul>
</div>
<div id="sub_info">&nbsp;&nbsp;<img src="images/hi.gif" />&nbsp;
<span id="show_text">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>
<a class="link" href="role.do?action=init"><%=lang.readGm(GMLangConstants.ROLE_MANAGE)%></a>>>
<%=lang.readGm(GMLangConstants.ROLE)%>#${id}</span>
</div>
<div class="nofloat" />
<table name='tab_1' class="detail" width="1100px" cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
		<tr>
		 <th style="width: 350px;">&nbsp;<%=lang.readGm(GMLangConstants.RAID_ID)%></th>
		 <th style="width: 300px;">&nbsp;<%=lang.readGm(GMLangConstants.RAID_INST_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.LASTENTERTIME)%></th>
 		 <th>&nbsp;<%=lang.readGm(GMLangConstants.TIMES)%></th>
		</tr>
     <c:forEach items="${raids}" var="raid">
          <td>&nbsp;${raid.id}</td>
          <td>&nbsp; ${raid.raidInstId}</td>
		 <td >&nbsp;<fmt:formatDate value="${raid.lastEnterTime}" pattern="yyyy-MM-dd HH:mm:ss"/></td>
		 <td >&nbsp;${raid.times}</td>
        </tr>
     </c:forEach>
		<tr>
			<td height="30" colspan="9" style="border-bottom: 0px;">
			<div id="num_style">
             </data>
             </div></td>
		</tr>
	</tbody>
</table>
</div>
</body>
</html>