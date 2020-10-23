<%@ include file="logCommon.jsp"%>

<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<title></title>
		<script type="text/javascript">
			Request = {
					QueryString : function(key){
					var svalue = window.location.search.match(new RegExp("[\?\&]"+key+"=([^\&]*)(\&?)","i"));
					return svalue ? svalue[1] : svalue;
				}
				};
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
				   if("${isMoney}"=="true"){
				   if("${moneyType}"==""){
					   $("#moption-1").attr("selected","selected");
				   }else{
					   $("#moption${moneyType}").attr("selected","selected");
				   }
				   }
				   if("${isPrize}"=="true"){
				   if("${awardType}"==""){
					   $("#aoption-1").attr("selected","selected");
				   }else{
					   $("#aoption${awardType}").attr("selected","selected");
				   }
				   }
				   if("${isTreasure}"=="true"){
				   if("${treasurePrizeType}"==""){
					   $("#toption-1").attr("selected","selected");
				   }else{
					   $("#toption${treasurePrizeType}").attr("selected","selected");
				   }
				   }
				   if("${isGM}"=="true"){
				   if("${accountType}"==""){
					   $("#pri-1").attr("selected","selected");
				   }else{
					   $("#pri${treasurePrizeType}").attr("selected","selected");
				   }
				   }
				   if("${isChat}"=="true"){
					   if("${scope}"==""){
						   $("#soption-1").attr("selected","selected");
					   }else{
						   $("#soption${scope}").attr("selected","selected");
					   }
				   }
			   });
		</script>
	</head>
	
	<body>
		<div id="man_zone">
			<div class="topnav"><a class="link"
				href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>&gt;&gt;
				<%= lang.readGm(GMLangConstants.GAME_LOG) %>&gt;&gt;
			<%=lang.readGm((Integer) m.get("LogType").get((String)request.getAttribute("logType")))%>
			</div>
			<div id="nav">
				<ul>
					<li id="man_nav_1" class="bg_image_onclick"><%=lang.readGm(GMLangConstants.ROLE_ID)%>
					</li>
				</ul>
			</div>
			<div id="sub_info">
				&nbsp;&nbsp;
				<input id="roleID" type="text"
				class="limitWidth" value="${roleID}" />&nbsp;&nbsp; 
				
				<span><%=lang.readGm(GMLangConstants.DATE)%>：
				<input id="date" type="text" class="limitWidth" value="${date}" /> 
				<img id="dateImg" src="jslib/jscalendar/img.gif" /> <script
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
				      button   : "dateImg"     // ID of the button
				    }
			    );
				</script>
			</span>&nbsp;&nbsp;
			
			<span><%=lang.readGm(GMLangConstants.REASON)%>：</span> 
			<select id="reason">
				<option id="option-1" value="-1"><%=lang.readGm(GMLangConstants.REASON_ALL)%></option>
				<c:forEach items="${logReasons}" var="_logType" varStatus="count" begin="0">
					<option id="option${_logType.key}" value="${_logType.key}">[${_logType.key}]${_logType.value}</option>
				</c:forEach>
			</select> 
			
			</logparam>&nbsp;&nbsp;
			
			<span><%=lang.readGm(GMLangConstants.START_TIME)%>：<input
				id="startTime" name="startTime" value="${startTime}" class="time_gap" />
			<img id="startTimeImg" src="jslib/jscalendar/img.gif" /> <script
				type="text/javascript" language="javascript">
			$('#startTimeImg').timepicker({
			    defaultTime: new Date()
			});
			</script> 
			</span>&nbsp;&nbsp;
			
			<span><%=lang.readGm(GMLangConstants.END_TIME)%>：<input id="endTime"
				name="endTime" value="${endTime}" class="time_gap" /> <img
				id="endTimeImg" src="jslib/jscalendar/img.gif" /> <script
				type="text/javascript" language="javascript">
			$('#endTimeImg').timepicker({
			    defaultTime: new Date()
			});
			</script> 
			</span>&nbsp;&nbsp; 
			
			<input id="search" type="button" class="butcom" style="margin-left: 1em;"
				value="<%=lang.readGm(GMLangConstants.COMMON_SEARCH)%>"
				onClick="javaScript:search();" />&nbsp;&nbsp;  
				
			<input id="export" type="button" class="butcom" style="margin-left: 1em;"
				value="<%=lang.readGm(GMLangConstants.EXPORT)%>"
				onClick="javaScript:window.location.href='export.do?action=export&logType=${logType}'" />
			</div>
		</div>