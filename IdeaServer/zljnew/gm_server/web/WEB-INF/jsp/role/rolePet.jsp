<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/logCommon.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title></title>
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
function searchPet(){
    var name= $("#searchPetName").val();
    window.location.href="role.do?action=rolePet&id=${id}&name="+name;
}
function goTo(i){
	 var name= $("#searchPetName").val();
	 window.location="role.do?action=rolePet&id=${id}&name="+name+"&currentPage="+i;
}
</script>
</head>
<body>
<div id="man_zone" style="width: 100%">
<div class="topnav"><a class="link"
	href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>&gt;&gt;
	<%= lang.readGm(GMLangConstants.GAME_LOG) %>&gt;&gt;
<a href="role.do?action=init" class="link"><%=lang.readGm(GMLangConstants.ROLE_MANAGE)%></a>&gt;&gt;
<%=lang.readGm(GMLangConstants.PET)%></div>

<div id="nav">
<ul>
	<li id="man_nav_1"
		onclick="javaScript:window.location='role.do?action=roleBasicInfo&id=${id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.C_BASIC_INFO)%></li>
	<li id="man_nav_2" class="bg_image_onclick"><%=lang.readGm(GMLangConstants.PET)%></li>
	<li id="man_nav_3"
		onclick="javaScript:window.location='role.do?action=roleItem&id=${id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.ITEM)%></li>
</ul>
</div>

<div id="sub_info">&nbsp;&nbsp; <span> <%=lang.readGm(GMLangConstants.PET_NAME)%>：
<input id="searchPetName" type="text" value="${searchName}" />&nbsp;&nbsp;<input
	type="button" class="butcom" value="<%=lang.readGm(GMLangConstants.COMMON_SEARCH)%>"
	onclick="searchPet()" /> </span></div>

<table id='tab_1' class="detail" cellspacing="0" cellpadding="0"
	border="0">
	<tbody>
		<tr>
			<th>&nbsp;<%=lang.readGm(GMLangConstants.PET_ID)%></th>
			<th>&nbsp;<%=lang.readGm(GMLangConstants.PET_NAME)%></th>
			<th>&nbsp;<%=lang.readGm(GMLangConstants.LEVEL)%></th>
			<th>&nbsp;<%=lang.readGm(GMLangConstants.EXP)%></th>
			<th>&nbsp;<%=lang.readGm(GMLangConstants.SOLDIER_AMOUNT)%></th>
			<th>&nbsp;<%=lang.readGm(GMLangConstants.COMMANDER)%></th>
			<th>&nbsp;<%=lang.readGm(GMLangConstants.COMMON_OPERATION)%></th>
		</tr>
		<c:forEach items="${pets}" var="p">
			<tr>
				<td>&nbsp;<a class="link pointer"
					href="pet.do?action=petBasicInfo&roleId=${id}&petId=${p.id}">${p.id}</a></td>
				<!--
				<td>&nbsp; <c:forEach items="${xlsData['pets']}" var="pet">
					<c:if test="${pet.key eq p.templateId}">
						<c:out value="${pet.value}" />
					</c:if>
				</c:forEach></td>
				--><td>&nbsp;${p.name}</td>
				<td>&nbsp;${p.level}</td>
				<td>&nbsp;${p.exp}</td>
				<td>&nbsp;${p.soldierAmount}</td>
				<td>&nbsp;</td>
				<td>&nbsp; <img class="pointer"
					title="<%=lang.readGm(GMLangConstants.RETIRE)%>"
					src="images/b_edit.png"
					onclick="" />
				</td>
			</tr>
		</c:forEach>
		<tr>
			<td height="30" width="100%" style="border-bottom: 0px;" colspan="8">
			<div id="num_style"></data></div>
			</td>
		</tr>
	</tbody>
</table>
</div>
</body>
</html>