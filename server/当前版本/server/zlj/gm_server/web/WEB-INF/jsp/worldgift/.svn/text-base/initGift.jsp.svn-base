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
	  window.location.href="worldGift.do?action=init&currentPage="+i+"&id="+id;	
  }
  function search(){
	  var giftId = $("#id").val();
	  window.location.href="worldGift.do?action=init&giftId="+giftId;
  }
  function del(id){
	  var con= confirm("<%=lang.readGm(GMLangConstants.CONFRIM_DEL)%>?");
		if(con){
// 			$.post("worldGift.do?action=delPrize",{id:id},function(info){
// 				if($.trim(info)=="true"){
<%-- 					alert("<%=lang.readGm(GMLangConstants.DEL_SUCCESS)%>"); --%>
// 			        window.location='worldGift.do?action=init';
// 				}else{
<%-- 					alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>"); --%>
// 				}
		        
// 			  });	

		}
  }
</script>
</head>
<body>
<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>  
<%=lang.readGm(GMLangConstants.WORLD_GIFT)%>
</div>
<c:choose>
<c:when test="${error_msg ne null}">
<span id="error_msg" class="error_msg">${error_msg}</span>
</c:when>
</c:choose>
<br/>
<div id="nav">
<ul>
	<li id="man_nav_1" 	class="bg_image_onclick" >
		<%=lang.readGm(GMLangConstants.WORLD_GIFT_ID)%>
    </li>
</ul>
</div>
<div id="sub_info">&nbsp;&nbsp;<input id="id" type="text" class="limitWidth"  value="${id}"/>
<input id="search" type="button"  style="margin-left: 1em;" value="<%= lang.readGm(GMLangConstants.COMMON_SEARCH)%>" onClick="javaScript:search();"/>
</div>
<div class="nofloat" />
<table name='tab_1' class="detail"  cellspacing="0" cellpadding="0"	border="0" >
	<tbody>
		<tr>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.ID)%></th>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.WORLD_GIFT_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.WORLD_GIFT_NAME)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.WORLD_GIFT_PARAMS)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.WORLD_GIFT_CREATE_TIME)%></th>
		 <c:if test="${DBType eq 1}">
	        <th>&nbsp;<%=lang.readGm(GMLangConstants.COMMON_OPERATION)%>
				<img  class="pointer" title="<%=lang.readGm(GMLangConstants.NEW_ADD)%>" src="images/add.gif" onclick="javaScript:window.location='worldGift.do?action=addInit'"/>	
			</th>
		 </c:if>
		</tr>
     <c:forEach items="${giftList}" var="giftVo">
        <tr>
		 <td>&nbsp;${giftVo.id}</td>
		 <td>&nbsp;${giftVo.giftId}</td>
		 <td>&nbsp;${giftVo.giftName}</td>
         <td>&nbsp;${giftVo.giftParams}</td>
		 <td>&nbsp;<fmt:formatDate pattern="yyyy-MM-dd HH:mm" value="${giftVo.createTime}" /></td>
		 <c:if test="${DBType eq 1}">
		  <td>&nbsp; </td>
<%-- 			<img class="pointer" title="<%=lang.readGm(GMLangConstants.COMMON_DELETE)%>"  src="images/b_drop.png" onclick="javaScript:del('${prizeVo.prize.id}');"/> --%>
          
         </c:if>
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