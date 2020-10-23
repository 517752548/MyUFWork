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
<table name='tab_1' class="detail battleLogInfo no_bottom"  cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
        <tr>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.PROPERTY)%><%=lang.readGm(GMLangConstants.DESCRIBE)%></th>
        </tr>
		<tr>
	         <td class="label">&nbsp;${propInfo}</td>
		</tr>
	</tbody>
</table>
<table name='tab_1' class="detail battleLogInfo no_bottom"  cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
        <tr>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.WEARING)%></th>
        </tr>
		<tr>
	         <td class="label">&nbsp;
	         <table cellspacing="0" cellpadding="0"	border="0">
	<tbody>
		<tr>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.ITEM_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.TEMPLATENAME)%></th>
	     <th>&nbsp;<%=lang.readGm(GMLangConstants.BIND)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.ENDURE)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.EQUIP_STAR)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.C_PROPERTY)%></th>
		</tr>
     <c:forEach items="${items}" var="item">
        <tr>
          <td>&nbsp;${item.id}</td>
          <td>&nbsp;
	          <c:forEach items="${xlsData['items']}" var="m" >
	             <c:if test="${m.key eq item.templateId}"><c:out value="${m.value}" /></c:if>
	          </c:forEach>
	          (${item.templateId})
         </td>
 		 <td>&nbsp;
 		 <c:choose>
           <c:when test="${item.bind eq 0}">
            <%=lang.readGm(GMLangConstants.UNBIND)%>
           </c:when>
           <c:when test="${item.bind eq 1}">
            <%=lang.readGm(GMLangConstants.BIND)%>
           </c:when>
         </c:choose>
 		 </td>
         <td>&nbsp;
           ${item.curEndure}
         </td>
		 <td>&nbsp;${item.star}</td>
		 <td>&nbsp;${item.properties}</td>
		</tr>
     </c:forEach>
	</tbody>
</table>
	         </td>
		</tr>
	</tbody>
</table>
<table name='tab_1' class="detail battleLogInfo no_bottom"  cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
        <tr>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.PETINFO)%></th>
        </tr>
		<tr>
	         <td class="label">&nbsp;${petInfo}</td>
		</tr>
	</tbody>
</table>

</div>
</body>
</html>