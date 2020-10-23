<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ page import="com.imop.lj.db.model.HumanEntity"%>
<%
	HumanEntity charaInfo= (HumanEntity)request.getAttribute("c");
%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
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
<div id="nav">
<ul>
	<li id="man_nav_1"
		onclick="javaScript:window.location='role.do?action=petBasicInfo&roleId=${roleId}&petId=${p.id}';"
		class="bg_image_onclick" style="padding: 2px 35px 0px 30px;"><%=lang.readGm(GMLangConstants.C_BASIC_INFO)%></li>
	<!-- <li id="man_nav_2" style="padding: 2px 50px 0px 40px;"
		class="bg_image"><%=lang.readGm(GMLangConstants.BUFINFO)%></li> -->
</ul>
</div>
<div id="sub_info">&nbsp;&nbsp;<img src="images/hi.gif" />&nbsp;
<span id="show_text">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>
<a class="link" href="role.do?action=rolePet&id=${roleId}"><%=lang.readGm(GMLangConstants.ROLE)%><%=lang.readGm(GMLangConstants.PET)%></a>>>
<%=lang.readGm(GMLangConstants.PET)%>#${p.id}</span>
</div>
<div class="tab-row">
<h2 id='tab_1' onclick="switchTab(id)" class="selected tab">
<a href="#"><%=lang.readGm(GMLangConstants.PET)%>
<%=lang.readGm(GMLangConstants.C_BASIC_INFO)%></a></h2>
</div>
<div class="nofloat" />
<form action="pet.do?action=savePet">
<table name='tab_1' class="detail petBasicInfo no_bottom" cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
        <tr>
         <th colspan="10">&nbsp;<%=lang.readGm(GMLangConstants.C_BASIC_INFO)%></th>
        </tr>
		<tr>
		 <td class="label">&nbsp;<%=lang.readGm(GMLangConstants.PET_NAME)%></td>
         <td>&nbsp;<input name="petName" value="${p.name}"/></td>
		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.PET_ID)%></td>
         <td style="width: 600px;">&nbsp;${p.id}</td>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.ROLE_ID)%></td>
         <td>&nbsp;${roleId}</td>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.LEVEL)%></td>
         <td>&nbsp;<input name="petLevel" value="${p.level}"/></td>
 		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.EXP)%></td>
         <td>&nbsp;<input name="petExp" value="${p.exp}"/></td>
		</tr>
        <tr>
		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.EXP)%></td>
         <td>&nbsp;<input name="curHp" value="${p.curHp}"/></td>
		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.EXP)%></td>
         <td>&nbsp;<input name="curMp" value="${p.curMp}"/></td>
		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.CURRENT_LOYALTY)%></td>
         <td>&nbsp;<input name="currentLoyalty" value="${petPros.proJson.currentLoyalty}"/></td>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.CURRENT_COHESION)%></td>
         <td>&nbsp;<input name="currentCohesion" value="${petPros.proJson.currentCohesion}"/></td>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.CURRENT_ENERGY)%></td>
         <td>&nbsp;<input name="currentEnergy" value="${petPros.proJson.currentEnergy}"/></td>
		</tr>
		<tr>
		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.EVLOUTION_LEVEL)%></td>
         <td>&nbsp;<input name="evloutionLevel" value="${petPros.proJson.evloutionLevel}"/></td>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.CURRENT_EVLOUTION_EXP)%></td>
         <td>&nbsp;<input name="currentEvloutionExp" value="${petPros.proJson.currentEvloutionExp}"/></td>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.GROWING_POINT)%></td>
         <td>&nbsp;<input name="growingPoint" value="${petPros.proJson.growingPoint}"/></td>
		 <td class="label">&nbsp;<%=lang.readGm(GMLangConstants.LEFTPOINT)%></td>
	     <td >&nbsp;<input name="leftPoint" value="${p.leftPoint}"></td>
		 <td  class="label">&nbsp;</td>
         <td>&nbsp;</td>
		</tr>
	</tbody>
</table>
<table name='tab_1' class="detail petBasicInfo"  cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
        <tr>
         <th colspan="10">&nbsp;<%=lang.readGm(GMLangConstants.PROPERTY)%></th>
        </tr>
		<tr>
	         <td class="label">&nbsp;<%=lang.readGm(GMLangConstants.INTELLECT)%></td>
	         <td>&nbsp;<input name="addIntellect" value="${p.addIntellect}"/></td>
	         <td class="label">&nbsp;<%=lang.readGm(GMLangConstants.STRENGTH)%></td>
	         <td>&nbsp;<input name="addStrength" value="${p.addStrength}"/></td>
	         <td class="label">&nbsp;<%=lang.readGm(GMLangConstants.STAMINA)%></td>
	         <td>&nbsp;<input name="addStamina" value="${p.addStamina}"/></td>
              <td class="label">&nbsp;<%=lang.readGm(GMLangConstants.AGILITY)%></td>
	         <td>&nbsp;<input name="addAgility" value="${p.addAgility}"/></td>
			 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.BELIEF)%></td>
	         <td>&nbsp;<input name="addBelief" value="${p.addBelief}"/></td>
		</tr>
        <tr>
         <td colspan="10" class="bottom" >
			  <input id="submit" type="submit" value="<%= lang.readGm(GMLangConstants.COMMON_SUBMIT)%>" class="butcom" />
			  <span style="padding: 10px;"/><input id="reset" type="reset" value="<%= lang.readGm(GMLangConstants.RESET)%>" class="butcom" />
            <span
				style="padding: 10px;" /><input id="return" type="button" class="butcom"
				value="<%= lang.readGm(GMLangConstants.RETURN)%>"  onclick="javaScript:window.location='role.do?action=rolePet&id=${roleId}';"/>
			</td>
        </tr>
	</tbody>
</table>
</form>
</div>
</body>
</html>