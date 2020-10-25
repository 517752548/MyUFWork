<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

<title>Insert title here</title>
<script  type="text/javascript">
$().ready(function(){
	  var type="${searchType}";
	  if(type=="role"){
		$("#searchType").val("role");
   		$("#man_nav_1").attr("class","bg_image");
	    $("#man_nav_2").attr("class","bg_image_onclick");
	   }
	   var exist="${exist}";
	   if(exist=="false"){
		   window.location='sysUser.do?action=init';
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
		   $("#searchType").val("userName");
		   break;
	    case 2:
		   $("#searchType").val("role");
		   break;
	}
}
 
function search(){
	var searchType=$("#searchType").val();
	var searchValue=$("#searchValue").val();
	window.location.href="sysUser.do?action=init&searchType="+searchType+"&searchValue="+searchValue;
}
function delSysUser(id){
	var con= confirm("<%=lang.readGm(GMLangConstants.CONFRIM_DEL)%>?");
	if(con){
		$.post("sysUser.do?action=delSysUser",{id:id},function(){
	        alert("<%=lang.readGm(GMLangConstants.DEL_SUCCESS)%>");
	        window.location='sysUser.do?action=init';
		  });	

	}
}

</script>
</head>
<body>
<div id="man_zone">
<div class="topnav"><a href="homePage.do?action=welcome">
<%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>&gt;&gt;
<%= lang.readGm(GMLangConstants.SYS) %>&gt;&gt;
<%= lang.readGm(GMLangConstants.USER)%><%= lang.readGm(GMLangConstants.MANAGE)%>
</div>
<div id="nav">
    <ul>  
        <li id="man_nav_1"  onclick="list_sub_nav(id)"  class="bg_image_onclick"><%= lang.readGm(GMLangConstants.SYSUSER_NAME)%></li>
		<li id="man_nav_2"  onclick="list_sub_nav(id)"  class="bg_image">
		<%= lang.readGm(GMLangConstants.ROLE)%></li>
     </ul>
</div>
<div id="sub_info">
<span id="show_text">
<input id='searchValue' type='text' value="${searchValue}"/>
</span>&nbsp;&nbsp;
<input id="searchType" type="hidden" value="userName">    
<input id="search" type="button"  class="butcom" value="<%= lang.readGm(GMLangConstants.COMMON_SEARCH)%>" onClick="javaScript:search();"/>
</div>
<div class="nofloat" />
<table class="detail"  cellspacing="0" cellpadding="0" border="0">
  <tbody><tr>
    <th><%= lang.readGm(GMLangConstants.SYSUSER_NAME)%></th>
    <th><%= lang.readGm(GMLangConstants.COMMON_REGION)%></th>
	<th><%= lang.readGm(GMLangConstants.ROLE)%></th>
	<th><%= lang.readGm(GMLangConstants.COMMON_LASTLOGONDATE)%></th>
	<c:if test="${DBType eq 1}">
	    <th><%= lang.readGm(GMLangConstants.COMMON_OPERATION)%>
	     <c:if test="${sRole eq 'admin'||sRole eq 'super_admin'}">
			<img  class="pointer" title="<%=lang.readGm(GMLangConstants.ADD)%>" src="images/add.gif" onclick="javaScript:window.location='sysUser.do?action=addInitSysUser'"/>
	     </c:if>
	    </th>
	</c:if>
  </tr>
  <c:forEach items="${sysUserList}" var="u">
      <tr>
        <td>&nbsp;${u.username}</td>
        <td> &nbsp;
        	${u.regionName}
        </td>
        <td>&nbsp;
        			                    	    <c:choose>
									  		<c:when test="${u.role eq 'super_admin'}">
									  			<%=lang.readGm(GMLangConstants.SUPER_ADMIN) %>
									  		</c:when>
									  		<c:when test="${u.role eq 'admin'}">
									  			<%=lang.readGm(GMLangConstants.ADMIN) %>
									  		</c:when>
									  		<c:when test="${u.role eq 'maintain'}">
									  			<%=lang.readGm(GMLangConstants.MAINTAIN) %>
									  		</c:when>
									  		<c:when test="${u.role eq 'normal_custom_service'}">
									  			<%=lang.readGm(GMLangConstants.NORMAL_CUSTOM_SERVICE) %>
									  		</c:when>
									  		<c:when test="${u.role eq 'advanced_custom_service'}">
									  			<%=lang.readGm(GMLangConstants.ADVANCED_CUSTOM_SERVICE) %>
									  		</c:when>
									  		<c:when test="${u.role eq 'operation'}">
									  			<%=lang.readGm(GMLangConstants.OPERATION) %>
									  		</c:when>
									  		<c:when test="${u.role eq 'advanced_operation'}">
									  			<%=lang.readGm(GMLangConstants.ADVANCED_OPERATION) %>
									  		</c:when>
									  		<c:when test="${u.role eq 'kaiying'}">
									  			<%=lang.readGm(GMLangConstants.KAIYING) %>
									  		</c:when>
									  		<c:when test="${u.role eq 'developer'}">
									  			<%=lang.readGm(GMLangConstants.DEVELOPER) %>
									  		</c:when>
									  	</c:choose></td>
        <td>&nbsp;<fmt:formatDate value="${u.lastLogonDate}" pattern="yyyy-MM-dd HH:mm"/></td>
        <c:if test="${DBType eq 1}"><td>&nbsp;
            <c:choose>
               <c:when test="${lev < roleMap.get(u.role)}">
                   <img class="pointer" title="<%=lang.readGm(GMLangConstants.EDIT)%><%=lang.readGm(GMLangConstants.COMMON_PASSWORD)%>"  src="images/b_edit.png" onclick="javaScript:window.location='sysUser.do?action=editInitPassword&id=${u.id}'"/>&nbsp;
               	  <img class="pointer" title="<%=lang.readGm(GMLangConstants.EDIT)%><%=lang.readGm(GMLangConstants.RIGHT)%>"  src="images/b_browse.png" onclick="javaScript:window.location='sysUser.do?action=editInitSysUser&id=${u.id}'"/>&nbsp;
                  <img class="pointer" title="<%=lang.readGm(GMLangConstants.COMMON_DELETE)%>"  src="images/b_drop.png" onclick="javaScript:delSysUser('${u.id}');"/>
               </c:when>
               <c:when test="${id eq u.id && (sRole eq 'super_admin'||sRole eq 'admin')}">				   
					<img class="pointer" title="<%=lang.readGm(GMLangConstants.EDIT)%><%=lang.readGm(GMLangConstants.COMMON_PASSWORD)%>"  src="images/b_edit.png" onclick="javaScript:window.location='sysUser.do?action=editInitPassword&id=${u.id}'"/>&nbsp;              
               </c:when>
            </c:choose>
        </td></c:if>
      </tr>
 	</c:forEach>
  <tr>
    <td height="30" colspan="5" style="border-bottom: 0px;">
     <jsp:include page="../page.jsp"></jsp:include>
    </td>
  </tr>
</tbody></table>
</div>
</div>
</body>
</html>