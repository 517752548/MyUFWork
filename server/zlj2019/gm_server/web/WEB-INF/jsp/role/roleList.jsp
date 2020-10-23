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
	    case 2:
		   $("#searchType").val("userId");
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
	window.location.href="role.do?action=init&searchType="+searchType+"&searchValue="+searchValue+"&startLevel="+startLevel+"&endLevel="+endLevel;
}
function goTo(i){
	var searchType=$("#searchType").val();
    var searchValue=$("#searchValue").val();
    var startLevel = $("#startLevel").val();
	var endLevel = $("#endLevel").val();
    var url=window.location.toString().split("&");
	window.location.href=url[0]+'&currentPage='+i+"&searchType="+searchType+"&searchValue="+searchValue+"&startLevel="+startLevel+"&endLevel="+endLevel;
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
		$.post("role.do?action=kickOut",{"id":"'"+id+"'"},function(info){
			var info = $.trim(info);
			if(info=="ok"){
              alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
              window.location="role.do?action=init";
			}else{
			  alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
			}

		});
	}
}
function forceKickOut(id){
	var con = confirm("<%=lang.readGm(GMLangConstants.CONFRIM)%>?");
	if(con){
		$.post("role.do?action=forceKickOut",{"id":"'"+id+"'"},function(info){
			var info = $.trim(info);
			if(info=="ok"){
              alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
              window.location="role.do?action=init";
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
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.ROLE_NAME)%>')"
		class="bg_image_onclick"><%=lang.readGm(GMLangConstants.ROLE_NAME)%></li>
	<li id="man_nav_1"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.ROLE_ID)%>')"
		class="bg_image"><%=lang.readGm(GMLangConstants.ROLE_ID)%></li>
	<li id="man_nav_2"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.USER_ID)%>')"
		class="bg_image"><%=lang.readGm(GMLangConstants.USER_ID)%></li>
    
</ul>
</div>
<div id="sub_info">
<span id="show_text">
	<input	id='searchValue' type='text' value="${searchValue}" />&nbsp;&nbsp;
    <span><%=lang.readGm(GMLangConstants.ROLE)%><%=lang.readGm(GMLangConstants.ROLE_LEVEL)%>：<input id='startLevel' type='text' value="${startLevel}" style="width: 50px;"/>&mdash;&mdash;<input id='endLevel' type='text' value="${endLevel}" style="width: 50px;margin:0px;"/></span>
</span>&nbsp;&nbsp;
 <input id="searchType" type="hidden" value="userName"/> 
<input id="search" type="button" class="butcom" style="margin-left: 1em;" 	value="<%=lang.readGm(GMLangConstants.COMMON_SEARCH)%>"
	onClick="javaScript:search();" />&nbsp;&nbsp;
<input id="batchSearch" type="button" class="butcom" style="margin-left: 1em;" value="<%= lang.readGm(GMLangConstants.BATCH_SEARCH_LASTLOGIN)%>" onclick="javaScript:window.location='role.do?action=batchSearchInit'">
</div>

<div class="nofloat" />
<table class="detail"  cellspacing="0" cellpadding="0"
	border="0" width="100%">
	<tbody>
		<tr>
			<th><%=lang.readGm(GMLangConstants.ROLE_LOGS)%></th>
			<th><%=lang.readGm(GMLangConstants.ROLE_DETAIL)%></th>
			<th><%=lang.readGm(GMLangConstants.ROLE_ID)%></th>
			<th><%=lang.readGm(GMLangConstants.ROLE_NAME)%></th>
			<th><%=lang.readGm(GMLangConstants.USER_ID)%></th>
			<th><%=lang.readGm(GMLangConstants.ROLE_ALLIANCE_TYPE)%></th>
			<th><%=lang.readGm(GMLangConstants.ROLE_LEVEL)%></th>
			<th><%=lang.readGm(GMLangConstants.COMMON_LASTLOGONDATE)%></th>
			<th><%=lang.readGm(GMLangConstants.COMMON_STATE)%></th> 
			<th><%=lang.readGm(GMLangConstants.COMMON_OPERATION)%></th> 
			<!--<th><%=lang.readGm(GMLangConstants.FORBID)%></th>   -->
		</tr>
		<c:forEach items="${roleList}" var="u">
		<tr>
			<td>&nbsp;
					<c:choose>
          			 <c:when test="${DBType eq 1 && lev >2}">  
          			 <input class="butcom" type="button" value="<%=lang.readGm(GMLangConstants.ROLE_LOGS)%>"
	onClick="javaScript:window.location.href='role.do?action=genLogInit&roleId=${u.id}';" disabled="disabled"/>
          			 </c:when>
	          		  <c:otherwise> 
	          		<input class="butcom" type="button" value="<%=lang.readGm(GMLangConstants.ROLE_LOGS)%>"
	onClick="javaScript:window.location.href='role.do?action=genLogInit&roleId=${u.id}';" />
	          		 </c:otherwise>
        		   </c:choose>
			</td>
			
			<td>&nbsp;
			<c:choose>
          			 <c:when test="${DBType eq 1 && lev >2}">  
          			 <input class="butcom" type="button" value="<%=lang.readGm(GMLangConstants.ROLE_DETAIL)%>" 
          			 	onClick="javaScript:window.location.href='role.do?action=roleBasicInfo&id=${u.id}';" disabled="disabled"/>
          			 </c:when>
	          		  <c:otherwise> 
	          		<input class="butcom" type="button" value="<%=lang.readGm(GMLangConstants.ROLE_DETAIL)%>"
							onClick="javaScript:window.location.href='role.do?action=roleBasicInfo&id=${u.id}';"/>
	          		 </c:otherwise>
        		   </c:choose>
			</td>
			
				<td>&nbsp;${u.id}</td>
                
				<td>&nbsp;${u.name}</td>
                
				<td>&nbsp;
				  <c:choose>
          			 <c:when test="${DBType eq 1 && lev >2}">
						${u.passportId}
					 </c:when>
	          		 <c:otherwise>
	          		 		<a 	href="user.do?action=init&searchType=userId&searchValue=${u.passportId}"
					class="link">${u.passportId}</a>
	          		 </c:otherwise>
        		   </c:choose> 
				</td>
				
				<td>
				<c:choose>
					    <c:when test="${u.country eq 0}">
			            	<%=lang.readGm(GMLangConstants.ALLIANCE_LESS)%>
			            </c:when>
			            <c:when test="${u.country eq 1}">
			           		<%=lang.readGm(GMLangConstants.ALLIANCE_SHU)%>
			           	</c:when>
			           	<c:when test="${u.country eq 2}">
			           		<%=lang.readGm(GMLangConstants.ALLIANCE_WEI)%>			            	
			            </c:when>
			            <c:when test="${u.country eq 3}">
			           		<%=lang.readGm(GMLangConstants.ALLIANCE_WU)%>
			           	</c:when>
			           	<c:otherwise>
			           		${u.country}
	          		 	</c:otherwise>
			         </c:choose>
				</td>
				
				<td>&nbsp;${u.level}</td>
				
				<td>&nbsp;<fmt:formatDate pattern="yyyy-MM-dd HH:mm:ss" value="${u.lastLoginTime}" /></td>
				
				<td>&nbsp;
					<c:choose>
					    <c:when test="${u.onlineStatus eq 0}">
			            	<%=lang.readGm(GMLangConstants.OFFLINE)%>
			            </c:when>
			            <c:when test="${u.onlineStatus eq 1}">
			           		<%=lang.readGm(GMLangConstants.ONLINE)%>
			           	</c:when>
			         </c:choose>
         		</td>
         		
			    <c:if test="${DBType eq 1}">
					<td>&nbsp;<a href="#" class="link pointer" onclick="javaScript:kickOut('${u.id}');"><%=lang.readGm(GMLangConstants.KICKOUT)%></a>
					|&nbsp;<a href="#" class="link pointer" onclick="javaScript:forceKickOut('${u.id}');"><%=lang.readGm(GMLangConstants.FORCEKICKOUT)%></a>
					</td>
                </c:if>
               <!--  <c:if test="${DBType eq 1}">
					<td>&nbsp;<a href="#" class="link pointer" onclick="javaScript:forbidtalk('${u.id}');"><%=lang.readGm(GMLangConstants.FORBID)%></td>
                </c:if> -->
			</tr>
		</c:forEach>
    <tr>
	   <td id="num_style" height="30" colspan="11" width="100%" colspan="11" style="border-bottom: 0px;text-align:right;">
	     </data>
	    </td>
  </tr>
	</tbody>
</table>

</div>
</div>
</body>
</html>