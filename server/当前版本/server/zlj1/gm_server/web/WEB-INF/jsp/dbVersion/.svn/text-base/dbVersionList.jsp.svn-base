<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

<title>Insert title here</title>
<script  type="text/javascript"><!--
$().ready(function(){
	  var type="${searchType}";
	  if(type=="userId"){
		$("#searchType").val("userId");
		$("#man_nav_1").attr("class","bg_image");
	    $("#man_nav_2").attr("class","bg_image_onclick");
	   }
	  var state="${userStatus}";
	  if(state=="0"){
		  $("#unlock").attr("selected","selected");
	  }else if(state=="1"){
		  $("#lock").attr("selected","selected");
	  }else{
		  $("#all").attr("selected","selected");
	  }
	  var accountType="${accountType}";
	  if(accountType=="0"){
		  $("#pri0").attr("selected","selected");
	  }else if(accountType=="1"){
		  $("#pri1").attr("selected","selected");
	  }else if(accountType=="2"){
		  $("#pri2").attr("selected","selected");
	  }else{
		  $("#pri-1").attr("selected","selected");
	  }
      $("#selectAll").click(function(){
    	  var selectAll= $("#selectAll").attr("checked");
    		 if(selectAll==true){
    	     $("input[name^='users']").each(function(){
    				$(this).attr("checked",true);
    	      });
    		 }else{
    			 $("input[name^='users']").each(function(){
    		 			$(this).attr("checked",false);
    		      });
    		 }

       }); 
	});

function list_sub_nav(Id){
   $("li[id^='man_nav']").each(function(){
    	  $(this).attr("class","bg_image");
        });
   if($("#"+Id).attr("class") == "bg_image"){
	  $("#"+Id).attr("class","bg_image_onclick");
   }
   showInnerText(Id);
}

function showInnerText(Id){
    var switchId = parseInt(Id.substring(8));
	var showText = "";
	switch(switchId){
	    case 1:
		   $("#searchType").val("username");
		   break;
	    case 2:
		   $("#searchType").val("userId");
		   break;
	}
}

function goTo(i){
	var searchType=$("#searchType").val();
    var searchValue=$("#searchValue").val();
    var userStatus=$("#userStatus").val();
	var accountType=$("#accountType").val();
	window.location.href="dbVersion.do?action=init&currentPage="+i+"&searchType="+searchType+"&searchValue="+searchValue+"&userStatus="+userStatus+"&accountType="+accountType;
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

function search(){
	var searchType=$("#searchType").val();
	var searchValue=$("#searchValue").val();
	var userStatus=$("#userStatus").val();
	var accountType=$("#accountType").val();
	window.location.href="dbVersion.do?action=init&searchType="+searchType+"&searchValue="+searchValue+"&userStatus="+userStatus+"&accountType="+accountType;
}

function batchLockUser(){
	var len=$("input[name^='users']:checked").length;
	if(len==0){
		alert('<%=lang.readGm(GMLangConstants.NO_USER_ALERT)%>');
	    return false;
	}
	var userIds = "";
	$("input[name^='users']:checked").each(function(){
		userIds = userIds+$(this).attr("id")+",";
	});
	userIds = userIds.substring(0,userIds.length-1);
	window.location='dbVersion.do?action=batchLockUserInit&userIds='+userIds;
}

function unBatchLockUser(){
	var len=$("input[name^='users']:checked").length;
	if(len==0){
		alert('<%=lang.readGm(GMLangConstants.NO_USER_ALERT)%>');
	    return false;
	}
	var userIds = "";
	$("input[name^='users']:checked").each(function(){
		userIds = userIds+$(this).attr("id")+",";
	});
	userIds = userIds.substring(0,userIds.length-1);
	$.post("dbVersion.do?action=unBatchLockUser",{userIds:userIds},function(info){
		var data=$.trim(info);  
		if("true"==data){
			alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
			window.location = "dbVersion.do?action=init";
		}else{
			alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
			window.location = "dbVersion.do?action=init";
		}
	});
 }

--></script>
</head>
<body>
<div id="man_zone" >
<div class="topnav"><a href="homePage.do?action=welcome">
<%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>&gt;&gt;
<%= lang.readGm(GMLangConstants.GAME_WORLD_MANAGE) %>&gt;&gt;
<%= lang.readGm(GMLangConstants.EMPLOYEEOPERATION) %>
</div>
<div id="nav">
    <ul>  
        <li id="man_nav_1"  onclick="list_sub_nav(id)"  class="bg_image_onclick"><%= lang.readGm(GMLangConstants.USER_NAME)%></li>
		<li id="man_nav_2"  onclick="list_sub_nav(id)"  class="bg_image"><%= lang.readGm(GMLangConstants.USER_ID)%></li>
     </ul>
</div>

<div id="sub_info">
<span id="show_text">
<input id='searchValue' type='text' value="${searchValue}"/>
</span>&nbsp;&nbsp;
<input id="searchType" type="hidden" value="username">
<span><%= lang.readGm(GMLangConstants.COMMON_STATE)%>：</span>
<select id="userStatus">
<option id="all" value="-1"><%= lang.readGm(GMLangConstants.REASON_ALL)%></option>
<option id="unlock" value="0"><%= lang.readGm(GMLangConstants.COMMON_NOR)%></option>
<option id="lock" value="1"><%= lang.readGm(GMLangConstants.LOCKED)%></option>
</select>&nbsp;&nbsp;
<span><%= lang.readGm(GMLangConstants.ACCOUNTTYPE)%>：</span>
<select id="accountType">
<option id="pri-1" value="-1"><%= lang.readGm(GMLangConstants.REASON_ALL)%></option>
<option id="pri0"  value="0"><%= lang.readGm(GMLangConstants.PLAYER)%></option>
<option id="pri1"  value="1"><%= lang.readGm(GMLangConstants.GM)%></option>
<option id="pri2"  value="2"><%= lang.readGm(GMLangConstants.DEBUG)%></option>
</select>&nbsp;&nbsp;
<input id="search" type="button" class="butcom" style="margin-left: 1em;" value="<%= lang.readGm(GMLangConstants.COMMON_SEARCH)%>" onClick="javaScript:search();"/>&nbsp;&nbsp;
<input id="batchSearch" type="button" class="butcom" style="margin-left: 1em;" value="<%= lang.readGm(GMLangConstants.BATCH_SEARCH_LASTLOGIN)%>" onclick="javaScript:window.location='dbVersion.do?action=batchSearchInit'">
</div>

<div class="nofloat" />
<form id="userForm">
<table class="detail"  cellspacing="0" cellpadding="0" border="0">
  <tbody><tr>
	<th style="padding-left: 0px;">
	<input id="selectAll" type="checkbox" />
	</th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.BOSS_ID)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.DBVERSION_VERSION)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.DBVERSION_UPDATETIME)%></th>
  <c:forEach items="${dbVersionList}" var="dbVersion">
      <tr>
		<td><input type="checkbox" id="${dbVersion.id}" name="users"/></td>
        <td>&nbsp; ${dbVersion.id}</td>
        <td>&nbsp;${dbVersion.version}</td>
        <td>&nbsp;${dbVersion.updateTime}</td>
      </tr>
 	</c:forEach>
  <tr>
     <td id="num_style" height="30" colspan="4" style="border-bottom: 0px;width: 100%;text-align:right;">
     	</data>
    </td>
  </tr>
</tbody></table>
</form>
</div>
</div>
</body>
</html>