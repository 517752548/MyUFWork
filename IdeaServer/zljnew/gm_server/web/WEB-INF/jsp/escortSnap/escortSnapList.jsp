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
    $("#man_nav_3").attr("class","bg_image");
   }
  if(type=="roleId"){
		$("#searchType").val("roleId");
		$("#man_nav_1").attr("class","bg_image_onclick");
		$("#man_nav_2").attr("class","bg_image");
	    $("#man_nav_3").attr("class","bg_image");
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
	    case 3:
		   $("#searchType").val("userName");
		    break; 
	}
}
function search(){
	var searchType=$("#searchType").val();
	var searchValue=$("#searchValue").val();
	var startLevel = $("#startLevel").val();
	var endLevel = $("#endLevel").val();
	var startIndexSort = $("#startIndexSort").val();
	var endIndexSort = $("#endIndexSort").val(); 
	var guildName = $("#guildName").val();
	window.location.href="escortSnap.do?action=init&searchType="+searchType+"&searchValue="+searchValue+"&startLevel="+startLevel+"&endLevel="+endLevel+"&startIndexSort="+startIndexSort+"&endIndexSort="+endIndexSort+"&guildName="+guildName;
}
function goTo(i){
	var searchType=$("#searchType").val();
    var searchValue=$("#searchValue").val();
    var startLevel = $("#startLevel").val();
	var endLevel = $("#endLevel").val();
	var startIndexSort = $("#startIndexSort").val();
	var endIndexSort = $("#endIndexSort").val(); 
	var guildName = $("#guildName").val();
    var url=window.location.toString().split("&");
	window.location.href=url[0]+'&currentPage='+i+"&searchType="+searchType+"&searchValue="+searchValue+"&startLevel="+startLevel+"&endLevel="+endLevel+"&startIndexSort="+startIndexSort+"&endIndexSort="+endIndexSort+"&guildName="+guildName;;
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
function kickOut(id){
	var con = confirm("<%=lang.readGm(GMLangConstants.CONFRIM)%>?");
	if(con){
		$.post("escortSnap.do?action=kickOut",{"id":"'"+id+"'"},function(info){
			var info = $.trim(info);
			if(info=="ok"){
              alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
              window.location="escortSnap.do?action=init";
			}else{
			  alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
			}

		});
	}
}
</script>
</head>
<body>
<div id="man_zone">
<div class="topnav">
<a href="homePage.do?action=welcome"><%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>&gt;&gt;
<%= lang.readGm(GMLangConstants.GAME_LOG) %>&gt;&gt;
<%= lang.readGm(GMLangConstants.ROLE_MANAGE) %>
</div>
<div id="nav">
<ul>
    <li id="man_nav_3"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.ESCORTSNAP_NAME)%>')"
		class="bg_image_onclick"><%=lang.readGm(GMLangConstants.ESCORTSNAP_NAME)%></li>
	<li id="man_nav_1"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.ESCORTSNAP_ID)%>')"
		class="bg_image"><%=lang.readGm(GMLangConstants.ESCORTSNAP_ID)%></li>   
</ul>
</div>
<div id="sub_info">
<span id="show_text">
	<input	id='searchValue' type='text' value="${searchValue}" />&nbsp;&nbsp;
    <span><%=lang.readGm(GMLangConstants.ROLE)%><%=lang.readGm(GMLangConstants.ROLE_LEVEL)%>:<input id='startLevel' type='text' value="${startLevel}" style="width: 50px;"/>&mdash;&mdash;<input id='endLevel' type='text' value="${endLevel}" style="width: 50px;margin:0px;"/></span>&nbsp;&nbsp;
 	<span><%=lang.readGm(GMLangConstants.ESCORTSNAP_CANBEATTACKEDCOUNT)%>:<input id='startIndexSort' type='text' value="${startIndexSort}" style="width: 50px;"/>&mdash;&mdash;<input id='endIndexSort' type='text' value="${endIndexSort}" style="width: 50px;margin:0px;"/></span>&nbsp;&nbsp;
 	<span><%=lang.readGm(GMLangConstants.ESCORTSNAP_GUILDNAME)%>:<input id='guildName' type='text' value="${guildName}" style="width: 50px;"/></span>
</span>&nbsp;&nbsp;
 <input id="searchType" type="hidden" value="userName"/> 
<input id="search" type="button" class="butcom" style="margin-left: 1em;" 	value="<%=lang.readGm(GMLangConstants.COMMON_SEARCH)%>"
	onClick="javaScript:search();" />&nbsp;&nbsp;
<input id="batchSearch" type="button" class="butcom" style="margin-left: 1em;" value="<%= lang.readGm(GMLangConstants.BATCH_SEARCH_LASTLOGIN)%>" onclick="javaScript:window.location='escortSnap.do?action=batchSearchInit'">
</div>

<div class="nofloat" />
<table class="detail"  cellspacing="0" cellpadding="0" border="0">
  <tbody><tr>
	<!-- <th style="padding-left: 0px;">
	<input id="selectAll" type="checkbox" />
	</th> -->
    <th>&nbsp;<%= lang.readGm(GMLangConstants.ESCORTSNAP_ID)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.ESCORTSNAP_NAME)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.REALATION_LEVEL)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.ESCORTSNAP_GUILDNAME)%></th>
 	
 	 <th>&nbsp;<%= lang.readGm(GMLangConstants.ESCORTSNAP_CANBEATTACKEDCOUNT)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.ESCORTSNAP_TOTALATTACKCONUNT)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.ESCORTSNAP_CURRENTMESSENGERID)%></th>
 	<!-- <th>&nbsp;<%= lang.readGm(GMLangConstants.ESCORTSNAP_HELPFRIENDID)%></th>
 	
 	 <th>&nbsp;<%= lang.readGm(GMLangConstants.ESCORTSNAP_HELPFRIENDNAME)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.REALATION_HELPRAPUTION)%></th> -->
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.ESCORTSNAP_STARTESCORTTIME)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.ESCORTSNAP_ESCORTTOTALTIME)%></th>
 	
 	 <th>&nbsp;<%= lang.readGm(GMLangConstants.ESCORTSNAP_MONEYBONUS)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.ESCORTSNAP_MONEYTMLBONUS)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.REALATION_REPUTATIONBONUS)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.ESCORTSNAP_REPUTATIONTMOBONUS)%></th>	
 	
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.ESCORTSNAP_ATTACKERIDS)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.ESCORTSNAP_ITEMID)%></th>	 	
  </tr>
  <c:forEach items="${escortSnapList}" var="escortSnap">
      <tr>
		<!-- <td><input type="checkbox" id="${escortSnap.id}" name="users"/></td> -->
        <td><a href="role.do?action=init&searchType=roleId&searchValue=${escortSnap.id}" class="link">&nbsp;${escortSnap.id} </a></td>
         <td>&nbsp;${escortSnap.name}</td>
        <td>&nbsp;${escortSnap.level}</td>
        <td>&nbsp;${escortSnap.guildName}</td>
        
        <td>&nbsp;${escortSnap.canBeAttackedCount}</td>
         <td>&nbsp;${escortSnap.totalAttackCount}</td>
        <td>&nbsp;${escortSnap.currentMessengerId}</td>
       <!--   <td>&nbsp;${escortSnap.helpFriendId}</td>
        
        <td>&nbsp;${escortSnap.helpFriendName}</td>
         <td>&nbsp;${escortSnap.helpReputation}</td>-->
        <td>&nbsp;${escortSnap.startEscortTime}</td>
        <td>&nbsp;${escortSnap.escortTotalTime}</td>

        
        <td>&nbsp;${escortSnap.moneyBonus}</td>
         <td>&nbsp;${escortSnap.moneyTmplBonus}</td>
        <td>&nbsp;${escortSnap.reputationBonus}</td>
        <td>&nbsp;${escortSnap.reputationTmplBonus}</td>
        
        <td>&nbsp;${escortSnap.attackerIds}</td>
         <td>&nbsp;${escortSnap.itemId}</td>
      </tr>
 	</c:forEach>
  <tr>
     <td id="num_style" height="30" colspan="19" style="border-bottom: 0px;width: 100%;text-align:right;">
     	</data>
    </td>
  </tr>
</tbody></table>
</div>
</div>
</body>
</html>