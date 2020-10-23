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
    $("#man_nav_4").attr("class","bg_image");
   }
  if(type=="roleId"){
		$("#searchType").val("roleId");
		$("#man_nav_1").attr("class","bg_image_onclick");
		$("#man_nav_2").attr("class","bg_image");
	    $("#man_nav_3").attr("class","bg_image");
	    $("#man_nav_4").attr("class","bg_image");
	   }
  if(type=="id"){
		$("#searchType").val("id");
		$("#man_nav_1").attr("class","bg_image");
		$("#man_nav_2").attr("class","bg_image");
	    $("#man_nav_3").attr("class","bg_image");
	    $("#man_nav_4").attr("class","bg_image_onclick");
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
	    case 3:
		   $("#searchType").val("userName");
		    break; 
	    case 4:
		   $("#searchType").val("id");
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
	window.location.href="employee.do?action=init&searchType="+searchType+"&searchValue="+searchValue+"&startLevel="+startLevel+"&endLevel="+endLevel+"&startIndexSort="+startIndexSort+"&endIndexSort="+endIndexSort;
}
function goTo(i){
	var searchType=$("#searchType").val();
    var searchValue=$("#searchValue").val();
    var startLevel = $("#startLevel").val();
	var endLevel = $("#endLevel").val();
	var startIndexSort = $("#startIndexSort").val();
	var endIndexSort = $("#endIndexSort").val(); 
    var url=window.location.toString().split("&");
	window.location.href=url[0]+'&currentPage='+i+"&searchType="+searchType+"&searchValue="+searchValue+"&startLevel="+startLevel+"&endLevel="+endLevel+"&startIndexSort="+startIndexSort+"&endIndexSort="+endIndexSort;;
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
		$.post("employee.do?action=kickOut",{"id":"'"+id+"'"},function(info){
			var info = $.trim(info);
			if(info=="ok"){
              alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
              window.location="employee.do?action=init";
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
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.EMPLOYEEname)%>')"
		class="bg_image_onclick"><%=lang.readGm(GMLangConstants.EMPLOYEEname)%></li>
	<li id="man_nav_1"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.ROLE_ID)%>')"
		class="bg_image"><%=lang.readGm(GMLangConstants.ROLE_ID)%></li>
	<li id="man_nav_2"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.EMPLOYEEtemplateId)%>')"
		class="bg_image"><%=lang.readGm(GMLangConstants.EMPLOYEEtemplateId)%></li>  
	<li id="man_nav_4"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.EMPLOYEEid)%>')"
		class="bg_image"><%=lang.readGm(GMLangConstants.EMPLOYEEid)%></li>  
</ul>
</div>
<div id="sub_info">
<span id="show_text">
	<input	id='searchValue' type='text' value="${searchValue}" />&nbsp;&nbsp;
    <span><%=lang.readGm(GMLangConstants.EMPLOYEElevel)%>:<input id='startLevel' type='text' value="${startLevel}" style="width: 50px;"/>&mdash;&mdash;<input id='endLevel' type='text' value="${endLevel}" style="width: 50px;margin:0px;"/></span>&nbsp;&nbsp;
 	<span><%=lang.readGm(GMLangConstants.EMPLOYEEexp)%>:<input id='startIndexSort' type='text' value="${startIndexSort}" style="width: 50px;"/>&mdash;&mdash;<input id='endIndexSort' type='text' value="${endIndexSort}" style="width: 50px;margin:0px;"/></span>
</span>&nbsp;&nbsp;
 <input id="searchType" type="hidden" value="userName"/> 
<input id="search" type="button" class="butcom" style="margin-left: 1em;" 	value="<%=lang.readGm(GMLangConstants.COMMON_SEARCH)%>"
	onClick="javaScript:search();" />&nbsp;&nbsp;
<input id="batchSearch" type="button" class="butcom" style="margin-left: 1em;" value="<%= lang.readGm(GMLangConstants.BATCH_SEARCH_LASTLOGIN)%>" onclick="javaScript:window.location='employee.do?action=batchSearchInit'">
</div>

<div class="nofloat" />
<table class="detail"  cellspacing="0" cellpadding="0"
	border="0" width="100%">
  <tbody><tr>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.EMPLOYEEid)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.EMPLOYEEcharId)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.EMPLOYEEtemplateId)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.EMPLOYEEcreateDate)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.EMPLOYEElastRefreshSkillDate)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.EMPLOYEEname)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.EMPLOYEElevel)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.EMPLOYEEexp)%></th>
 	
  </tr>
  <c:forEach items="${employeeList}" var="employee">
      <tr>
        <td>&nbsp;${employee.id}</td>
          <td><a href="role.do?action=init&searchType=roleId&searchValue=${employee.charId}" class="link">&nbsp;${employee.charId} </a></td>
         <td>&nbsp;${employee.templateId}</td>
        <td>&nbsp;<fmt:formatDate value="${employee.createDate}" pattern="yyyy-MM-dd HH:mm:ss"/></td>
        <td>&nbsp;<fmt:formatDate value="${employee.lastRefreshSkillDate}" pattern="yyyy-MM-dd HH:mm:ss"/></td>
        <td>&nbsp;${employee.name}</td>
        <td>&nbsp;${employee.level}</td>
        <td>&nbsp;${employee.exp}</td>
      </tr>
 	</c:forEach>
  <tr>
     <td id="num_style" height="30" colspan="9" style="border-bottom: 0px;width: 100%;text-align:right;">
     	</data>
    </td>
  </tr>
</tbody></table>
</div>
</div>
</body>
</html>