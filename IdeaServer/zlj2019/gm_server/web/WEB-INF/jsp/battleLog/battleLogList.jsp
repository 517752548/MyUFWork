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
	  var startTime=$("#startTime").val();
	  var endTime=$("#endTime").val();
	  window.location.href="battleLog.do?action=init&currentPage="+i+"&roleID="+roleID+"&date="+date+"&reason="+reason+"&sortType="+sortType+"&order="+order+"&startTime="+startTime+"&endTime="+endTime;
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
	  var startTime=$("#startTime").val();
	  var endTime=$("#endTime").val();
	  window.location.href="battleLog.do?action=init&roleID="+roleID+"&date="+date+"&reason="+reason+"&sortType="+sortType+"&order="+order+"&startTime="+startTime+"&endTime="+endTime;
	}
</script>
</head>
<body>
<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>  
<%=lang.readGm(GMLangConstants.FIGHT)%><%=lang.readGm(GMLangConstants.LOG)%></div>
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
	onClick="javaScript:window.location.href='export.do?action=export&logType=battle_log'" />
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
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.ROLE_ALLIANCE_TYPE)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.REASON)%></th>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.MAP)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.MAP_X)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.MAP_Y)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.SKILL)%><%=lang.readGm(GMLangConstants.ID)%></th>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.HP_CHANGE)%></th>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.ADDTION)%><%=lang.readGm(GMLangConstants.PARAM)%></th>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.C_PROPERTY)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.WEARING)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.PETINFO)%></th>
		</tr>
     <c:forEach items="${battleLogList}" var="battleLog">
        <tr>
		 <td>&nbsp;${battleLog.id}</td>
         <td>&nbsp;
         <c:forEach items="${logTypes}" var="logType" >
             	<c:if test="${logType.key eq battleLog.logType}"><c:out value="${logType.value}" /></c:if>
         </c:forEach>
         </td>
         <td>&nbsp;${battleLog.formtLogTime}</td>
		 <td>&nbsp;${battleLog.regionId}</td>
         <td>&nbsp;${battleLog.serverId}</td>
 		 <td>&nbsp;<a href="user.do?action=init&searchType=userId&searchValue=${battleLog.accountId}"
					class="link">${battleLog.accountId}</a></td>
		 <td>&nbsp;${battleLog.accountName}</td>
         <td>&nbsp;<a href="role.do?action=init&searchType=roleId&searchValue=${battleLog.charId}"
					class="link">${battleLog.charId}</a></td>
		 <td>&nbsp;${battleLog.charName}</td>
         <td>&nbsp;${battleLog.level}</td>
         <td>&nbsp;
         	<c:choose>
				    <c:when test="${battleLog.jobId eq 0}">
		            	<%=lang.readGm(GMLangConstants.ALLIANCE_GONGCHANGUOJI)%>
		            </c:when>
		            <c:when test="${battleLog.jobId eq 1}">
		           		<%=lang.readGm(GMLangConstants.ALLIANCE_QUANZHENYING)%>
		           	</c:when>
		           	<c:when test="${battleLog.jobId eq 2}">
		            	<%=lang.readGm(GMLangConstants.ALLIANCE_TONGMENTGUO)%>
		            </c:when>
		            <c:when test="${battleLog.jobId eq 4}">
		           		<%=lang.readGm(GMLangConstants.ALLIANCE_ZHOUXINGUO)%>
		           	</c:when>
		           	<c:when test="${battleLog.jobId eq 8}">
		           		<%=lang.readGm(GMLangConstants.ALLIANCE_GONGCHANGUOJI)%>
		           	</c:when>
		           	</c:choose>
         </td>
         <td>&nbsp;
         	<c:forEach items="${logReasons}" var="LogReason" >
             	<c:if test="${LogReason.key eq battleLog.reason}"><c:out value="${LogReason.value}" /><c:set var="canFindReason" value="true"/></c:if>
         	</c:forEach>
			<c:if test="${canFindReason ne true}" >
				<c:out value="${temp}" />
			</c:if>
         </td>
		 <td>&nbsp; 
		 <c:forEach items="${xlsData['maps']}" var="map" >
             <c:if test="${map.key eq battleLog.mapId}"><c:out value="${map.value}" /></c:if>
         </c:forEach>
		 <td>&nbsp;${battleLog.mapX}</td>
         <td>&nbsp;${battleLog.mapY}</td>
         <td>&nbsp;${battleLog.skillId}</td>
         <td>&nbsp;${battleLog.hpChange}</td>
         <td>&nbsp;${battleLog.param}</td>
         <td colspan="3">&nbsp; 
           <input type="button" onclick="javascript:window.open('battleLog.do?action=battleInfo&id=${battleLog.id}&date=${date}','newwindow','width=940px,height=550,top=0,left=0,toolbar=no,menubar=no,scrollbars=yes,resizable=yes,location=no,status=no');" value="<%= lang.readGm(GMLangConstants.VIEW)%>"/>
         </td>
		</tr>
     </c:forEach>
     <tr>
    <td height="30" colspan="19" style="border-bottom: 0px;width: 100%;">
     <div id="num_style"></data></div>
    </td>
  </tr>
   </tbody>
</table>
</body>
</html>