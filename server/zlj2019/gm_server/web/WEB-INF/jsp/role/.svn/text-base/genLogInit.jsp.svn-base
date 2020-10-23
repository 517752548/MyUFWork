<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/logCommon.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>mop</title>
<script type="text/javascript">
$().ready(function(){
	$("input[name='logType']:first").attr("checked",true);
});
</script>
<script type="text/javascript">
function searchLog(){
	var id=$("input[name='logType']:checked").attr("id");
	var date = $("#date").val();
	window.location="basicLog.do?action=init&date="+date+"&roleID=${roleId}"+"&logType="+id;

	return;
	switch(id){
	  case '502':
			window.location="basicLog.do?action=init&date="+date+"&roleID=${roleId}"+"&logType=item_log";
			break;
	  case '503':
			window.location="basicLog.do?action=init&date="+date+"&roleID=${roleId}"+"&logType=money_log";
			break;
	  case '510':
			window.location="basicLog.do?action=init&date="+date+"&roleID=${roleId}"+"&logType=task_log";
			break;
	  case '515':
			window.location="basicLog.do?action=init&date="+date+"&roleID=${roleId}"+"&logType=snap_log";
			break;
	  case '529':
			window.location="basicLog.do?action=init&date="+date+"&roleID=${roleId}"+"&logType=level_log";
			break;
	  case '530':
			window.location="basicLog.do?action=init&date="+date+"&roleID=${roleId}"+"&logType=camp_log";
			break;
	  case '535':
			window.location="basicLog.do?action=init&date="+date+"&roleID=${roleId}"+"&logType=grain_log";
			break;
	  case '536':
			window.location="basicLog.do?action=init&date="+date+"&roleID=${roleId}"+"&logType=prestige_log";
			break;
	  case '537':
			window.location="basicLog.do?action=init&date="+date+"&roleID=${roleId}"+"&logType=exploit_log";
			break;
	  case '538':
			window.location="basicLog.do?action=init&date="+date+"&roleID=${roleId}"+"&logType=gm_command_log";
			break;
	  case '539':
			window.location="basicLog.do?action=init&date="+date+"&roleID=${roleId}"+"&logType=basic_player_log";
			break;
	  case '541':
			window.location="basicLog.do?action=init&date="+date+"&roleID=${roleId}"+"&logType=pet_log";
			break;
	  case '542':
			window.location="basicLog.do?action=init&date="+date+"&roleID=${roleId}"+"&logType=mail_log";
			break;
	  case '543':
			window.location="basicLog.do?action=init&date="+date+"&roleID=${roleId}"+"&logType=guild_log";
			break;
	  case '544':
			window.location="basicLog.do?action=init&date="+date+"&roleID=${roleId}"+"&logType=prize_log";
			break;
	  case '545':
			window.location="basicLog.do?action=init&date="+date+"&roleID=${roleId}"+"&logType=battle_log";
			break;
	}
	}	
</script>
</head>
<body>
<form  method="post" action="genLog.do?action=genLog"
	onsubmit="return is_ok()">
<div id="man_zone">

<div class="topnav">
<a href="homePage.do?action=welcome"><%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %></a>&gt;&gt;
<%= lang.readGm(GMLangConstants.GAME_LOG) %>&gt;&gt;
<a  href="role.do?action=init" class="link"><%=lang.readGm(GMLangConstants.ROLE_MANAGE)%></a>&gt;&gt;
<%= lang.readGm(GMLangConstants.ROLE_LOGS) %>
</div>

<div id="nav">
<ul>
    <li id="man_nav_1"
		class="bg_image_onclick"><%=lang.readGm(GMLangConstants.ROLE_LOGS)%></li>
</ul>
</div>

<div id="sub_info">
	<span id="show_text">&nbsp;&nbsp;
		<%=lang.readGm(GMLangConstants.DATE)%>: <input
					id="date" type="text" class="limitWidth" value="${date}" /> <img
					id="dateImg" src="jslib/jscalendar/img.gif" /> <script
					type="text/javascript" language="javascript">
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
			button :"dateImg" // ID of the button
		});
	</script>&nbsp;&nbsp;
	<input id="search" class="butcom" type="button"  style="margin-left: 1em;" value="<%= lang.readGm(GMLangConstants.COMMON_SEARCH)%>" onClick="javascript:searchLog();"/>
</span>
</div>

<table id='tab_1' class="detail no_bottom" cellspacing="0" cellpadding="0"
	border="0" >
	<tbody>
		<tr>
			<th colSpan="5"><%=lang.readGm(GMLangConstants.ROLE_LOGS)%></th>
		</tr>
    <c:forEach items="${logTypeMap}" var="logType" varStatus="count" begin="0">
	<c:if test="${count.index%5 eq 0}"><tr align="left"></c:if>
<td>&nbsp;&nbsp;<input  id="${logType.key}" value="${logType.key}"  name="logType" type="radio">${logType.value}
		</td>
    <c:if test="${count.index%5 eq 4}"></tr></c:if>
    <c:if test="${(count.last) and (count.index%5 lt 4)}"></tr></c:if>
    </c:forEach>
    </tbody>
</table>
</div>
</form>
</body>
</html>