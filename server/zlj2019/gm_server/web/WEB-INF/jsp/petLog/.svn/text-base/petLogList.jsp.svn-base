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
	   if("${order}"=="asc"){
		   $("#sortImg").attr("src","images/nav_up.gif");
		   $("#timeSort").attr("title","<%=lang.readGm(GMLangConstants.DESC)%>");
	   }	
   });
  function goTo(i){
	  var sort = $("#sortImg").attr("src");
	  var sortType="log_time";
	  var order="asc";
	  if(sort.indexOf("nav_down.gif")!=-1){
		  sortType="log_time";
		  order="desc";
	  }
	  var roleID = $("#roleID").val();
	  var date = $("#date").val();
	  var reason=$("#reason").val();
	  var templeteID = $("#templeteID").val();
	  var startTime=$("#startTime").val();
	  var endTime=$("#endTime").val();
	  window.location.href="petLog.do?action=init&currentPage="+i+"&roleID="+roleID+"&date="+date+"&reason="+reason+"&templeteID="+templeteID+"&sortType="+sortType+"&order="+order+"&startTime="+startTime+"&endTime="+endTime;
   }
  
  function search(){
	  var sort = $("#sortImg").attr("src");
	  var sortType="log_time";
	  var order="asc";
	  if(sort.indexOf("nav_down.gif")!=-1){
		  sortType="log_time";
		  order="desc";
	  }
	  var roleID = $("#roleID").val();
	  var date = $("#date").val();
	  var reason=$("#reason").val();
	  var templeteID = $("#templeteID").val();
	  var startTime=$("#startTime").val();
	  var endTime=$("#endTime").val();
	  window.location.href="petLog.do?action=init&roleID="+roleID+"&date="+date+"&reason="+reason+"&templeteID="+templeteID+"&sortType="+sortType+"&order="+order+"&startTime="+startTime+"&endTime="+endTime;
	}
</script>
</head>
<body>
<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>  
<%=lang.readGm(GMLangConstants.PET)%><%=lang.readGm(GMLangConstants.LOG)%></div>
<div id="nav">
<ul>
	<li id="man_nav_1" 	class="bg_image_onclick" >
		<%=lang.readGm(GMLangConstants.ROLE_ID)%>
  </li>
</ul>
</div>
<div id="sub_info">&nbsp;&nbsp;<input id="roleID" type="text" class="limitWidth"  value="${roleID}"/>
<span><%=lang.readGm(GMLangConstants.DATE)%>:
<input id="date" type="text" class="limitWidth" value="${date}"/>
<img id="dateImg" src="jslib/jscalendar/img.gif" />
<script type="text/javascript" language="javascript">
Calendar.setup(
	    {
	      inputField  : "date",         // ID of the input field
	      ifFormat    :  "%Y-%m-%d",       // format of the input field
	      showsTime   :  false,
	      timeFormat  :  "24",
	      onClose  :  function (cal){
		              if(cal.date>new Date()){
		            	  alert("<%=lang.readGm(GMLangConstants.DATE_ERR)%>");
			             }
	    	          cal.hide();
                     },
	      button   : "dateImg"     // ID of the button
	    }
    );

</script>
</span>
<span><%=lang.readGm(GMLangConstants.REASON)%>:
<select id="reason">
<option id="option-1"  value="-1"><%= lang.readGm(GMLangConstants.REASON_ALL)%></option>
<c:forEach items="${logReasons}" var="logType" varStatus="count" begin="0">
	   <option id="option${logType.key}"  value="${logType.key}">${logType.value}</option>
	</c:forEach>
</select>
<span><%=lang.readGm(GMLangConstants.PET)%><%=lang.readGm(GMLangConstants.TEMPLATE_ID)%>:
<input id="templeteID" type="text" class="limitWidth" value="${templeteID}"/></span>
<span><%=lang.readGm(GMLangConstants.START_TIME)%>: 
<input id="startTime" name="startTime" value="${startTime}" class="time_gap"/>
<img id="startTimeImg" src="jslib/jscalendar/img.gif" />
<script type="text/javascript" language="javascript">
$('#startTimeImg').timepicker({
    defaultTime: new Date()
});
</script>
<%=lang.readGm(GMLangConstants.END_TIME)%>: <input id="endTime" name="endTime" value="${endTime}" class="time_gap"/>
<img id="endTimeImg" src="jslib/jscalendar/img.gif" />
<script type="text/javascript" language="javascript">
$('#endTimeImg').timepicker({
    defaultTime: new Date()
});
</script>
</span>
<input id="search" type="button"  style="margin-left: 1em;" value="<%= lang.readGm(GMLangConstants.COMMON_SEARCH)%>" onClick="javaScript:search();"/>
<input id="export" type="button" style="margin-left: 1em;"
	value="<%=lang.readGm(GMLangConstants.EXPORT)%>"
	onClick="javaScript:window.location.href='export.do?action=export&logType=pet_log'" />
</div>
<div class="nofloat" />
<table name='tab_1' class="detail"   cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
		<tr>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.LOG)%><%=lang.readGm(GMLangConstants.ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.LOG)%><%=lang.readGm(GMLangConstants.CARDTYPE)%></th>
		 <th>&nbsp;<a id="timeSort"  class="link pointer" onclick="javaScript:sort();" title="<%=lang.readGm(GMLangConstants.ASC)%>"><%=lang.readGm(GMLangConstants.TIME)%><img id="sortImg"  src="images/nav_down.gif" /></a></th>
 		 <th>&nbsp;<%=lang.readGm(GMLangConstants.REGION_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.SERVER_ID)%></th>
	     <th>&nbsp;<%=lang.readGm(GMLangConstants.USER_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.USER_NAME)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.ROLE_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.ROLE_NAME)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.LEVEL)%></th>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.MAP)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.MAP_X)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.MAP_Y)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.PET)%><%=lang.readGm(GMLangConstants.TEMPLATENAME)%></th>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.PET_ID)%></th>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.ALTER)%><%=lang.readGm(GMLangConstants.REASON)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.ADDTION)%><%=lang.readGm(GMLangConstants.PARAM)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.COMMON_OPERATION)%></th>
		</tr>
     <c:forEach items="${petLogList}" var="petLog">
        <tr>
		 <td>&nbsp;${petLog.id}</td>
         <td>&nbsp;
         <c:forEach items="${logTypes}" var="logType" >
             	<c:if test="${logType.key eq petLog.logType}"><c:out value="${logType.value}" /></c:if>
         </c:forEach>
         </td>
         <td>&nbsp;${petLog.formtLogTime}</td>
		 <td>&nbsp;${petLog.regionId}</td>
         <td>&nbsp;${petLog.serverId}</td>
 		 <td>&nbsp;<a href="user.do?action=init&searchType=userId&searchValue=${petLog.accountId}"
					class="link">${petLog.accountId}</a></td>
		 <td>&nbsp;${petLog.accountName}</td>
         <td>&nbsp;<a href="role.do?action=init&searchType=roleId&searchValue=${petLog.charId}"
					class="link">${petLog.charId}</a></td>
		 <td>&nbsp;${petLog.charName}</td>
         <td>&nbsp;${petLog.level}</td>
		 <td>&nbsp; 
		 <c:forEach items="${xlsData['maps']}" var="map" >
             <c:if test="${map.key eq petLog.mapId}"><c:out value="${map.value}" /></c:if>
         </c:forEach>
		 <td>&nbsp;${petLog.mapX}</td>
         <td>&nbsp;${petLog.mapY}</td>
		 <td>&nbsp;<c:forEach items="${xlsData['pets']}" var="it" >
             <c:if test="${it.key eq petLog.petTmplId}"><c:out value="${it.value}" /></c:if>
         </c:forEach>(${petLog.petTmplId})</td>
          <td>&nbsp;${petLog.petId}</td>
         <td>&nbsp;
          <c:forEach items="${logReasons}" var="petLogReason" >
             <c:if test="${petLogReason.key eq petLog.reason}"><c:out value="${petLogReason.value}" /></c:if>
         </c:forEach>
         </td>
         <td>&nbsp;${petLog.param}</td>
         <td>&nbsp; 
          <c:if test="${petLog.petData ne NULL}">
           <img onclick="javascript:window.location='petLog.do?action=petRecoverInit&id=${petLog.id}&accountId=${petLog.accountId}&date=${date}'" border="0" title="恢复" src="images/s_okay.png"/>
           <input type="button" onclick="javascript:window.open('petLog.do?action=petInfo&id=${petLog.id}&date=${date}','newwindow','height=400,top=0,left=0,toolbar=no,menubar=no,scrollbars=yes,resizable=no,location=no,status=no');" value="<%= lang.readGm(GMLangConstants.VIEW)%>"/>
          </c:if> 
         </td>
		</tr>
     </c:forEach>
     <tr>
    <td height="30" colspan="18" style="border-bottom: 0px;width: 100%;">
     <div id="num_style"></data></div>
    </td>
  </tr>
   </tbody>
</table>
</body>
</html>