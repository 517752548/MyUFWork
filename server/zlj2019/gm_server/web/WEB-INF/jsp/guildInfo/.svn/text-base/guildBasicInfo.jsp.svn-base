<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title></title>
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
<%=lang.readGm(GMLangConstants.GUILD_BASIC_INFO)%>
</div>

<div id="nav">
<ul>
	<li id="man_nav_1"
		onclick="javaScript:window.location='guildInfo.do?action=initGuildBasicInfo&id=${guildId}&guildName=${guildName}';"
		class="bg_image_onclick" ><%=lang.readGm(GMLangConstants.C_BASIC_INFO)%></li>
	<li id="man_nav_2" 
		onclick="javaScript:window.location='guildInfo.do?action=initGuildMember&id=${guildId}&guildName=${guildName}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.GUILD_MEMBER)%></li>     
</ul>
</div>

<div id="sub_info">
</div>

<table id='tab_1' class="detail guildBasicInfo no_bottom" cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
        <tr>
         <th colspan="10">&nbsp;<%=lang.readGm(GMLangConstants.GUILD_BASIC_INFO)%></th>
        </tr>
		<tr>
		 <td class="label">&nbsp;<%=lang.readGm(GMLangConstants.GUILD_NAME)%></td>
         <td>&nbsp;${guildName}</td>
		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.GUILD_ID)%></td>
         <td >&nbsp;${guildId}</td>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.CREATOR_NAME)%></td>
         <td>&nbsp;${guild.creatorName}</td>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.LEADER_NAME)%></td>
         <td>&nbsp;${guild.leaderName}</td>
 		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.CREATE_TIME)%></td>
         <td>&nbsp;${guild.createdTime}</td>
		</tr>
        <tr>
		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.GUILD_LEVEL)%></td>
         <td>&nbsp;${guild.guildLevel}</td>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.GUILD_SYMBOL_NAME)%></td>
         <td>&nbsp;${guild.guildSymbolName}</td>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.GUILD_SYMBOL_LEVEL)%></td>
         <td>&nbsp;${guild.guildSymbolLevel}</td>
		</tr>
	</tbody>
</table>

<table id='tab_2' class="detail guildBasicInfo no_bottom" cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
        <tr>
         <th colspan="10">&nbsp;<%=lang.readGm(GMLangConstants.GUILD_TECH)%></th>
        </tr>
        <tr>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.GUILD_TECH_NAME)%></th>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.GUILD_TECH_LEVEL)%></th>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.GUILD_TECH_PROGRESS)%></th>
        </tr>
		<tr>
		<c:forEach items="${guildTechInfoList}" var="guildTech" varStatus="count" begin="0">
			<tr>
				<td>
					<c:forEach items="${dataMap['guildTechName']}" var="guildTechName" >
	            		<c:if test="${guildTechName.key eq count.index}">
	            			<c:out value="${language.readGm(guildTechName.value)}" />
	            		</c:if>
       				</c:forEach>
				</td>
				<td>
					${guildTech.level}
				</td>
				<td>
					${guildTech.progress}
				</td>
			</tr>
       	</c:forEach>
	</tbody>
</table>
</div>
</body>
</html>