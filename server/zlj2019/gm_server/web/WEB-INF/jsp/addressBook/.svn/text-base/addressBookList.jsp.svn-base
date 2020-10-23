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
  if(type=="roleId"){
	$("#searchType").val("roleId");
	$("#man_nav_1").attr("class","bg_image_onclick");
    $("#man_nav_2").attr("class","bg_image");
   }
  if(type=="roleName"){
		$("#searchType").val("roleName");
		$("#man_nav_1").attr("class","bg_image");
		$("#man_nav_2").attr("class","bg_image_onclick");
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
		   $("#searchType").val("roleName");
		   break;
	}
}
function search(){
	var searchType=$("#searchType").val();
	var searchValue=$("#searchValue").val();
	var startDate=$("#startDate").val();
	var endDate=$("#endDate").val();
	window.location.href="addressBook.do?action=init&searchType="+searchType+"&searchValue="+searchValue+"&startDate="+startDate+"&endDate="+endDate;
}
function goTo(i){
	var searchType=$("#searchType").val();
    var searchValue=$("#searchValue").val();
	var startDate=$("#startDate").val();
	var endDate=$("#endDate").val();
    var url=window.location.toString().split("&");
	window.location.href=url[0]+'&currentPage='+i+"&searchType="+searchType+"&searchValue="+searchValue+"&startDate="+startDate+"&endDate="+endDate;
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
		$.post("addressBook.do?action=kickOut",{"id":"'"+id+"'"},function(info){
			var info = $.trim(info);
			if(info=="ok"){
              alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
              window.location="addressBook.do?action=init";
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
<%= lang.readGm(GMLangConstants.GAME_WORLD_MANAGE) %>&gt;&gt;
<%= lang.readGm(GMLangConstants.ADDRESS_BOOK_MANAGE) %>
</div>
<div id="nav">
<ul>
	<li id="man_nav_1"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.ROLE_ID)%>')"
		class="bg_image"><%=lang.readGm(GMLangConstants.ROLE_ID)%></li>
	<li id="man_nav_2"
		onclick="list_sub_nav(id,'<%=lang.readGm(GMLangConstants.ROLE_NAME)%>')"
		class="bg_image"><%=lang.readGm(GMLangConstants.ROLE_NAME)%></li>   
</ul>
</div>
<div id="sub_info">
<span id="show_text">
	<input	id='searchValue' type='text' value="${searchValue}" />&nbsp;&nbsp;
	
	<span><%=lang.readGm(GMLangConstants.START_DATE)%>：
				<input id="startDate" type="text" class="limitWidth" value="${startDate}" /> 
				<img id="dateImg1" src="jslib/jscalendar/img.gif" />
				<script
				type="text/javascript" language="javascript">
					Calendar.setup(
						    {
						      inputField  : "startDate",         // ID of the input field
						      ifFormat    :  "%Y-%m-%d",       // format of the input field
						      showsTime   :  false,
						      timeFormat  :  "24",
						      onClose  :  function (cal){
							              if(cal.date>new Date()){
							            	  alert("<%=lang.readGm(GMLangConstants.DATE_ERR)%>");
								             }
						    	          cal.hide();
					                     },
						      button   : "dateImg1"     // ID of the button
						    }
					    );
				</script>
	</span>&nbsp;&nbsp;
	<span><%=lang.readGm(GMLangConstants.END_DATE)%>：
				<input id="endDate" type="text" class="limitWidth" value="${endDate}" /> 
				<img id="dateImg2" src="jslib/jscalendar/img.gif" />
				<script
				type="text/javascript" language="javascript">
					Calendar.setup(
						    {
						      inputField  : "endDate",         // ID of the input field
						      ifFormat    :  "%Y-%m-%d",       // format of the input field
						      showsTime   :  false,
						      timeFormat  :  "24",
						      onClose  :  function (cal){
							              if(cal.date>new Date()){
							            	  alert("<%=lang.readGm(GMLangConstants.DATE_ERR)%>");
								             }
						    	          cal.hide();
					                     },
						      button   : "dateImg2"     // ID of the button
						    }
					    );
				</script>
	</span>&nbsp;&nbsp;
</span>&nbsp;&nbsp;
<input id="searchType" type="hidden" value="roleName"/> 
<input id="search" type="button" class="butcom" style="margin-left: 1em;" 	value="<%=lang.readGm(GMLangConstants.COMMON_SEARCH)%>"
	onClick="javaScript:search();" />&nbsp;&nbsp;
</div>

<div class="nofloat" />
<table class="detail"  cellspacing="0" cellpadding="0" border="0">
  <tbody><tr>
	<!-- <th style="padding-left: 0px;">
	<input id="selectAll" type="checkbox" />
	</th> -->
    <th>&nbsp;<%= lang.readGm(GMLangConstants.ROLE_ID)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.ROLE_NAME)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.ADDRESS_BOOK_QQ)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.ADDRESS_BOOK_MOBILE)%></th>	
 	
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.CREATE_TIME)%></th>
    <th>&nbsp;<%= lang.readGm(GMLangConstants.UPDATE_TIME)%></th>
 	<th>&nbsp;<%= lang.readGm(GMLangConstants.DELETE_TIME)%></th>

  </tr>
  <c:forEach items="${addressBookList}" var="addressBook">
      <tr>
      	
        <td><a href="role.do?action=init&searchType=roleId&searchValue=${addressBook.id}" class="link">&nbsp;${addressBook.id} </a></td>
        <td>&nbsp;${addressBook.name}</td>  
        <td>&nbsp;${addressBook.qq}</td>
        <td>&nbsp;${addressBook.mobileNbr}</td>
        <td>&nbsp;<fmt:formatDate value="${addressBook.createTime}" pattern="yyyy-MM-dd HH:mm:ss"/></td>
        <td>&nbsp;<fmt:formatDate value="${addressBook.updateTime}" pattern="yyyy-MM-dd HH:mm:ss"/></td>
        <td>&nbsp;<fmt:formatDate value="${addressBook.deleteTime}" pattern="yyyy-MM-dd HH:mm:ss"/></td>
          
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