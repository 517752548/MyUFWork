<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/logCommon.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>mop</title>
<script type="text/javascript" charset="UTF-8">
   
  function goTo(i){
	  var openId = $("#openId").val();
	  var reason=$("#reason").val();
	  var date = $("#date").val();
	  var startTime=$("#startTime").val();
	  var endTime=$("#endTime").val();
	  window.location.href="cdkey.do?action=init&currentPage="+i+"&openId="+openId+"&reason="+reason+"&startTime="+startTime+"&endTime="+endTime+"&date="+date;	
  }
  function search(){
	  var cdkeyId = $("#cdkeyId").val();
	  var date = $("#date").val();
	  if(is_null(cdkeyId) && is_null(date)) {
		  alert("<%=lang.readGm(GMLangConstants.CDKEY_SEARCH_BY_ACT_NAME_OR_DATE_CAN_NOT_NULL)%>");
		  return;
	  }
	  window.location.href="cdkey.do?action=searchByActivityNameOrDate&cdkeyId="+cdkeyId+"&date="+date;	
  }
  function del(id){
	  var con= confirm("<%=lang.readGm(GMLangConstants.CONFRIM_DEL)%>?");
		if(con){
			var currentPage = $("#curPage").val();
			var date = $("#date").val();
			var startTime=$("#startTime").val();
			var endTime=$("#endTime").val();
			$.post("cdkey.do?action=delUserPrize",{id:id},function(){
		        alert("<%=lang.readGm(GMLangConstants.DEL_SUCCESS)%>");
		        window.location="cdkey.do?action=init&currentPage="+currentPage+"&startTime="+startTime+"&endTime="+endTime+"&date="+date;	
			  });	
		}
  }
  function selAll(but,name){
		var sel=$("#"+but+"").attr("checked");
		if(sel){
			$("#"+but+"").attr("checked",true);
			var checks=document.getElementsByName(name);
			for(var i=0;i<checks.length;i++){
				checks[i].checked=true;
			}
		}else{
			$("#"+but+"").attr("checked",false);
			var checks=document.getElementsByName(name);
			for(var i=0;i<checks.length;i++){
				checks[i].checked=false;
			}
		}		
	}
	function delChosen()
	{
		 var con= confirm("<%=lang.readGm(GMLangConstants.CONFRIM_DEL)%>?");
			if(con){
				var currentPage = $("#curPage").val();
				var date = $("#date").val();
				var startTime=$("#startTime").val();
				var endTime=$("#endTime").val();
				var ids = "";
				var checks=document.getElementsByName("prize");
				for(var i=0;i<checks.length;i++){
					if(checks[i].checked==false){
						continue;
					}else{
						ids += checks[i].value+"_";
					}
				}
				$.post("cdkey.do?action=delUserPrize",{ids:ids},function(){
			        alert("<%=lang.readGm(GMLangConstants.DEL_SUCCESS)%>");
			        window.location="cdkey.do?action=init&currentPage="+currentPage+"&startTime="+startTime+"&endTime="+endTime+"&date="+date;	
				});	
			}
	}
	
	function searchOpenId() {
		var openId = $("#openId").val();
		if(is_null(openId)) {
			alert("<%=lang.readGm(GMLangConstants.DEL_SUCCESS)%>");
			return;
		}
		window.location.href="cdkey.do?action=searchByOpenId&openId=" + openId;	
	}
</script>
</head>

<body>


<div id="man_zone">
	<div class="topnav">
		<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>><%=lang.readGm(GMLangConstants.CDKEY_SEARCH)%> 
	</div>
<div id="nav">
<!-- <ul> -->
<!-- 	<li id="man_nav_1" 	class="bg_image_onclick" > -->
<%-- 		<%=lang.readGm(GMLangConstants.USER_ID)%> --%>
<!--     </li> -->
<!-- </ul> -->
</div>
<div id="sub_info">&nbsp;&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_OPEN_ID)%>&nbsp;&nbsp;<input id="openId" type="text" class="limitWidth" value="${openId}"/>
<input id="search" type="button"  style="margin-left: 1em;" value="<%=lang.readGm(GMLangConstants.CDKEY_SEARCH_BY_OPENID)%>" onClick="javaScript:searchOpenId();"/>
<span><%=lang.readGm(GMLangConstants.CDKEY_ID)%>:<input id="cdkeyId" type="text" class="limitWidth" value="${plansId}"/>
</span>
<span><%=lang.readGm(GMLangConstants.CDKEY_CREATE_TIME)%>:<input id="date" type="text" class="limitWidth" value="${date}"/><img id="dateImg" src="jslib/jscalendar/img.gif" />
<script type="text/javascript" language="javascript" charset="UTF-8">Calendar.setup(
{inputField  : "date",         // ID of the input field
ifFormat    : "%Y-%m-%d %H:%M:%S",       // format of the input field
showsTime   : true,
timeFormat  : "24",
onClose  :  function (cal){
if(cal.date>new Date()){
alert("<%=lang.readGm(GMLangConstants.DATE_ERR)%>");
}
cal.hide();
},
button   : "dateImg"     // ID of the button
});</script></span>
<input id="search" type="button"  style="margin-left: 1em;" value="<%= lang.readGm(GMLangConstants.COMMON_SEARCH)%>" onClick="javaScript:search();"/>
<%-- <input id="deleteSelected" type="button"  style="margin-left: 1em;" value="<%= lang.readGm(GMLangConstants.DELETE_CHOSEN)%>" onClick="javaScript:delChosen();"/> --%>
</div>

<table class="detail"  cellspacing="0" cellpadding="0" border="0" >
	<tbody>
		<tr>
		<th>
			<span onclick="selAll('allCDKey','cdkey')" ><%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%>
				<input type="checkbox" id="allCDKey" />
			</span> 
		</th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_ID)%></th>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_PLANS_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_GIFT_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_GROUP_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_OPERATOR_GM_ID)%></th>
	     <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_TAKEN_STATE)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_CREATE_TIME)%></th>
	     <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_OPEN_ID)%></th>
	     <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_CHARID)%></th>
<%-- 		 <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_CHAR_NAME)%></th> --%>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_CHAR_SERVER_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_TAKEN_TIME)%></th>
<%-- 		 <c:if test="${DBType eq 1}"> --%>
<%--          	<th>&nbsp;<%=lang.readGm(GMLangConstants.COMMON_OPERATION)%> --%>
<%-- 			<img class="pointer" title="<%=lang.readGm(GMLangConstants.NEW_ADD)%>" src="images/add.gif" onclick="javaScript:window.location='cdkey.do?action=createView'"/>	 --%>
<!-- 		 	&nbsp; -->
<!-- 			</th> -->
<%-- 		</c:if> --%>
		</tr>
     <c:forEach items="${cdkeylist}" var="cdkeyVo">
        <tr>
		 <td>&nbsp;<input type="checkbox" name="cdkey" value="${cdkeyVo.cdkey}"></td>
		 <td>&nbsp;${cdkeyVo.cdkey}</td>
		 <td>&nbsp;${cdkeyVo.plansId}</td>
		 <td>&nbsp;${cdkeyVo.giftId}</td>
         <td>&nbsp;${cdkeyVo.groupId}</td>
         <td>&nbsp;${cdkeyVo.gmId}</td>
         <td>&nbsp;
			<c:choose>
				<c:when test="${cdkeyVo.state eq 0}">
					<%=lang.readGm(GMLangConstants.NO_GET)%>
				</c:when>
				<c:when test="${cdkeyVo.state eq 1}">
					<%=lang.readGm(GMLangConstants.GETED)%>
				</c:when>
			</c:choose>
         </td>
		 <td>&nbsp;<fmt:formatDate pattern="yyyy-MM-dd HH:mm" value="${cdkeyVo.createTime}" /></td>
 		 <td>&nbsp;${cdkeyVo.openId}</td>
 		 <td>&nbsp;${cdkeyVo.charId}</td>
<%--  		 <td>&nbsp;${cdkeyVo.charName}</td> --%>
 		 <td>&nbsp;${cdkeyVo.chartServerId}</td>
 		 <td>&nbsp;${cdkeyVo.takeTime}</td>
<!-- 		 <td> &nbsp; </td> -->
		</tr>
     </c:forEach>
     <tr>
    <td height="30" colspan="17" style="border-bottom: 0px;width: 100%;" align="right">
     <div id="num_style"></data></div>
    </td>
  </tr>
   </tbody>
</table>
</div>


</body>
</html>