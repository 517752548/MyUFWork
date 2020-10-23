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
  
  var state = "${state}";
  if(state == "1"){
	  $("#state1").attr("selected","selected");
  }else if(state == "2"){
	  $("#state2").attr("selected","selected");
  }else{
	  $("#state-1").attr("selected","selected");
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
	var startLevel = $("#startLevel").val();
	var endLevel = $("#endLevel").val();
	var startIndexSort = $("#startIndexSort").val();
	var endIndexSort = $("#endIndexSort").val(); 
	var huntBag = $("#huntBag").val();
	var trainType = $("#trainType").val();
	var state = $("#state").val();
	window.location.href="pet.do?action=init&searchType="+searchType+"&searchValue="+searchValue+"&startLevel="+startLevel+"&endLevel="+endLevel+"&startIndexSort="+startIndexSort+"&endIndexSort="+endIndexSort+"&huntBag="+huntBag+"&trainType="+trainType+"&state="+state;
}
function goTo(i){
	var searchType=$("#searchType").val();
    var searchValue=$("#searchValue").val();
    var startLevel = $("#startLevel").val();
	var endLevel = $("#endLevel").val();
	var startIndexSort = $("#startIndexSort").val();
	var endIndexSort = $("#endIndexSort").val(); 
	var huntBag = $("#huntBag").val();
	var trainType = $("#trainType").val();
	var state = $("#state").val();
    var url=window.location.toString().split("&");
	window.location.href=url[0]+'&currentPage='+i+"&searchType="+searchType+"&searchValue="+searchValue+"&startLevel="+startLevel+"&endLevel="+endLevel+"&startIndexSort="+startIndexSort+"&endIndexSort="+endIndexSort+"&huntBag="+huntBag+"&trainType="+trainType+"&state="+state;;
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
		$.post("secretary.do?action=kickOut",{"id":"'"+id+"'"},function(info){
			var info = $.trim(info);
			if(info=="ok"){
              alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
              window.location="secretary.do?action=init";
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
	<li id="man_nav_1"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.SECRETARY_CHARID)%>')"
		class="bg_image"><%=lang.readGm(GMLangConstants.SECRETARY_CHARID)%></li>
	<li id="man_nav_2"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.SECRETARY_TEMOLATEID)%>')"
		class="bg_image"><%=lang.readGm(GMLangConstants.SECRETARY_TEMOLATEID)%></li>   
</ul>
</div>
<div id="sub_info">
<span id="show_text">
	<input	id='searchValue' type='text' value="${searchValue}" />&nbsp;&nbsp;
    <span><%=lang.readGm(GMLangConstants.ROLE)%><%=lang.readGm(GMLangConstants.ROLE_LEVEL)%>:<input id='startLevel' type='text' value="${startLevel}" style="width: 50px;"/>&mdash;&mdash;<input id='endLevel' type='text' value="${endLevel}" style="width: 50px;margin:0px;"/></span>&nbsp;&nbsp;
 	<span><%=lang.readGm(GMLangConstants.SECRETARY_EXP)%>:<input id='startIndexSort' type='text' value="${startIndexSort}" style="width: 50px;"/>&mdash;&mdash;<input id='endIndexSort' type='text' value="${endIndexSort}" style="width: 50px;margin:0px;"/></span>&nbsp;&nbsp;
 	<span>
 		<%=lang.readGm(GMLangConstants.SECRETARY_STATE)%>:
 		<select id="state" name="state">
 			<option id="state-1"  value="-1"><%=lang.readGm(GMLangConstants.ALL)%></option>
			<option id="state1"  value="1"><%=lang.readGm(GMLangConstants.SECRETARY_NORMAL)%></option>
			<option id="state2"  value="2"><%=lang.readGm(GMLangConstants.SECRETARY_FIRE)%></option>
			</select>
 	</span>
</span>&nbsp;&nbsp;
 <input id="searchType" type="hidden" value="userName"/> 
<input id="search" type="button" class="butcom" style="margin-left: 1em;" 	value="<%=lang.readGm(GMLangConstants.COMMON_SEARCH)%>"
	onClick="javaScript:search();" />&nbsp;&nbsp;
</div>

<div class="nofloat" />
<table class="detail"  cellspacing="0" cellpadding="0" border="0">
  <tbody><tr>
	<!-- <th style="padding-left: 0px;">
	<input id="selectAll" type="checkbox" />
	</th> -->
	<th>&nbsp;<%= lang.readGm(GMLangConstants.SECRETARY_ID)%></th>
	<th>&nbsp;<%= lang.readGm(GMLangConstants.SECRETARY_CHARID)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.SECRETARY_LEVEL1)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.SECRETARY_EXP)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.SECRETARY_TEMOLATEID)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.SECRETARY_STATE)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.SECRETARY_SKILL_ID)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.SECRETARY_TYPE)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.SECRETARY_CREATEDATE)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.SECRETARY_LAST_FIRE_DATE)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.SECRETARY_LAST_HIRE_DATE)%></th>
 	
  </tr>
  <c:forEach items="${secretaryList}" var="pet">
      <tr>
		<!-- <td><input type="checkbox" id="${secretary.id}" name="users"/></td> -->
        <td>&nbsp;${pet.id}</td>
        <td><a href="role.do?action=init&searchType=roleId&searchValue=${pet.charId}" class="link">&nbsp;${pet.charId} </a></td>
        <td>&nbsp;${pet.level}</td>
        <td>&nbsp;${pet.exp}</td> 
        <td>&nbsp;${pet.templateId}</td>
        <td>&nbsp;${pet.petState}</td>
        <td>&nbsp;</td>
        <td>&nbsp;${pet.petType}</td>
        <td>&nbsp;<fmt:formatDate pattern="yyyy-MM-dd HH:mm" value="${pet.createDate}" /></td>
        <td>&nbsp;<fmt:formatDate pattern="yyyy-MM-dd HH:mm" value="${pet.lastFireDate}" /></td>
        <td>&nbsp;<fmt:formatDate pattern="yyyy-MM-dd HH:mm" value="${pet.lastHireDate}" /></td>
      </tr>
 	</c:forEach>
  <tr>
     <td id="num_style" height="30" colspan="18" style="border-bottom: 0px;width: 100%;text-align:right;">
     	</data>
    </td>
  </tr>
</tbody></table>
</div>
</div>
</body>
</html>