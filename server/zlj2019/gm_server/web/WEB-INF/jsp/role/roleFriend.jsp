<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/logCommon.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
<script type="text/javascript">
$().ready(function(){
  $("table[name^='tab']").each(function(){
	  	  $(this).hide();
   });
  var tabId = "${tabId}";
  if(tabId=="tab_2"){
	  $("table[name^='tab_2']").each(function(){
	  	  $(this).show();
      });
	  $("#tab_2").attr("class","selected tab"); 
	  $("#tab_1").attr("class","tab"); 
	  $("#selectedTab").val("tab_2");
  }else if(tabId=="tab_3"){
	  $("table[name^='tab_3']").each(function(){
	  	  $(this).show();
      });
	  $("#selectedTab").val("tab_3");
  }else{
	  $("table[name^='tab_1']").each(function(){
	  	  $(this).show();
      });
	  $("#selectedTab").val("tab_1");
  }
});
function list_sub_nav(id,sortname){
	$("li[id^='man_nav']").each(function(){
    	  $(this).attr("class","bg_image");
     });
   if($("#"+id).attr("class")=="bg_image"){
	   $("#"+id).attr("class","bg_image_onclick");
   }
   showInnerText(id);
}

function showInnerText(id){
    var switchId = parseInt(id.substring(8));
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
function switchTab(id){
	$("h2[id^='tab']").each(function(){
    	  $(this).attr("class","tab");
     });
   if($("#"+id).attr("class")=="tab"){
	   $("#"+id).attr("class","selected tab");
   }
   $("table[name^='tab']").each(function(){
	  	  $(this).hide();
	});
   $("table[name^='"+id+"']").each(function(){
	  	  $(this).show();
   });
   $("#selectedTab").val(id);
}
function goTo(i){
	var tabId=$("#selectedTab").val();
	window.location="role.do?action=roleFriend&id=${id}&currentPage="+i+"&tabId="+tabId;
}
</script>
</head>
<body>
<div id="man_zone">
<div id="nav">
<ul>
	<li id="man_nav_1"
		onclick="javaScript:window.location='role.do?action=roleBasicInfo&id=${id}';"
		class="bg_image" ><%=lang.readGm(GMLangConstants.C_BASIC_INFO)%></li>
	<li id="man_nav_2" 
		onclick="javaScript:window.location='role.do?action=rolePet&id=${id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.PET)%></li>
   <li id="man_nav_3"  
		onclick="javaScript:window.location='role.do?action=roleItem&id=${id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.ITEM)%></li>
   <li id="man_nav_4"  
		onclick="javaScript:window.location='role.do?action=roleTask&id=${id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.TASK)%></li>

   <li id="man_nav_6" 
		onclick="javaScript:window.location='role.do?action=roleSkill&id=${id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.SKILL)%></li>
   <li id="man_nav_7" 
		onclick="javaScript:window.location='role.do?action=roleXinfa&id=${id}';"
		class="bg_image"><%=lang.readGm(GMLangConstants.XINFA)%></li>
   <li id="man_nav_8" 
		onclick="javaScript:window.location='role.do?action=roleFriend&id=${id}';"
		class="bg_image_onclick"><%=lang.readGm(GMLangConstants.SOCIAL_RELATION)%></li>


        
</ul>
</div>
<div id="sub_info">&nbsp;&nbsp;<img src="images/hi.gif" />&nbsp;
<span id="show_text">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>  
<a class="link" href="role.do?action=init"><%=lang.readGm(GMLangConstants.ROLE_MANAGE)%></a>>>
<%=lang.readGm(GMLangConstants.ROLE)%>#${id}</span>
</div>
<div class="tab-row">
<h2 id='tab_1' onclick="switchTab(id)" class="selected tab" >
<a href="#"><%=lang.readGm(GMLangConstants.FRIEND)%></a></h2>
<h2 id='tab_2' onclick="switchTab(id)" class="tab" >
<a  href="#"><%=lang.readGm(GMLangConstants.BLACKLIST)%></a></h2>
<h3 id='tab_3' onclick="switchTab(id)" class="tab" >
<a  href="#"><%=lang.readGm(GMLangConstants.MASTERY)%></a></h2>
</div>
<div class="nofloat" />
<input id="selectedTab" type="hidden"/>
<table name='tab_1' class="detail no_bottom"  cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
		<tr>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.FRIEND)%><%=lang.readGm(GMLangConstants.ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.FRIEND)%><%=lang.readGm(GMLangConstants.COMMON_NAME)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.FRIEND)%><%=lang.readGm(GMLangConstants.FRIEND_GROUP)%></th>
 		 <th>&nbsp;<%=lang.readGm(GMLangConstants.AMITY)%></th>
		</tr>
     <c:forEach items="${friends}" var="fvo">
        <tr>
		 <td style="width: 350px;">&nbsp;${fvo.friendRelation.friendUUID}</td>
         <td>&nbsp;
		  ${fvo.friendName}
         </td>
         <td>&nbsp;${fvo.friendRelation.friendGroup + 1}</td>
		 <td>&nbsp;${fvo.friendRelation.frindAmity}</td>
		</tr>
     </c:forEach>
   </tbody>
</table>
<table name='tab_2' class="detail no_bottom"  cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
		<tr>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.BLACKLIST)%><%=lang.readGm(GMLangConstants.ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.BLACKLIST)%><%=lang.readGm(GMLangConstants.COMMON_NAME)%></th>
		</tr>
     <c:forEach items="${blacklists}" var="blacklist">
        <tr>
		 <td>&nbsp;${blacklist.friendRelation.friendUUID}</td>
         <td>&nbsp;${blacklist.friendName}</td>
		</tr>
     </c:forEach>
   </tbody>
</table>
<table name='tab_3' class="detail no_bottom"  cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
		<tr>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.MASTER)%><%=lang.readGm(GMLangConstants.ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.MASTER)%><%=lang.readGm(GMLangConstants.COMMON_NAME)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.COMMON_STATE)%></th>
		</tr>
     <c:forEach items="${masterList}" var="master">
        <tr>
		 <td>&nbsp;<a	href="role.do?action=init&searchType=roleId&searchValue=${master.id}"
					class="link">${master.id}</a></td>
         <td>&nbsp;${master.name}</td>
 		 <td>&nbsp;<c:if test="${master.status eq 0}"><%=lang.readGm(GMLangConstants.NOT_GRADUATE)%></c:if>
		<c:if test="${master.status eq 1}"><%=lang.readGm(GMLangConstants.GRADUATE)%></c:if></td>
		</tr>
     </c:forEach>
   </tbody>
	<tbody>
		<tr>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.DISCIPLE)%><%=lang.readGm(GMLangConstants.ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.DISCIPLE)%><%=lang.readGm(GMLangConstants.COMMON_NAME)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.COMMON_STATE)%></th>
		</tr>
     <c:forEach items="${discipleList}" var="disciple">
        <tr>
		 <td>&nbsp;<a	href="role.do?action=init&searchType=roleId&searchValue=${disciple.id}"
					class="link">${disciple.id}</a></td>
         <td>&nbsp;${disciple.name}</td>
		 <td>&nbsp;<c:if test="${disciple.status eq 0}"><%=lang.readGm(GMLangConstants.NOT_GRADUATE)%></c:if>
		<c:if test="${disciple.status eq 1}"><%=lang.readGm(GMLangConstants.GRADUATE)%></c:if></td>
		</tr>
     </c:forEach>
   </tbody>
</table>
<c:if test="${tabId ne 'tab_3'}">
<table id="table" cellspacing="0" cellpadding="0" width=98%; class="task_page"
	border="0" >
 <tr>
	<td height="30"  style="border-bottom: 0px;width: 100%;text-align: right;">
       <div id="num_style">
         </data>
    </div></td>
</tr> 
</table>
</c:if>
</div>
</body>
</html>