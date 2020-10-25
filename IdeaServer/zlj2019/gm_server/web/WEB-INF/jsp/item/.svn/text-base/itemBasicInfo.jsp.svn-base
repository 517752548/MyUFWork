<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title></title>
</head>
<script type="text/javascript">
	
</script>
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
         <th colspan="10" align="center">&nbsp;<%=lang.readGm(GMLangConstants.C_BASIC_INFO)%></th>
        </tr>
		<tr>
		 <td class="label">&nbsp;<%=lang.readGm(GMLangConstants.ITEM_ID)%></td>
         <td>&nbsp;${item.id}</td>
         
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.ITEM_NAME)%></td>
         <td>&nbsp;
	          <c:forEach items="${xlsData['items']}" var="m" >
	             <c:if test="${m.key eq item.templateId}"><c:out value="${m.value}" /></c:if>
	          </c:forEach></td>
	     		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.NUM)%></td>
         <td>&nbsp;${item.overlap}</td>
		</tr>
		
		<tr>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.WEAR_ID)%></td>
         <td>&nbsp;
         	${item.wearerId}
         </td>
         
 		 <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.ITEM_TEMPLATE_ID)%></td>
         <td>&nbsp;${item.templateId}</td>
         
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.ROLE_ID)%></td>
         <td>&nbsp;${item.charId}</td>
		</tr>
		
		<tr>
          <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.POSITION)%></td>
         <td>&nbsp; <c:forEach items="${dataMap['bagType']}" var="bag" >
             	<c:if test="${bag.key eq item.bagId}"><c:out value="${language.readGm(bag.value)}" /></c:if>
         </c:forEach></td>
         <td  class="label">&nbsp;<%=lang.readGm(GMLangConstants.EQUIP_ENHANCE)%></td>
         <td>&nbsp;${enhanceLevel}</td>
		</tr>

	</tbody>
</table>
</div>
</div>
</body>
</html>