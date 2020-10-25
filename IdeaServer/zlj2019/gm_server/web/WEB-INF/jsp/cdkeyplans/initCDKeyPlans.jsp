<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/logCommon.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

<script type="text/javascript" charset="UTF-8">
   
  function goTo(i){
	  var plansId = $("#plansId").val();
	  var date = $("#date").val();
	  var startTime=$("#startTime").val();
	  var endTime=$("#endTime").val();
	  window.location.href="cdkeyPlans.do?action=init&currentPage="+i+"&plansId="+plansId+"&startTime="+startTime+"&endTime="+endTime+"&date="+date;	
  }
  function search(){
	  var cdkeyPlansName = $("#cdkeyPlansName").val();
	  var date = $("#date").val();
	  if(is_null(cdkeyPlansName) && is_null(date)) {
		  alert("<%=lang.readGm(GMLangConstants.CDKEY_PLANS_SEARCH_BY_NAME_OR_DATE_CAN_NOT_NULL)%>");
		  return;
	  }
	  window.location.href="cdkeyPlans.do?action=searchByNameOrDate&cdkeyPlansName="+cdkeyPlansName+"&date="+date;	
  }
  function del(id){
	  var con= confirm("<%=lang.readGm(GMLangConstants.CONFRIM_DEL)%>?");
		if(con){
			var currentPage = $("#curPage").val();
			var date = $("#date").val();
			var startTime=$("#startTime").val();
			var endTime=$("#endTime").val();
			$.post("cdkeyPlans.do?action=delUserPrize",{id:id},function(){
		        alert("<%=lang.readGm(GMLangConstants.DEL_SUCCESS)%>");
		        window.location="cdkeyPlans.do?action=init&currentPage="+currentPage+"&startTime="+startTime+"&endTime="+endTime+"&date="+date;	
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
				$.post("cdkeyPlans.do?action=delUserPrize",{ids:ids},function(){
			        alert("<%=lang.readGm(GMLangConstants.DEL_SUCCESS)%>");
			        window.location="cdkeyPlans.do?action=init&currentPage="+currentPage+"&startTime="+startTime+"&endTime="+endTime+"&date="+date;	
				});	
			}
	}
	
	function searchPlansId() {
		var cdkeyPlansId = $("#cdkeyPlansId").val();
		if(is_null(cdkeyPlansId)) {
			alert("<%=lang.readGm(GMLangConstants.CDKEY_PLANS_ID_SEARCHE_NOT_NULL)%>");
			return;
		}
		window.location.href="cdkeyPlans.do?action=init&plansId=" + cdkeyPlansId;	
	}
</script>
</head>

<body>


<div id="man_zone">
	<div class="topnav">
		<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>><%=lang.readGm(GMLangConstants.CDKEY_PLANS)%>
	</div>
<div id="nav">
<!-- <ul> -->
<!-- 	<li id="man_nav_1" 	class="bg_image_onclick" > -->
<%-- 		<%=lang.readGm(GMLangConstants.USER_ID)%> --%>
<!--     </li> -->
<!-- </ul> -->
</div>
<div id="sub_info">&nbsp;&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_PLANS_ID)%>&nbsp;&nbsp;<input id="cdkeyPlansId" type="text" class="limitWidth" value="${cdkeyPlansId}"/>
<input id="search" type="button"  style="margin-left: 1em;" value="<%=lang.readGm(GMLangConstants.CDKEY_PLANS_ID_SEARCHE)%>" onClick="javaScript:searchPlansId();"/>
<span><%=lang.readGm(GMLangConstants.CDKEY_PLANS_NAME)%>:<input id="cdkeyPlansName" type="text" class="limitWidth" value="${cdkeyPlansName}"/>
</span>
<span><%=lang.readGm(GMLangConstants.CDKEY_CREATE_TIME)%>:<input id="date" type="text" class="limitWidth" value="${date}"/><img id="dateImg" src="jslib/jscalendar/img.gif" />
<script type="text/javascript" language="javascript" charset="UTF-8">Calendar.setup(
{inputField  : "date",         // ID of the input field
ifFormat    : "%Y-%m-%d",       // format of the input field
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
<!-- <input id="export" type="button" style="margin-left: 1em;" -->
<%-- 	value="<%=lang.readGm(GMLangConstants.EXPORT)%>" --%>
<%-- 	onClick="javaScript:window.location.href='cdkeyPlans.do?action=export&list='${cdkeylist}'" /> --%>
</div>

<table class="detail"  cellspacing="0" cellpadding="0" border="0" >
	<tbody>
		<tr>
		<th>
			<span onclick="selAll('allCDKey','cdkey')" ><%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%>
				<input type="checkbox" id="allCDKey" />
			</span> 
		</th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.ID)%></th>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_PLANS_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_PLANS_NAME)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_PLANS_START_TIME)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_PLANS_END_TIME)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_PLANS_CREATE_TIME)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_OPERATOR_GM_ID)%></th>
		 <c:if test="${DBType eq 1}">
         	<th>&nbsp;<%=lang.readGm(GMLangConstants.COMMON_OPERATION)%>
			<img class="pointer" title="<%=lang.readGm(GMLangConstants.NEW_ADD)%>" src="images/add.gif"
			 onclick="javaScript:window.location='cdkeyPlans.do?action=addInit'"/>	
		 	&nbsp;
			</th>
		</c:if>
		</tr>
     <c:forEach items="${plansList}" var="vo">
        <tr>
		 <td>&nbsp;<input type="checkbox" name="cdkey" value="${vo.id}"></td>
		 <td>&nbsp;${vo.id}</td>
         <td>&nbsp;${vo.cdkeyPlansId}</td>
		 <td>&nbsp;${vo.cdkeyPlansName}</td>
		 <td>&nbsp;<fmt:formatDate pattern="yyyy-MM-dd HH:mm" value="${vo.startTime}" /></td>
		 <td>&nbsp;<fmt:formatDate pattern="yyyy-MM-dd HH:mm" value="${vo.endTime}" /></td>
		 <td>&nbsp;<fmt:formatDate pattern="yyyy-MM-dd HH:mm" value="${vo.createTime}" /></td>
		 <td>&nbsp;${vo.gmId}</td>
		 <c:if test="${DBType eq 1}">
			 <td>&nbsp; </td>
<%-- 				<img class="pointer" title="<%=lang.readGm(GMLangConstants.COMMON_DELETE)%>"  --%>
<%-- 				src="images/b_drop.png" onclick="javaScript:del('${vo.id}');"/> --%>
	         
		 </c:if> 
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