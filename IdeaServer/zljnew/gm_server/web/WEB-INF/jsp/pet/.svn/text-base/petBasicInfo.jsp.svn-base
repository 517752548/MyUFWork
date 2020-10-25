<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title></title>
<script type="text/javascript">
$().ready(function(){
  $("table[name^='tab']").each(function(){
	  	  $(this).hide();
   });
  $("table[name^='tab_1']").each(function(){
	  	  $(this).show();
   });
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
}

</script>
</head>
<body>
<div id="man_zone">

	<div class="topnav">
		<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>&gt;&gt;
		<%= lang.readGm(GMLangConstants.GAME_LOG) %>&gt;&gt;  
		<a  href="role.do?action=init" class="link"><%=lang.readGm(GMLangConstants.ROLE_MANAGE)%></a>&gt;&gt;
		<%=lang.readGm(GMLangConstants.C_BASIC_INFO)%>
	</div>
	
<div id="nav">
<ul>
	<li id="man_nav_1"
		class="bg_image_onclick" style="padding: 2px 35px 0px 30px;"><%=lang.readGm(GMLangConstants.C_BASIC_INFO)%></li>
</ul>
</div>

		<div id="sub_info">
		</div>

<div class="nofloat" />

<table id='tab_1' class="detail petBasicInfo no_bottom" cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
        <tr>
         <th colspan="6" align="center">&nbsp;<%=lang.readGm(GMLangConstants.C_BASIC_INFO)%></th>
        </tr>
		<tr>
		 <td class="label">&nbsp;<%=lang.readGm(GMLangConstants.PET_NAME)%></td>
         <td>&nbsp;${p.name}</td>
         
		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.PET_ID)%></td>
         <td>&nbsp;${p.id}</td>
         
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.ROLE_ID)%></td>
         <td>&nbsp;${roleId}</td>
		</tr>
		
		<tr>
		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.LEVEL)%></td>
         <td>&nbsp;${p.level}</td>
         
 		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.EXP)%></td>
         <td>&nbsp;${p.exp}</td>
         
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.COMMANDER)%></td>
         <td>&nbsp;</td>
		</tr>
		
		<tr>
			<td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.SOLDIER_AMOUNT)%></td>
         	<td>&nbsp;${p.soldierAmount}</td>
         	<td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.SOLDIER_ID)%></td>
         	<td>&nbsp;${p.soldierId}</td>
		</tr>
	</tbody>
</table>
</div>
</div>
</body>
</html>
