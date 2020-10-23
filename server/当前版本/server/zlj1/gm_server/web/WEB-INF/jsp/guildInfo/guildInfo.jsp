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
function search(){
	var guildName=$("#guildName").val();
	window.location.href="guildInfo.do?action=init&guildName="+guildName;
}
function goTo(i){
	var guildName=$("#guildName").val();
    var url=window.location.toString().split("&");
	window.location.href=url[0]+'&currentPage='+i+"&guildName="+guildName;
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
<a class="link" href="homePage.do?action=welcome"><%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>&gt;&gt;
<%= lang.readGm(GMLangConstants.GAME_WORLD_MANAGE) %>&gt;&gt;
<%= lang.readGm(GMLangConstants.GUILD_MANAGE) %>
</div>

<div id="nav">
<ul>
    <li id="man_nav_1"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.GUILD_NAME)%>')"
		class="bg_image_onclick"><%=lang.readGm(GMLangConstants.GUILD_NAME)%></li>
</ul>
</div>

<div id="sub_info">
<span id="show_text">
	<input	id='guildName' type='text' value="${guildName}" />&nbsp;&nbsp;
</span>
<input id="search" type="button" class="butcom" style="margin-left: 1em;" 	value="<%=lang.readGm(GMLangConstants.COMMON_SEARCH)%>"
	onClick="javaScript:search();" />
</div>

<table class="detail"  cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
		<tr>
			<th><%=lang.readGm(GMLangConstants.GUILD_ID)%></th>
			<th><%=lang.readGm(GMLangConstants.GUILD_NAME)%></th>
			<th><%=lang.readGm(GMLangConstants.GUILD_LEVEL)%></th>
			<th><%=lang.readGm(GMLangConstants.ROLE_ALLIANCE_TYPE)%></th>
			<th><%=lang.readGm(GMLangConstants.GUILD_SYMBOL_NAME)%></th>
			<th><%=lang.readGm(GMLangConstants.GUILD_SYMBOL_LEVEL)%></th>
			<th><%=lang.readGm(GMLangConstants.CREATOR_NAME)%></th>
			<th><%=lang.readGm(GMLangConstants.LEADER_NAME)%></th>
			<th><%=lang.readGm(GMLangConstants.COMMON_STATE)%></th>
			<th><%=lang.readGm(GMLangConstants.CREATE_TIME)%></th>

		</tr>
		<c:forEach items="${guildInfoList}" var="guild">
			<tr>
				<td>&nbsp;${guild.id}</td>
				<td><a href="guildInfo.do?action=initGuildBasicInfo&id=${guild.id}&guildName=${guild.guildName}" class="link">&nbsp;${guild.guildName}</a></td>
				<td>&nbsp;${guild.guildLevel}</td>
				<td>&nbsp;
					<c:choose>
					    <c:when test="${guild.alliance eq 1}">
			            	<%=lang.readGm(GMLangConstants.ALLIANCE_TONGMENTGUO)%>
			            </c:when>
			            <c:when test="${guild.alliance eq 2}">
			           		<%=lang.readGm(GMLangConstants.ALLIANCE_ZHOUXINGUO)%>
			           	</c:when>
			           	<c:when test="${guild.alliance eq 4}">
			            	<%=lang.readGm(GMLangConstants.ALLIANCE_GONGCHANGUOJI)%>
			            </c:when>
			            <c:when test="${guild.alliance eq 7}">
			           		<%=lang.readGm(GMLangConstants.ALLIANCE_QUANZHENYING)%>
			           	</c:when>
			           	<c:otherwise>
			           		${guild.alliance}
	          		 	</c:otherwise>
			         </c:choose>
         		</td>
				<td>&nbsp;${guild.guildSymbolName}
				</td>
				<td>&nbsp;${guild.guildSymbolLevel}
				</td>
				<td>&nbsp;${guild.creatorName}
				</td>
				<td>&nbsp; ${guild.leaderName}</td>
				<td>&nbsp;
				<c:forEach items="${dataMap['guildState']}" var="guildState" >
             		<c:if test="${guildState.key eq guild.state}"><c:out value="${language.readGm(guildState.value)}" /></c:if>
         		</c:forEach>
				</td>
				<td>&nbsp;<fmt:formatDate pattern="yyyy-MM-dd HH:mm:ss" value="${guild.createdTime}" /></td>
			</tr>
		</c:forEach>
    <tr>
	   <td id="num_style" height="30" colspan="25" style="border-bottom: 0px;text-align:right;">
	     </data>
	    </td>
  </tr>
	</tbody>
</table>
</div>
</body>
</html>