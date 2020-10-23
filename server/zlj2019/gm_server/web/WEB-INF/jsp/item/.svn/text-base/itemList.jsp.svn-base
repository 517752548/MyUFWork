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
  if(state == "0"){
	  $("#state0").attr("selected","selected");
  }else if(state == "1"){
	  $("#state1").attr("selected","selected");
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
	var state = $("#state").val();
	window.location.href="item.do?action=init&searchType="+searchType+"&searchValue="+searchValue+"&startLevel="+startLevel+"&endLevel="+endLevel+"&startIndexSort="+startIndexSort+"&endIndexSort="+endIndexSort+"&state="+state;
}
function goTo(i){
	var searchType=$("#searchType").val();
    var searchValue=$("#searchValue").val();
    var startLevel = $("#startLevel").val();
	var endLevel = $("#endLevel").val();
	var startIndexSort = $("#startIndexSort").val();
	var endIndexSort = $("#endIndexSort").val(); 
	var state = $("#state").val();
    var url=window.location.toString().split("&");
	window.location.href=url[0]+'&currentPage='+i+"&searchType="+searchType+"&searchValue="+searchValue+"&startLevel="+startLevel+"&endLevel="+endLevel+"&startIndexSort="+startIndexSort+"&endIndexSort="+endIndexSort+"&state="+state;
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
		$.post("item.do?action=kickOut",{"id":"'"+id+"'"},function(info){
			var info = $.trim(info);
			if(info=="ok"){
              alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
              window.location="item.do?action=init";
			}else{
			  alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
			}

		});
	}
}

function delItemNotice(itemId,bagType,bagIndex,num,roleUUID){
	var con= confirm("<%=lang.readGm(GMLangConstants.CONFRIM_DEL)%>?");
	if(con){
		$.post("item.do?action=delItem",{itemId:itemId,bagType:bagType,bagIndex:bagIndex,num:num,roleUUID:roleUUID},function(info){
			alert("<%=lang.readGm(GMLangConstants.ITEM_WAIT_FLUSH)%>");
            window.location="item.do?action=init";
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
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.ITEM_CHARID)%>')"
		class="bg_image"><%=lang.readGm(GMLangConstants.ITEM_CHARID)%></li>
	<li id="man_nav_2"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.ITEM_WEARERID)%>')"
		class="bg_image"><%=lang.readGm(GMLangConstants.ITEM_WEARERID)%></li>   
</ul>
</div>
<div id="sub_info">
<span id="show_text">
	<input	id='searchValue' type='text' value="${searchValue}" />&nbsp;&nbsp;
    <span><%=lang.readGm(GMLangConstants.ITEM_TEMPLATEID)%>:<input id='startLevel' type='text' value="${startLevel}" style="width: 50px;"/>&mdash;&mdash;<input id='endLevel' type='text' value="${endLevel}" style="width: 50px;margin:0px;"/></span>&nbsp;&nbsp;
 	<span>
 		<%=lang.readGm(GMLangConstants.ITEM_STATE)%>:
 		<select id="state" name="state">
 			<option id="state-1"  value="-1"><%=lang.readGm(GMLangConstants.ALL)%></option>
			<option id="state0"  value="0"><%=lang.readGm(GMLangConstants.UN_DELETED)%></option>
			<option id="state1"  value="1"><%=lang.readGm(GMLangConstants.DELETED)%></option>
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
    <th>&nbsp;<%= lang.readGm(GMLangConstants.ITEM_CHARID)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.ITEM_WEARERID)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.ITEM_BAGID)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.ITEM_BAGINDEX)%></th>	
 	
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.ITEM_TEMPLATEID)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.ITEM_OVERID)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.ITEM_DELETED)%></th>	
 	
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.ITEM_CREATEIME)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.ITEM_DELETEDATE)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.ITEM_DEADLINE)%></th>	
  </tr>
  <c:forEach items="${itemList}" var="item">
      <tr>
		<!-- <td><input type="checkbox" id="${item.id}" name="users"/></td> -->
        <td><a href="role.do?action=init&searchType=roleId&searchValue=${item.charId}" class="link">&nbsp;${item.charId} </a></td>
        <td>&nbsp;${item.wearerId}</td>
        <td>&nbsp;${item.bagId}</td>
        <td>&nbsp;${item.bagIndex}</td>
        
         <td>&nbsp;${item.templateId}</td>
        <td>&nbsp;${item.overlap}</td>
        <td>&nbsp;${item.deleted}</td>
        
         <td>&nbsp;${item.createTime}</td>
        <td>&nbsp;${item.deleteDate}</td>
        <td>&nbsp;${item.deadline}</td>
        <td>&nbsp;
        	<c:choose>
			<c:when test="${item.deleted eq 0}"><input class="butcom" type="button" value="<%= lang.readGm(GMLangConstants.ITEM_DEL_CONFIRM)%>" onclick="delItemNotice('${item.id}','${item.bagId}','${item.bagIndex}','${item.overlap}','${item.charId}');"/></c:when>
			 <c:when test="${item.deleted eq 1}"><%= lang.readGm(GMLangConstants.ITEM_HAS_DEL)%></c:when>
			</c:choose>
		</td>
      </tr>
 	</c:forEach>
  <tr>
     <td id="num_style" height="30" colspan="15" style="border-bottom: 0px;width: 100%;text-align:right;">
     	</data>
    </td>
  </tr>
</tbody></table>
</div>
</div>
</body>
</html>