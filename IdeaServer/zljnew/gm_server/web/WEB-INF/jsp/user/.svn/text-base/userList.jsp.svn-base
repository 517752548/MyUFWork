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
	window.location.href="user.do?action=init&currentPage="+i+"&searchType="+searchType+"&searchValue="+searchValue+"&userStatus="+userStatus+"&accountType="+accountType;
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
	window.location.href="user.do?action=init&searchType="+searchType+"&searchValue="+searchValue+"&userStatus="+userStatus+"&accountType="+accountType;
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
	window.location='user.do?action=batchLockUserInit&userIds='+userIds;
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
	$.post("user.do?action=unBatchLockUser",{userIds:userIds},function(info){
		var data=$.trim(info);  
		if("true"==data){
			alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
			window.location = "user.do?action=init";
		}else{
			alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
			window.location = "user.do?action=init";
		}
	});
 }
function forbidtalk(id){
	window.location.href="user.do?action=foribdtalk&passId="+id;
}
--></script>
</head>
<body>
<div id="man_zone" >
<div class="topnav"><a href="homePage.do?action=welcome">
<%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>&gt;&gt;
<%= lang.readGm(GMLangConstants.GAME_LOG) %>&gt;&gt;
<%= lang.readGm(GMLangConstants.ROLEACCOUNT) %>
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
<input id="batchSearch" type="button" class="butcom" style="margin-left: 1em;" value="<%= lang.readGm(GMLangConstants.BATCH_SEARCH_LASTLOGIN)%>" onclick="javaScript:window.location='user.do?action=batchSearchInit'">
</div>

<div class="nofloat" />
<form id="userForm">
<table class="detail"  cellspacing="0" cellpadding="0" border="0">
  <tbody><tr>
	<th style="padding-left: 0px;">
	<input id="selectAll" type="checkbox" />
	</th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.USER_ID)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.USER_NAME)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.USER_LASTLOGONIP)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.COMMON_LASTLOGONDATE)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.COMMON_STATE)%></th>
	<th>&nbsp;<%= lang.readGm(GMLangConstants.ACCOUNTTYPE)%></th>
    <c:if test="${DBType eq 1}">
	<th>&nbsp;<%= lang.readGm(GMLangConstants.COMMON_OPERATION)%>
	<th>&nbsp;<%=lang.readGm(GMLangConstants.FORBID)%></th> 
	&nbsp;<a id="importCSV"  href="user.do?action=importCSVInit"><%= lang.readGm(GMLangConstants.IMPORT_CSV)%></a>
	&nbsp;<a id="batchLockUser"  onclick="javaScript:batchLockUser();" ><%= lang.readGm(GMLangConstants.BATCH_LOCK_USERS)%></a>
    &nbsp;<a id="unBatchLockUser"  onclick="javaScript:unBatchLockUser();" ><%= lang.readGm(GMLangConstants.BATCH_UNLOCK_USERS)%></a></th>
    </c:if>
  </tr>
  <c:forEach items="${userInfoList}" var="u">
      <tr>
		<td><input type="checkbox" id="${u.id}" name="users"/></td>
        <td>&nbsp;
         <c:choose>
          <c:when test="${DBType eq 1 && lev >2}">
            ${u.id}
          </c:when>
          <c:otherwise>
           <a href="role.do?action=init&searchType=userId&searchValue=${u.id}" class="link">${u.id}</a>
          </c:otherwise>
        </c:choose>
        </td>
        <td>&nbsp;${u.name}</td>
        <td>&nbsp;${u.lastLoginIp}</td>
        <td>&nbsp;<fmt:formatDate value="${u.lastLoginTime}" pattern="yyyy-MM-dd HH:mm:ss"/></td>
        <td>&nbsp;<c:choose>
        	  <c:when test="${u.lockStatus eq 0}"><%= lang.readGm(GMLangConstants.COMMON_NOR)%></c:when>
			  <c:when test="${u.lockStatus eq 1}"><span class="red"><%= lang.readGm(GMLangConstants.LOCKED)%></span></c:when>
        	</c:choose>
       </td>
        <td>&nbsp;<c:choose>
        	  <c:when test="${u.role eq 0}"><%= lang.readGm(GMLangConstants.PLAYER)%></c:when>
			  <c:when test="${u.role eq 1}"><%= lang.readGm(GMLangConstants.GM)%></c:when>
			  <c:when test="${u.role eq 2}"><%= lang.readGm(GMLangConstants.DEBUG)%></c:when>	
        	</c:choose>
       </td>
       <c:if test="${DBType eq 1}">
	        <td>&nbsp;
	          
			           <c:if test="${sRole eq 'admin'||sRole eq 'super_admin'}">
						<img class="pointer" title="<%= lang.readGm(GMLangConstants.USER_PRI)%>"   src="images/b_edit.png" onclick="javascript:window.location='user.do?action=grantPrivilegeInit&id=${u.id}';" />&nbsp;&nbsp;
			           </c:if>
						<c:choose>
				        	  <c:when test="${u.lockStatus eq 0}"> <input type="button" class="butcom" value="<%= lang.readGm(GMLangConstants.LOCK_NUM)%>" onclick="javascript:window.location='user.do?action=lockUserInit&id=${u.id}';"/></c:when>
							  <c:when test="${u.lockStatus eq 1}"> <input type="button" class="butcom" value="<%= lang.readGm(GMLangConstants.VIEW)%>" onclick="javascript:window.location='user.do?action=unlockUserInit&id=${u.id}';"/></c:when>
				        </c:choose>
			</td>
		</c:if>
			<td>&nbsp;
				<c:if test="${time < u.foribedTalkTime}"><a href="#" class="link pointer" onclick="javaScript:forbidtalk('${u.id}');"><%=lang.readGm(GMLangConstants.FORIBD_TALK_RESET)%></c:if>
				<c:if test="${time >= u.foribedTalkTime}"><a href="#" class="link pointer" onclick="javaScript:forbidtalk('${u.id}');"><%=lang.readGm(GMLangConstants.FORBID)%></c:if>
			</td>
      </tr>
 	</c:forEach>
  <tr>
     <td id="num_style" height="30" colspan="9" style="border-bottom: 0px;width: 100%;text-align:right;">
     	</data>
    </td>
  </tr>
</tbody></table>
</form>
</div>
</div>
</body>
</html>