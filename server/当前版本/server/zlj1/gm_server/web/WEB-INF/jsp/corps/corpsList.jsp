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
	  if(type=="corpsid"){
		$("#searchType").val("corpsid");
		$("#man_nav_1").attr("class","bg_image");
	    $("#man_nav_2").attr("class","bg_image_onclick");
	   }
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
		   $("#searchType").val("corpsname");
		   break;
	    case 2:
		   $("#searchType").val("corpsid");
		   break;
	}
}

function goTo(i){
	var searchType=$("#searchType").val();
    var searchValue=$("#searchValue").val();
	window.location.href="corps.do?action=init&currentPage="+i+"&searchType="+searchType+"&searchValue="+searchValue;
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
	window.location.href="corps.do?action=init&searchType="+searchType+"&searchValue="+searchValue;
}

function disband(corpsId){
	var con= confirm("<%=lang.readGm(GMLangConstants.CORPS_FORCE_DISBAND)%>?");
	if(con){
		$.post("corps.do?action=disband",{corpsId:corpsId},function(info){
			alert("<%=lang.readGm(GMLangConstants.ITEM_WAIT_FLUSH)%>");
            window.location="corps.do?action=init";
		  });	

	}
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
        <li id="man_nav_1"  onclick="list_sub_nav(id)"  class="bg_image_onclick"><%= lang.readGm(GMLangConstants.CORPS_NAME)%></li>
		<li id="man_nav_2"  onclick="list_sub_nav(id)"  class="bg_image"><%= lang.readGm(GMLangConstants.CORPS_ID)%></li>
     </ul>
</div>

<div id="sub_info">
	<span id="show_text">
		<input id='searchValue' type='text' value="${searchValue}"/>
	</span>&nbsp;&nbsp;
	<input id="searchType" type="hidden" value="corpsname">
	<input id="search" type="button" class="butcom" style="margin-left: 1em;" value="<%= lang.readGm(GMLangConstants.COMMON_SEARCH)%>" onClick="javaScript:search();"/>&nbsp;&nbsp;
</div>

<div class="nofloat" />
<form id="corpsForm">
<table class="detail"  cellspacing="0" cellpadding="0" border="0">
  <tbody><tr>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.CORPS_ID)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.CORPS_NAME)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.CORPS_NOTICE)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.CORPS_COUNTRY)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.CORPS_QQ)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.CORPS_PRESIDENT)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.COMMON_OPERATION)%></th>
  </tr>
  <c:forEach items="${corpsInfoList}" var="corps">
      <tr>
      	<td>&nbsp;${corps.id}</td>
        <td>&nbsp;${corps.name}</td>
        <td>&nbsp;${corps.notice}</td>
		<td>&nbsp; 
			<c:choose>
				<c:when test="${corps.country eq 0}">
						<%=lang	.readGm(GMLangConstants.ALLIANCE_LESS)%>
				</c:when>
				<c:when test="${corps.country eq 1}">
					<%=lang.readGm(GMLangConstants.ALLIANCE_SHU)%>
				</c:when>
				<c:when test="${corps.country eq 2}">
					<%=lang.readGm(GMLangConstants.ALLIANCE_WEI)%>
				</c:when>
				<c:when test="${corps.country eq 3}">
					<%=lang.readGm(GMLangConstants.ALLIANCE_WU)%>
				</c:when>
				<c:otherwise>
					${corps.country}
				</c:otherwise>
			</c:choose>
		</td>
        <td>&nbsp;${corps.qq}</td>
        <td>&nbsp;${corps.presidentName}</td>
        <td><input class="butcom" type="button" value="<%= lang.readGm(GMLangConstants.CORPS_FORCE_DISBAND)%>" onclick="disband('${corps.id}');"/></td>
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