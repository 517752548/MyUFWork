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
<title><%= lang.readGm(GMLangConstants.LZR_GM) %></title>
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
<div class="tab-row">
<h2 id='tab_1' onclick="switchTab(id)" class="selected tab">
<a href="#"><%=lang.readGm(GMLangConstants.PET)%>
<%=lang.readGm(GMLangConstants.C_BASIC_INFO)%></a></h2>
</div>
<div class="nofloat" />
<table name='tab_1' class="detail petBasicInfo no_bottom" cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
        <tr>
         <th colspan="10">&nbsp;<%=lang.readGm(GMLangConstants.C_BASIC_INFO)%></th>
        </tr>
		<tr>
		 <td class="label">&nbsp;<%=lang.readGm(GMLangConstants.PET_NAME)%></td>
         <td>&nbsp;${p.name}</td>
		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.PET_ID)%></td>
         <td style="width: 600px;">&nbsp;${p.id}</td>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.ROLE_ID)%></td>
         <td>&nbsp;${p.charId}</td>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.LEVEL)%></td>
         <td>&nbsp;${p.level}</td>
 		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.EXP)%></td>
         <td>&nbsp;${p.exp}</td>
		</tr>

		<tr>
		 <td class="label">&nbsp;<%=lang.readGm(GMLangConstants.ROLE_SEX)%></td>
         <td>&nbsp;
			<c:choose>
					<c:when test="${p.sex eq 1}">
						<%=lang.readGm(GMLangConstants.PET_SEX_XIONG)%>
					</c:when>
					<c:when test="${p.sex eq 2}">
						<%=lang.readGm(GMLangConstants.PET_SEX_CI)%>
					</c:when>
				</c:choose></td>
		</td>
		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.EXP)%></td>
         <td>&nbsp;${p.curHp}</td>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.HAPPY_DEGREE)%></td>
         <td>&nbsp;${p.happy}</td>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.PET_LIFE)%></td>
         <td>&nbsp;${p.life}</td>
 		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.COMMON_STATE)%></td>
         <td>&nbsp;<c:choose>
           <c:when test="${p.state eq 0}">
            <%=lang.readGm(GMLangConstants.PET_STATE_REST)%>
           </c:when>
           <c:when test="${p.state eq 1}">
            <%=lang.readGm(GMLangConstants.PET_STATE_BATTLE)%>
           </c:when>
         </c:choose>
         </td>
		</tr>

		<tr>
		 <td class="label">&nbsp;<%=lang.readGm(GMLangConstants.UNDERSTANDING)%></td>
         <td>&nbsp;${p.understanding}</td>
		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.ROOTBONE)%></td>
         <td>&nbsp;${p.rootBone}</td>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.SPIRIT)%></td>
         <td>&nbsp;${p.spirit}</td>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.PET)%><%=lang.readGm(GMLangConstants.CARDTYPE)%></td>
         <td>&nbsp;
         <c:forEach items="${dataMap['petType']}" var="_petType">
             	<c:if test="${_petType.key eq p.petType}"><c:out value="${language.readGm(_petType.value)}" /></c:if>
         </c:forEach>
         </td>
 		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.PET)%><%=lang.readGm(GMLangConstants.NATURE)%></td>
         <td>&nbsp;
          <c:forEach items="${dataMap['petNature']}" var="_petNature">
             	<c:if test="${_petNature.key eq p.nature}"><c:out value="${language.readGm(_petNature.value)}" /></c:if>
         </c:forEach>
         </td>
		</tr>

 		<tr>
		<td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.GROWING_POINT)%></td>
          <td>&nbsp;${p.growingPoint}</td>
		 <td class="label">&nbsp;<%=lang.readGm(GMLangConstants.GROWING_POINT)%><%=lang.readGm(GMLangConstants.SWITCH)%></td>
			<td>&nbsp;<c:choose>
					<c:when test="${p.growingPointSwitch eq 0}">
						<%=lang.readGm(GMLangConstants.NO)%>
					</c:when>
					<c:otherwise><%=lang.readGm(GMLangConstants.YES)%>
					</c:otherwise>
			</c:choose>
		</td>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.BREED_NUM)%></td>
         <td>&nbsp;${p.breedNum}</td>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.VARIATION_LEVEL)%></td>
         <td>&nbsp;${p.variationLevel}</td>
		</tr>





	</tbody>
</table>
<table name='tab_1' class="detail petBasicInfo no_bottom"  cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
        <tr>
         <th colspan="10">&nbsp;<%=lang.readGm(GMLangConstants.PROPERTY)%></th>
        </tr>
		<tr>
	         <td class="label">&nbsp;<%=lang.readGm(GMLangConstants.INTELLECT)%><%=lang.readGm(GMLangConstants.ADD_POINT)%></td>
	         <td>&nbsp;${p.addBodySpells}</td>
	         <td class="label">&nbsp;<%=lang.readGm(GMLangConstants.STRENGTH)%><%=lang.readGm(GMLangConstants.ADD_POINT)%></td>
	         <td>&nbsp;${p.addStrength}</td>
	         <td class="label">&nbsp;<%=lang.readGm(GMLangConstants.BELIEF)%><%=lang.readGm(GMLangConstants.ADD_POINT)%></td>
	         <td>&nbsp;${p.addAnchoringForce}</td>
              <td class="label">&nbsp;<%=lang.readGm(GMLangConstants.AGILITY)%><%=lang.readGm(GMLangConstants.ADD_POINT)%></td>
	         <td>&nbsp;${p.addNimbus}</td>
			 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.BODY_STRENGTH)%><%=lang.readGm(GMLangConstants.ADD_POINT)%></td>
	         <td>&nbsp;${p.addStamina}</td>
		</tr>
        <tr>
	         <td class="label">&nbsp;<%=lang.readGm(GMLangConstants.LEFTPOINT)%></td>
	         <td colspan="9">&nbsp;${p.leftPoint}</td>
        </tr>
	</tbody>
</table>
</div>
</body>
</html>