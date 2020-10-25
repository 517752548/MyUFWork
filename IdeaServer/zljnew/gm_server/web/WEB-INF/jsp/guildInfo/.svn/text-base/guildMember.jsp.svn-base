<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>mmo</title>
<script type="text/javascript">
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
		   break;
	}
}
function goTo(i){
    var url=window.location.toString().split("&");
	window.location.href=url[0]+'&currentPage='+i+"&guildName=${guildName}&id=${guildId}";
   }
  function jumpTo(){
   var pno=$("#pno").val();
   if(is_int(pno)==false){
		alert('<%= lang.readGm(GMLangConstants.INTERVAL_NOT_NEG)%>');
		$("#pno").focus();
		return false;
	}
   goTo(pno);
   }
</script>
</head>
<body>
<div id="man_zone">

<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>&gt;&gt; 
<%= lang.readGm(GMLangConstants.GAME_WORLD_MANAGE) %>&gt;&gt;
<a href="guildInfo.do?action=init"><%= lang.readGm(GMLangConstants.GUILD_MANAGE) %></a>&gt;&gt;
<%=lang.readGm(GMLangConstants.GUILD_MEMBER)%>
</div>

<div id="nav">
<ul>
	<li id="man_nav_1"
		onclick="javaScript:window.location='guildInfo.do?action=initGuildBasicInfo&id=${guildId}&guildName=${guildName}';"
		class="bg_image" ><%=lang.readGm(GMLangConstants.C_BASIC_INFO)%></li>
	<li id="man_nav_2" 
		onclick="javaScript:window.location='guildInfo.do?action=initGuildMember&id=${guildId}&guildName=${guildName}';"
		class="bg_image_onclick"><%=lang.readGm(GMLangConstants.GUILD_MEMBER)%></li>     
</ul>
</div>

<div id="sub_info">
</div>

<table class="detail"  cellspacing="0" cellpadding="0" border="0" >
	<tbody>
		<tr>
			<th><%=lang.readGm(GMLangConstants.MEMBER_ID)%></th>
			<th><%=lang.readGm(GMLangConstants.ROLE_NAME)%></th>
			<th><%=lang.readGm(GMLangConstants.ROLE)%><%=lang.readGm(GMLangConstants.LEVEL)%></th>
			<th><%=lang.readGm(GMLangConstants.RANK)%></th>
			<th><%=lang.readGm(GMLangConstants.JOIN_TIME)%></th>
			<th><%=lang.readGm(GMLangConstants.COMMON_STATE)%></th>
			<th><%=lang.readGm(GMLangConstants.GUILDMEMBER_CUR_CONTRIBUTE)%></th>
			<th><%=lang.readGm(GMLangConstants.LAST_ONLINE_TIME)%></th>
		</tr>
		<c:forEach items="${guildMemberList}" var="guildMember">
			<tr>
				<td>&nbsp;<a href="role.do?action=roleBasicInfo&id=${guildMember.roleId}" class="link">${guildMember.roleId}</a></td>
				<td>&nbsp;${guildMember.name}</td>
				<td>&nbsp;${guildMember.level}</td>
				<td>&nbsp;
				<c:forEach items="${dataMap['guildRankType']}" var="guildRankType" >
             		<c:if test="${guildRankType.key eq guildMember.guildRank}"><c:out value="${language.readGm(guildRankType.value)}" /></c:if>
         		</c:forEach>
				</td>
				<td>&nbsp;<fmt:formatDate pattern="yyyy-MM-dd HH:mm:ss" value="${guildMember.joinTime}" /></td>
				<td>&nbsp;
				<c:forEach items="${dataMap['guildMemberState']}" var="guildMemberState" >
             		<c:if test="${guildMemberState.key eq guildMember.state}"><c:out value="${language.readGm(guildMemberState.value)}" /></c:if>
         		</c:forEach>
				</td>
				<td>&nbsp;${guildMember.curContrib}</td>
				<td>&nbsp;<fmt:formatDate pattern="yyyy-MM-dd HH:mm:ss" value="${guildMember.lastOnlineTime}" /></td>
			</tr>
		</c:forEach>
    <tr>
	   <td id="num_style" height="30" colspan="10" style="border-bottom: 0px;text-align:right;">
	     </data>
	    </td>
  </tr>
	</tbody>
</table>

</div>
</body>
</html>