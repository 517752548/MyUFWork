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
	  window.location.href="prize.do?action=init&currentPage="+i+"&id="+id+"&reason="+reason;	
  }
  function search(){
	  var id = $("#id").val();
	  var reason=$("#reason").val();
	  window.location.href="prize.do?action=init&id="+id+"&reason="+reason;
  }
  function del(id){
	  var con= confirm("<%=lang.readGm(GMLangConstants.CONFRIM_DEL)%>?");
		if(con){
			$.post("prize.do?action=delPrize",{id:id},function(info){
				if($.trim(info)=="true"){
					alert("<%=lang.readGm(GMLangConstants.DEL_SUCCESS)%>");
			        window.location='prize.do?action=init';
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
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>  
<%=lang.readGm(GMLangConstants.PRIZE)%></div>
<div id="nav">
<ul>
	<li id="man_nav_1" 	class="bg_image_onclick" >
		<%=lang.readGm(GMLangConstants.PRIZE_ID)%>
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
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.ID)%></th>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.PRIZE_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.PRIZE_NAME)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.C_MONEY)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.ITEM)%></th>
 		 <th>&nbsp;<%=lang.readGm(GMLangConstants.PET)%></th>
	     <th>&nbsp;<%=lang.readGm(GMLangConstants.CREATE_TIME)%></th>
		 <c:if test="${DBType eq 1}">
	        <th>&nbsp;<%=lang.readGm(GMLangConstants.COMMON_OPERATION)%>
				<img  class="pointer" title="<%=lang.readGm(GMLangConstants.NEW_ADD)%>" src="images/add.gif" onclick="javaScript:window.location='prize.do?action=addPrizeInit'"/>	
			</th>
		 </c:if>
		</tr>
     <c:forEach items="${prizeList}" var="prizeVo">
        <tr>
		 <td>&nbsp;${prizeVo.prize.id}</td>
		 <td>&nbsp;${prizeVo.prize.prizeId}</td>
		 <td>&nbsp;${prizeVo.prize.prizeName}</td>
         <td>&nbsp;${prizeVo.formatCoin}</td>
         <td>&nbsp;${prizeVo.formatItem}</td>
		 <td>&nbsp;${prizeVo.formatPet}</td>
		 <td>&nbsp;<fmt:formatDate pattern="yyyy-MM-dd HH:mm" value="${prizeVo.prize.createTime}" /></td>
		 <c:if test="${DBType eq 1}">
		  <td> 
			<img class="pointer" title="<%=lang.readGm(GMLangConstants.COMMON_DELETE)%>"  src="images/b_drop.png" onclick="javaScript:del('${prizeVo.prize.id}');"/>
          </td>
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