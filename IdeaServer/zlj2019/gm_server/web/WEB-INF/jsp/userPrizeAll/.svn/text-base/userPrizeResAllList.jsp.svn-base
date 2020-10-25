<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/logCommon.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>mop</title>
<script type="text/javascript">
   $().ready(function(){
	   if("${reason}"==""){
		   $("#option-1").attr("selected","selected");
	   }else{
		   $("#option${reason}").attr("selected","selected");
	   }
	   var exist="${fail}";
	   if(exist=="false"){
		   window.location='userPrizeAll.do?action=init';
	   }
   });
  function goTo(i){
	  var passportId = $("#passportId").val();
	  var reason=$("#reason").val();
	  window.location.href="userPrizeAll.do?action=init&currentPage="+i+"&passportId="+passportId+"&reason="+reason;	
  }
  function search(){
	  var passportId = $("#passportId").val();
	  var reason=$("#reason").val();
	  window.location.href="userPrizeAll.do?action=init&passportId="+passportId+"&reason="+reason;
  }
  function del(id){
	  var con= confirm("<%=lang.readGm(GMLangConstants.CONFRIM_DEL)%>?");
		if(con){
			$.post("userPrizeAll.do?action=delUserPrize",{id:id},function(){
		        alert("<%=lang.readGm(GMLangConstants.DEL_SUCCESS)%>");
		        window.location='userPrizeAll.do?action=init';
			  });	

		}
  }
</script>
</head>
<body>
<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>  
<a class="link" href="userPrizeAll.do?action=init"><%=lang.readGm(GMLangConstants.GM_USER_PRIZE)%></a>>><%=lang.readGm(GMLangConstants.COMPARE_RESULT)%></div>
<div class="nofloat" />
<table name='tab_1' class="detail"  cellspacing="0" cellpadding="0" style="border-bottom: 0px;"
	border="0" >
	<tbody>
		<tr>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.RESULT)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.SERVER_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.USER_PRIZE_NAME)%></th>
 		 <th>&nbsp;<%=lang.readGm(GMLangConstants.USER)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.PRIZE_TYPE)%></th>
	     <th>&nbsp;<%=lang.readGm(GMLangConstants.C_MONEY)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.ITEM)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.ADD_PRIZE_ITEM_PARAMS)%></th>
		</tr>
     <c:forEach items="${resList}" var="userPrize">
        <tr>
		 <td>&nbsp;${userPrize.result}</td>
         <td>&nbsp;${userPrize.dbId}</td>
		 <td>&nbsp;${userPrize.userPrizeName}</td>
         <td>&nbsp;${userPrize.userIdAndName}</td>
 		 <td>&nbsp;
 		 	<c:forEach items="${dataMap['rolePrizeAllServerReason']}" var="rolePrizeReason" >
             		<c:if test="${rolePrizeReason.key eq userPrize.type}"><c:out value="${language.readGm(rolePrizeReason.value)}" /></c:if>
         	</c:forEach>
		 </td>
		 <td>&nbsp;${userPrize.coin}</td>
         <td>&nbsp;${userPrize.item}</td>
         <td>&nbsp;${userPrize.itemParams}</td>
		</tr>
     </c:forEach>
   </tbody>
</table>
</body>
</html>