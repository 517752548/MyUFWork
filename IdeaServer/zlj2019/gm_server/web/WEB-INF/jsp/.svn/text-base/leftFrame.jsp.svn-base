<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
</head>
<script  type="text/javascript">
$(document).ready(function(){
	
});
function selectMenu(id,url){
	window.top.frames.manFrame.location.href=url;
	$("a[name^=menu]").each(function(){
		$(this).removeClass("selected");
		});
	$("#menu_"+id).addClass("selected");
}

</script>
<body  margin='0' padding='0'>
<table  class="sbmenu" cellpadding="0" cellspacing="0" >
<c:forEach items="${menuList}" var="menu" varStatus="c">
 <c:choose><c:when test="${menu.pid eq '0'}">
<tr id="sub_sort_${menu.id}"  hideFlag="false" onclick="switchMenu($(this),${menu.id});">
 <td id="menu_${menu.id}" class="list_tilte" name="menu"><span>${menu.name}</span>
</td></tr>
</c:when>
<c:otherwise>
<tr name="sub_detail_${menu.pid}" >
<td class="list_detail"><div ><a id="menu_${menu.id}" name="menu" href="javascript:void(0)" onclick="javascript:selectMenu('${menu.id}','${menu.url}');">${menu.name}</a>
</div></td></tr>
</c:otherwise></c:choose></c:forEach>
</table>

<script type="text/javascript">
function switchMenu(obj,id){
	  var  flag= $(obj).attr("hideFlag");
	  $("tr[name='sub_detail_"+id+"']").each(function(){
		  if(flag=="false"){
			  $(this).hide();
		  }else{
			  $(this).show();
		 }
	  });
	  if(flag=="false"){
		  $(obj).attr("hideFlag","true");
		  $("#img_"+id).attr("src","images/expandh.gif")
	  }else{
		  $(obj).attr("hideFlag","false");
		  $("#img_"+id).attr("src","images/collapseh.gif")
	 }
}

var winHeight= window.screen.height;
var w=window.top.frames.manFrame;
$("#left_content").css({
	height:winHeight*0.7
});
</script>

</body>
</html>