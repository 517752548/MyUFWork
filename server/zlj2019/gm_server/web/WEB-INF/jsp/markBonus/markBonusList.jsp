<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/logCommon.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>mop</title>
<script type="text/javascript">

  function goTo(i){
	  var id = $("#id").val();
	  var reason=$("#reason").val();
	  window.location.href="markBonus.do?action=init&currentPage="+i+"&id="+id+"&reason="+reason;	
  }
  function search(){
	  var id = $("#id").val();
	  var reason=$("#reason").val();
	  window.location.href="markBonus.do?action=init&id="+id+"&reason="+reason;
  }
  function del(id){
	  var con= confirm("<%=lang.readGm(GMLangConstants.CONFRIM_DEL)%>?");
		if(con){
			$.post("markBonus.do?action=delMarkBonus",{id:id},function(){
		        alert("<%=lang.readGm(GMLangConstants.DEL_SUCCESS)%>");
		        window.location='markBonus.do?action=init';
			  });	

		}
  }
</script>
</head>
<body>
<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>  
<%=lang.readGm(GMLangConstants.MARK_BONUS)%></div>
<div id="nav">
<ul>
	<li id="man_nav_1" 	class="bg_image_onclick" >
		<%=lang.readGm(GMLangConstants.USER_ID)%>
    </li>
</ul>
</div>
<div id="sub_info">&nbsp;&nbsp;<input id="id" type="text" class="limitWidth"  value="${id}"/>
<input id="search" type="button"  style="margin-left: 1em;" value="<%= lang.readGm(GMLangConstants.COMMON_SEARCH)%>" onClick="javaScript:search();"/>
</div>
<div class="nofloat" />
<table name='tab_1' class="detail"  cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
		<tr>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.USER_ID)%></th>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.GOLDEN_BONUS)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.SILVER_BONUS)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.UPDATE_TIME)%></th>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.COMMON_OPERATION)%>
			<img  class="pointer" title="<%=lang.readGm(GMLangConstants.NEW_ADD)%>" src="images/add.gif" onclick="javaScript:window.location='markBonus.do?action=addMarkBonusInit'"/>	
		</th>
		</tr>
     <c:forEach items="${markBonusList}" var="markBonus">
        <tr>
		 <td>&nbsp;<%=lang.readGm(GMLangConstants.USER_ID)%>${markBonus.passportId}</td>
		 <td>&nbsp;<%=lang.readGm(GMLangConstants.GOLDEN_BONUS)%>ID:${markBonus.goldenBonusId} ${markBonus.goldenPassDays} <%=lang.readGm(GMLangConstants.DAY_IS_VALID)%></td>
         <td>&nbsp;<%=lang.readGm(GMLangConstants.SILVER_BONUS)%>ID:${markBonus.silverBonusId} ${markBonus.silverPassDays} <%=lang.readGm(GMLangConstants.DAY_IS_VALID)%></td>
		 <td>&nbsp;<fmt:formatDate pattern="yyyy-MM-dd HH:mm" value="${markBonus.updateTime}" /></td>
		 <td> 
			<img class="pointer" title="<%=lang.readGm(GMLangConstants.COMMON_DELETE)%>"  src="images/b_drop.png" onclick="javaScript:del('${markBonus.id}');"/>
         </td>
		</tr>
     </c:forEach>
     <tr>
    <td height="30" colspan="13" style="border-bottom: 0px;width: 100%;">
     <div id="num_style"></data></div>
    </td>
  </tr>
   </tbody>
</table>
</body>
</html>