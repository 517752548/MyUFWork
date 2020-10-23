<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/logCommon.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>mmo</title>
</head>
<script type="text/javascript">
$().ready(function(){
	//服务器ID
    var sId="${sId}";
	var arr = sId.split(",");
	for(var i=0;i<arr.length;i++){
		var tmp=$.trim(arr[i]);
		$("#sId"+tmp).attr("checked","checked");
	}
	//开启方式
    var openType = "${openType}";
    $("#radio"+openType).attr("checked","checked");

	//选择日期
	var week = "${week}";   
	var arr1 = week.split(",");
	for(var i=0;i<arr1.length;i++){
		var tmp=$.trim(arr1[i]);
		$("#week"+tmp).attr("checked","checked");
	}

	//奖励程度
	var bonus = "${bonus}"; 
	$("#prize"+bonus).attr("selected","selected");
	//npcId
	$("#act3").attr("selected","selected");
	var npcId = "${npcIds}";
	if(npcId!=""){
		$("#act0").attr("selected","selected");
		addActivity();
	}
	var taskId = "${taskIds}";
	if(taskId!=""){
		$("#act1").attr("selected","selected");
		addActivity();
	}
	var expTimes = "${expTimes}";
	if(expTimes!=""){
		$("#act2").attr("selected","selected");
		addActivity();
	}
    var arena = "${arena}";
    if(arena!=""){
        $("#act4").attr("selected","selected");
        addActivity();
    }
	var status = "${status}";
	$("#status"+status).attr("selected","selected");
	if($("#radio0").attr("checked")){
		$("#selBut").attr("checked",true);
		$("#selBut").attr("disabled",true);
		var checks=document.getElementsByName("serverId");
		for(var i=0;i<checks.length;i++){
			checks[i].checked=true;
			checks[i].disabled=true;
		}
	}
	var noticeGlobal="${noticeGlobal}";

	$("#noticeGlobal"+noticeGlobal).attr("selected","selected");
	
	var noticePrediction="${noticePrediction}";

	$("#noticePrediction"+noticePrediction).attr("selected","selected");

	var noticeDisplay="${noticeDisplay}";

	$("#noticeDisplay"+noticeDisplay).attr("selected","selected");
})
</script>
<body>
<c:if test="${fail eq true}">
<script type="text/javascript">
alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
</script>
</c:if>
<c:if test="${activityIdErr eq true}">
	<script type="text/javascript">
		alert("<%=lang.readGm(GMLangConstants.ACT_ID_ECHO)%>");
	</script>
</c:if>
<c:if test="${htmlFail eq true}">
<script type="text/javascript">
alert("<%=lang.readGm(GMLangConstants.CONTENT_NOT_MATCH)%>");
</script>
</c:if>
<div id="man_zone">
<div class="topnav"><span id="show_text"><a
	href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>
<a href="activity.do?action=init">
<%=lang.readGm(GMLangConstants.GAME)%><%=lang.readGm(GMLangConstants.ACTIVITY)%>
</a> >><%=lang.readGm(GMLangConstants.EDIT)%>&nbsp;OR&nbsp;<%=lang.readGm(GMLangConstants.ADD) %>
</span></div>
<div style="clear: both;"></div>
<form id="activity" name="activity" method="post" action="activity.do?action=saveActivity" onsubmit="return is_ok();">
<input id="actId" name="actId" value="${actId}" type="hidden"/>
<input id="serIds" name="serIds" value="${serIds}" type="hidden"/>
<table name='tab_1' class="detail" style="width:70%;" cellspacing="0"
	cellpadding="0" border="0">
	<tbody>
		<tr>
			<th colspan="6"><%=lang.readGm(GMLangConstants.ACTIVITY)%><%=lang.readGm(GMLangConstants.INFO)%></th>
		</tr>
		<tr>
		<td class="label" ><%=lang.readGm(GMLangConstants.OPEN_TYPE)%></td>
		<td colspan="5">
			<input id="radio0" type="radio" name="pattern" value="0" onclick="selPattern(this.value,'serverId')"/><%=lang.readGm(GMLangConstants.ALL_OPEN) %>
			<input id="radio1" type="radio" name="pattern" value="1" checked onclick="selPattern(this.value,'serverId')"/><%=lang.readGm(GMLangConstants.PART_OPEN)%></td>
		</tr>
		<tr>
			<td class="label" ><%= lang.readGm(GMLangConstants.CMD_NSERVER_ALERT)%>
			</td>
			<td colspan="5"><span onclick="selAll('selBut','serverId')" ><input id="selBut"  type="checkbox" />
			<%= lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%></span>
                <c:forEach items="${serverIds}" var="s">
                   	<input id="sId${s}" name="serverId" type="checkbox" value="${s}" />${s}
                </c:forEach>
             </td>
		</tr>
        <tr>
		<td class="label" ><%=lang.readGm(GMLangConstants.ACTIVITY)%><%=lang.readGm(GMLangConstants.ID)%></td>
		<td ><input id="activityId" name="activityId" value="${activityId}"/>
			 <input type="hidden" id="actId" name="actId" value="${activityId}"/>
		</td>
		<td class="label" ><%=lang.readGm(GMLangConstants.ACTIVITY_NAME)%></td>
		<td colspan="3"><input id="activityName" name="activityName" value="${activityName}"/></td>
		</tr>
		<tr>
		<td class="label" ><%=lang.readGm(GMLangConstants.START_DATE)%></td>
		<td><input id="startDate" name="startDate" value="${startDate}"/>
			<img id="startDateImg" src="jslib/jscalendar/img.gif" />		
		</td>
		<td class="label" ><%=lang.readGm(GMLangConstants.END_DATE)%></td>
		<td colspan="3"><input id="endDate" name="endDate" value="${endDate}"/>
			<img id="endDateImg" src="jslib/jscalendar/img.gif" />	
		</td>
		</tr>
		<tr>
		<td class="label" ><%=lang.readGm(GMLangConstants.EVERYDAY)%><%=lang.readGm(GMLangConstants.START_TIME)%></td>
		<td><input id="startTime" name="startTime" value="${startTime}"/>
			<img id="startTimeImg" src="jslib/jscalendar/img.gif" />
			<script type="text/javascript" language="javascript">
				$('#startTimeImg').timepicker({
    			defaultTime: new Date()
				});
			</script>
		</td>
		<td class="label" ><%=lang.readGm(GMLangConstants.EVERYDAY)%><%=lang.readGm(GMLangConstants.END_TIME)%></td>
		<td colspan="3"><input id="endTime" name="endTime" value="${endTime}"/>
			<img id="endTimeImg" src="jslib/jscalendar/img.gif" />
			<script type="text/javascript" language="javascript">
				$('#endTimeImg').timepicker({
				    defaultTime: new Date()
				});
			</script>
		</td>
		</tr>
		<tr>
				<td class="label" ><%=lang.readGm(GMLangConstants.LOW_LEVEL)%></td>
				<td ><input id="lowLevel" name="lowLevel" value="${lowLevel}"/></td>
				<td class="label" ><%=lang.readGm(GMLangConstants.TOP_LEVEL)%></td>
				<td colspan="3"><input id="topLevel" name="topLevel" value="${topLevel}"/></td>
		</tr>
        <tr>
		    <td class="label"><%= lang.readGm(GMLangConstants.ACT_DES)%></td>
			<td colspan="5">
			  <textarea id="content" name="content" rows="5" cols="80">${content}</textarea>
			</td>
		</tr>
		<tr>
		    <td class="label"><%= lang.readGm(GMLangConstants.NOTICE_TEXT)%></td>
			<td colspan="5"><object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0" width="600" height="365">
				  <param name="movie" value="images/demo15.swf">
				  <param name="quality" value="high">
				  <embed src="images/demo15.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="600" height="365"></embed>
			 </object>
			</td>
		</tr>
		<tr>
			<td class="label red"><%= lang.readGm(GMLangConstants.ATTENTIONS)%>:</td>
			<td colspan="5" class="red"><%= lang.readGm(GMLangConstants.LINK_HINT)%></td>
		</tr>
		<tr>
		    <td class="label"><%= lang.readGm(GMLangConstants.EVERYDAY)%><%= lang.readGm(GMLangConstants.ACTIVITY)%></td>
			<td colspan="5">
			 <span onclick="selAll('allWeekBut','week')" ><input id="allWeekBut"  type="checkbox" />
			<%= lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%></span>
				<input id="week1" name="week" type="checkbox" value="1" /><%= lang.readGm(GMLangConstants.MONDAY)%>
				<input id="week2" name="week" type="checkbox" value="2" /><%= lang.readGm(GMLangConstants.TUESDAY) %>
				<input id="week3" name="week" type="checkbox" value=3><%= lang.readGm(GMLangConstants.WEDNESDAY) %>
				<input id="week4" name="week" type="checkbox" value=4><%= lang.readGm(GMLangConstants.THURSDAY) %>
				<input id="week5" name="week" type="checkbox" value=5><%= lang.readGm(GMLangConstants.FRIDAY) %>
				<input id="week6" name="week" type="checkbox" value=6><%= lang.readGm(GMLangConstants.SATURDAY) %>
				<input id="week7" name="week" type="checkbox" value=7><%= lang.readGm(GMLangConstants.SUNDAY) %>
			</td>
		</tr>
		<tr>
		    <td class="label"><%= lang.readGm(GMLangConstants.PRIZE_LEVEL)%></td>
			<td><select name="prizeLevel">
					<option id="prizeS" value="S" selected>S</option>
					<option id="prizeA" value="A">A</option>
					<option id="prizeB" value="B">B</option>
					<option id="prizeC"  value="C">C</option>
					<option id="prizeD" value="D">D</option>
				</select>
			</td>
			<td class="label"><%= lang.readGm(GMLangConstants.OPEN_CLOSE)%></td>
			<td colspan="3">
				<select name="status">
					<option id="status1" value=1 selected><%=lang.readGm(GMLangConstants.OPEN) %></option>
					<option  id="status0"  value=0><%=lang.readGm(GMLangConstants.CLOSE) %></option>
				</select>
			</td>
		</tr>
		<tr>
		<tr>
		    <td class="label"><%= lang.readGm(GMLangConstants.IS_NOTICE)%></td>
			<td><select name="isNotice">
					<option id="noticeGlobal0" value="0" selected><%= lang.readGm(GMLangConstants.NO)%></option>
					<option id="noticeGlobal1" value="1"><%= lang.readGm(GMLangConstants.YES)%></option>
				</select>
			</td>
			<td class="label"><%= lang.readGm(GMLangConstants.IS_FORESHOW)%></td>
			<td>
				<select name="isForeshow">
					<option id="noticePrediction0" value="0"><%=lang.readGm(GMLangConstants.NO) %></option>
					<option id="noticePrediction1" value="1" selected><%=lang.readGm(GMLangConstants.YES) %></option>
				</select>
			</td>
			<td class="label"><%= lang.readGm(GMLangConstants.IS_DISPLAY)%></td>
			<td>
				<select name="isDisplay">
					<option  id="noticeDisplay0" value="0"><%=lang.readGm(GMLangConstants.NO) %></option>
					<option id="noticeDisplay1" value="1" selected><%=lang.readGm(GMLangConstants.YES) %></option>
				</select>
			</td>
		</tr>
		<td class="label" ><%=lang.readGm(GMLangConstants.ACTIVITY_FUNCTION)%></td>
		<td colspan="5"><select id="activityFn" name="activityFn">
					<option id="act0" value=0 selected><%=lang.readGm(GMLangConstants.NPC_HIDDEN_APPEAR) %></option>
					<option id="act1" value=1><%=lang.readGm(GMLangConstants.TASK_HIDDEN_APPEAR) %></option>
					<option id="act2" value=2><%=lang.readGm(GMLangConstants.EXP_BONUS) %></option>
					<option id="act3" value=3><%=lang.readGm(GMLangConstants.NO_CONTENT) %></option>
                    <option id="act4" value="4"><%=lang.readGm(GMLangConstants.ACT_ARENA_PK) %></option>
          </select>
		<img  style="margin-left: 1em;"
				class="pointer link" src="images/1.jpg" title="<%=lang.readGm(GMLangConstants.COMMON_SUBMIT)%>"
				onclick="javaScript:addActivity()" /></td>
		
		</tr>
        <tr id="bottomTr">
			<td colspan="6" class="bottom">
			  <input id="submit" type="submit" value="<%= lang.readGm(GMLangConstants.COMMON_SUBMIT)%>" class="butcom" />
			  <span style="padding: 10px;"/>
			  <input id="coverLink" type="button" value="<%= lang.readGm(GMLangConstants.COVER_LINK)%>" class="butcom" onclick="javaScript:cover();"/>
			  <span style="padding: 10px;"/>
			  <input id="reset" type="reset" value="<%= lang.readGm(GMLangConstants.RESET)%>"  class="butcom"/>
			<span
				style="padding: 10px;" /><input id="return" type="button" class="butcom"
				value="<%= lang.readGm(GMLangConstants.RETURN)%>"  onclick="javaScript:window.location='activity.do?action=init';"/>
            </td>
		</tr>
	</tbody>
</table>
</form>
</div>
<script type="text/javascript" language="javascript">
Calendar.setup(
	    {
	      inputField  : "startDate",         // ID of the input field
	      ifFormat    :  "%Y-%m-%d",       // format of the input field
	      showsTime   :  true,
	      timeFormat  :  "24",
	      button      : "startDateImg"    // ID of the button
	    }
	  );
Calendar.setup(
	    {
	      inputField  : "endDate",         // ID of the input field
	      ifFormat    :  "%Y-%m-%d",       // format of the input field
	      showsTime   :  true,
	      timeFormat  :  "24",
	      button      : "endDateImg"     // ID of the button
	    }
	  );
function is_ok(){
	//选择服务器
	var ser_cont = 0;
	var sIds="";
    $("input[name='serverId']").each(function(){
		var s_checked= $(this).attr("checked");
		if(s_checked){
			sIds+=$(this).val()+",";
			ser_cont=+1;
		}
      });
    sIds=sIds.substr(0,sIds.length-1);
    $("#serIds").val(sIds);
    if(ser_cont==0){
    	alert("<%= lang.readGm(GMLangConstants.CMD_NSERVER_ALERT)%>");
    	return false;
     }
	//活动ID
     if(!validActId()){
    	 return false;
     }
     
	//活动名
     if(!validActName()){
    	 return false;
     }

     //开始日期	
     if(!validStartDate()){
    	 return false;
     }
	 
   	 //结束日期   
     if(!validEndDate()){
    	 return false;
     }
	 
     //每日开始时间
     if(!validStartTime()){
    	 return false;
     }

	//每日结束时间
    if(!validEndTime()){
   	 	return false;
    }
	
	
	//最低等级限制
    if(!validLowLevel()){
   	 	return false;
    }

	//最高等级限制
    if(!validTopLevel()){
   	 	return false;
    }
    
    
  	//活动内容 
    if(!validDes()){
   	 	return false;
    }
    //taskId
	 var activityFn1 = $("#activityFn1").attr("id");
	 if(activityFn1=="activityFn1"){
		 if(!taskCheck()){
			 return false;
		 }
	 }
	
	//npcId
	 var activityFn0 = $("#activityFn0").attr("id");
	 if(activityFn0=="activityFn0"){
		 if(!npcCheck()){
			 return false;
		 }
	 }
	//expTimes
	 var activityFn2 = $("#activityFn2").attr("id");
	 if(activityFn2=="activityFn2"){
		 if(!expTimesCheck()){
			 return false;
		 }
	 }
	 //异步数据校验
	if(!asynDataCheck()){
		return false;
	}
    return true;
}

function cover(){
	var content= $.trim($("#content").val());
	if(is_null(content)==true){
		alert('<%= lang.readGm(GMLangConstants.CONTENT_NOT_NULL)%>');
		$("#content").focus();
		return false;
	}
	$.post("gameNotice.do?action=coverLink",{content:content},function(info){
		$("#content").val(info);
	})
} 
function selPattern(value,name){
	var pattern=document.getElementsByName("pattern");
	if(value==0){
		var checks=document.getElementsByName(name);
		$("#selBut").attr("checked",true);
		$("#selBut").attr("disabled",true);
		for(var i=0;i<checks.length;i++){
			checks[i].checked=true;
			checks[i].disabled=true;
		}
	}
	else if(value==1){
		$("#selBut").attr("checked",false);
		$("#selBut").attr("disabled",false);
		var checks=document.getElementsByName(name);
		for(var i=0;i<checks.length;i++){
			checks[i].checked=false;
			checks[i].disabled=false;
		}
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
function addActivity(){
	var value=$("#activityFn").val();
	var trObject = $("#activityFn"+value).attr("id");
	if(trObject=="activityFn"+value){
       return false;
	}
	if(value==0){
		var html ="<tr id='activityFn0'><td class='label'><%=lang.readGm(GMLangConstants.NPC)%>(<%=lang.readGm(GMLangConstants.NPC_HINT)%>)</td><td> <input id='npcId' name='npcId' value='${npcIds}'/><img  style='margin-left: 1em;'"
		+ "class='pointer link' src='images/3.jpg' title='<%=lang.readGm(GMLangConstants.COMMON_DELETE)%>' onclick='javaScript:plusActivity(0);' /></td><td colspan='4'>&nbsp;${npcs}</td></tr>";
        $("#bottomTr").before(html);
	}else if(value==1){
		var html ="<tr id='activityFn1'><td class='label'><%=lang.readGm(GMLangConstants.ACT_TASK)%>(<%=lang.readGm(GMLangConstants.ACT_TASK_HINT)%>)</td><td> <input id='taskId' name='taskId' value='${taskIds}'/><img  style='margin-left: 1em;'"
			+ "class='pointer link' src='images/3.jpg' title='<%=lang.readGm(GMLangConstants.COMMON_DELETE)%>' onclick='javaScript:plusActivity(1);'/></td><td colspan='4'>&nbsp;${tasks}</td></tr>";
	        $("#bottomTr").before(html);
	}else if(value==2){
		var html ="<tr id='activityFn2'><td class='label'><%=lang.readGm(GMLangConstants.ACT_EXP)%>(<%=lang.readGm(GMLangConstants.ACT_EXP_HINT)%>)</td><td> <input id='expTimes' name='expTimes' value='${expTimes}'/><img  style='margin-left: 1em;'"
			+ "class='pointer link' src='images/3.jpg' title='<%=lang.readGm(GMLangConstants.COMMON_DELETE)%>' onclick='javaScript:plusActivity(2);'/></td><td colspan='4'>&nbsp;当前经验倍数${expTimes}</td></tr>";
	        $("#bottomTr").before(html);
	}else if(value==4){
        var html ="<tr id='activityFn4'><td class='label'><%=lang.readGm(GMLangConstants.ACT_ARENA_PK)%>(<%=lang.readGm(GMLangConstants.ACT_ARENA_PK_PARAM)%>)</td><td> <input id='arena' name='arena' value='${arena}'/><img  style='margin-left: 1em;'"
            + "class='pointer link' src='images/3.jpg' title='<%=lang.readGm(GMLangConstants.COMMON_DELETE)%>' onclick='javaScript:plusActivity(4);'/></td><td colspan='4'>&nbsp;${arena}</td></tr>";
            $("#bottomTr").before(html);
    }
}
function plusActivity(id){
	var obj ="activityFn"+id;
   $("#"+obj).remove();
}

//npc ID 检查
function npcCheck(){
	var npcId = $.trim($("#npcId").val());
	if(is_null(npcId)==true){
		alert('<%= lang.readGm(GMLangConstants.NPCID_NOT_NULL)%>');
		$("#npcId").focus();
		return false;
	}
	var npcArray = new Array();
	var arr=npcId.split(",");
	var isOk = true;
	for(var i=0;i<arr.length;i++){
		var tmp=$.trim(arr[i]);
		if(is_num(tmp)==false){
			isOk = false;
			alert('<%=lang.readGm(GMLangConstants.NPC_FORM_WRONG) %>');
			break;
		}
		if(isContain(npcArray.toString(),tmp)){
			alert(tmp+":<%= lang.readGm(GMLangConstants.ECHO)%>");
			isOk = false;
			break;
		}
	
		npcArray.push(tmp);
	}	
	return isOk;
}

// task ID 检查
function taskCheck(){
	var taskId = $.trim($("#taskId").val());
	if(is_null(taskId)==true){
		alert('<%= lang.readGm(GMLangConstants.TASKID_NOT_NULL)%>');
		$("#taskId").focus();
		return false;
	}
	var taskArray = new Array();
	var arr=taskId.split(",");
	var isOk = true;
	for(var i=0;i<arr.length;i++){
		var tmp=$.trim(arr[i]);
		if(is_num(tmp)==false){
			isOk = false;
			alert('<%=lang.readGm(GMLangConstants.TASK_FORM_WRONG) %>');
			break;
		}
		if(isContain(taskArray.toString(),tmp)){
			alert(tmp+":<%= lang.readGm(GMLangConstants.ECHO)%>");
			isOk = false;
			break;
		}
		taskArray.push(tmp);
	}	
	return isOk;
}
//doubleEXP times 检查
function expTimesCheck(){
	var expTimes = $.trim($("#expTimes").val());
	if(is_null(expTimes)==true){
		alert('<%= lang.readGm(GMLangConstants.EXP_TIMES_NOT_NULL)%>');
		$("#expTimes").focus();
		return false;
	}
	if(is_int(expTimes)==false){
		alert('<%= lang.readGm(GMLangConstants.ACT_EXP_HINT)%>');
		$("#expTimes").focus();
		return false;
	}
	//if(parsrInt(expTimes)<2){
	//	alert('<%= lang.readGm(GMLangConstants.ACT_EXP_HINT)%>');
	//	$("#expTimes").focus();
	//	return false;
	//}
	return true;
}


//校验活动ID
function validActId(){
    var activityId = $.trim($("#activityId").val());
    if(is_null(activityId)==true){
		alert('<%= lang.readGm(GMLangConstants.ACTIVITYID_NOT_NULL)%>');
		$("#activityId").focus();
		return false;
	}
    if(is_int(activityId)==false){
		alert('<%= lang.readGm(GMLangConstants.ACTIVITYID_ID_IS_INT)%>');
		$("#activityId").focus();
		return false;
	}
    if(activityId.length>9){
		alert('<%= lang.readGm(GMLangConstants.TOO_LONG)%>');
		$("#activityId").focus();
		return false;
	}
    return true;
}

//校验活动名称
function validActName(){
	var activityName = $.trim($("#activityName").val());
	 if(is_null(activityName)==true){
			alert('<%= lang.readGm(GMLangConstants.ACTIVITYNAME_NOT_NULL)%>');
			$("#activityName").focus();
			return false;
	}
	 var l=0;
	 var a = activityName.split("");
	 for(var i=0;i<a.length;i++){
		if(a[i].charCodeAt(0)<299){
			l++;
		}else{
			l+=2;
		}
	  }	
	 if(l>20){
			alert('<%=lang.readGm(GMLangConstants.ACTIVITY_NANE_LESSFIFTY) %>');
			return false;
	}	
    return true;
}

//校验开始日期
function validStartDate(){
	var startDate = $.trim($("#startDate").val());
	if(is_null(startDate)==true){
		alert('<%= lang.readGm(GMLangConstants.STARTDATE_NOT_NULL)%>');
		$("#startDate").focus();
		return false;
	}
	if(validDate(startDate)==false){
		alert('<%= lang.readGm(GMLangConstants.STARTDATE_NOT_CORRECT)%>');
		$("#startDate").focus();
		return false;
	}
	return true;
}

//校验结束日期
function validEndDate(){
	var endDate = $.trim($("#endDate").val());
	var startDate = $.trim($("#startDate").val());
	if(is_null(endDate)==true){
		alert('<%= lang.readGm(GMLangConstants.ENDDATE_NOT_NULL)%>');
		$("#endDate").focus();
		return false;
	}
	if(validDate(endDate)==false){
		alert('<%= lang.readGm(GMLangConstants.ENDDATE_NOT_CORRECT)%>');
		$("#endDate").focus();
		return false;
	}
	if(endDate<startDate){
		alert('<%= lang.readGm(GMLangConstants.ENDDATE_MORE_STARTDATE)%>');
		$("#endDate").focus();
		return false;
	}
	return true;
}

//每日开始时间
function validStartTime(){
	var startTime = $.trim($("#startTime").val());
	if(is_null(startTime)==true){
		alert('<%= lang.readGm(GMLangConstants.STARTTIME_NOT_NULL)%>');
		$("#startTime").focus();
		return false;
	}
	if(validTime(startTime)==false){
		alert('<%= lang.readGm(GMLangConstants.STARTTTIME_NOT_CORRECT)%>');
		$("#startTime").focus();
		return false;
	}
	return true;
}
//每日结束时间
function validEndTime(){
	var startTime = $.trim($("#startTime").val());
	var endTime = $.trim($("#endTime").val());
	if(is_null(endTime)==true){
		alert('<%= lang.readGm(GMLangConstants.ENDTIME_NOT_NULL)%>');
		$("#endTime").focus();
		return false;
	}
	if(validTime(endTime)==false){
		alert('<%= lang.readGm(GMLangConstants.ENDTTIME_NOT_CORRECT)%>');
		$("#endTime").focus();
		return false;
	}
	if(endTime<=startTime){
		alert('<%= lang.readGm(GMLangConstants.END_MORE_START)%>');
		$("#endTime").focus();
		return false;
	}
	return true;
}
//最高等级限制
function validTopLevel(){
	var topLevel = $.trim($("#topLevel").val());
	var lowLevel = $.trim($("#lowLevel").val());
	if((is_null(lowLevel)==true)&&(is_null(topLevel)==true)){
		return true;
	}
	if(is_null(topLevel)==true){
		alert('<%= lang.readGm(GMLangConstants.TOPLEVEL_NOT_NULL)%>');
		$("#topLevel").focus();
		return false;
	}
	if(is_int0(topLevel)==false){
		alert('<%= lang.readGm(GMLangConstants.LEVEL_ID_IS_INT)%>');
		$("#topLevel").focus();
		return false;
	}
	topLevel = parseInt(topLevel);
	lowLevel = parseInt(lowLevel);
	if(topLevel<0){
		alert('<%= lang.readGm(GMLangConstants.LOWLEVEL_MORE_THAN_0)%>');
		$("#topLevel").focus();
		return false;
	}
	if(topLevel>100){
		alert('<%= lang.readGm(GMLangConstants.TOPLEVEL_LESS_THAN_100)%>');
		$("#topLevel").focus();
		return false;
	}
	if(lowLevel>=topLevel){
		alert('<%= lang.readGm(GMLangConstants.TOPLEVEL_MORE_LOWLEVEL)%>');
		$("#lowLevel").focus();
		return false;
	}
	return true;
}
//最低等级限制
function validLowLevel(){
	var lowLevel = $.trim($("#lowLevel").val());
	var topLevel = $.trim($("#topLevel").val());
	if((is_null(lowLevel)==true)&&(is_null(topLevel)==true)){
		return true;
	}
	if(is_null(lowLevel)==true){
		alert('<%= lang.readGm(GMLangConstants.LOWLEVEL_NOT_NULL)%>');
		$("#lowLevel").focus();
		return false;
	}
	topLevel = parseInt(topLevel);
	lowLevel = parseInt(lowLevel);
	if(is_int0(lowLevel)==false){
		alert('<%= lang.readGm(GMLangConstants.LEVEL_ID_IS_INT)%>');
		$("#lowLevel").focus();
		return false;
	}
	if(lowLevel<0){
		alert('<%= lang.readGm(GMLangConstants.LOWLEVEL_MORE_THAN_0)%>');
		$("#lowLevel").focus();
		return false;
	}
	if(lowLevel>100){
		alert('<%= lang.readGm(GMLangConstants.TOPLEVEL_LESS_THAN_100)%>');
		$("#lowLevel").focus();
		return false;
	}
	return true;
}

//活动介绍
function validDes(){
	var content = $.trim($("#content").val());
	if(is_null(content)==true){
		alert('<%= lang.readGm(GMLangConstants.ACT_DES_NOT_NULL)%>');
		$("#content").focus();
		return false;
	}
	if(content.length>500){
		alert('<%= lang.readGm(GMLangConstants.ACTCONTENT_IS_LONG)%>');
		$("#content").focus();
		return false;
	}
	return true;
}
//校验异步数据
function asynDataCheck(){
	 var taskId ="";
	 var npcId ="";
	 var expTimes = "";
	 var actId = "";
     var arena = "";
     var activityFn4 = $("#activityFn4").attr("id");
     if(activityFn4=="activityFn4"){
         arena = $.trim($("#arena").val());
     }
	 var activityFn2 = $("#activityFn2").attr("id");
	 if(activityFn2=="activityFn2"){
		 expTimes = $.trim($("#expTimes").val());
	 }
	 var activityFn1 = $("#activityFn1").attr("id");
	 if(activityFn1=="activityFn1"){
		 taskId = $.trim($("#taskId").val());
	 }
	 var activityFn0 = $("#activityFn0").attr("id");
	 if(activityFn0=="activityFn0"){
		 npcId = $.trim($("#npcId").val());
	  }	
	 var content = $.trim($("#content").val());
	 var activityId = $.trim($("#activityId").val());
	 actId = $.trim($("#actId").val());
	 var flag = true;
	 $.ajaxSettings.async= false;
	 $.post("activity.do?action=checkData",{expTimes:expTimes,taskId:taskId,npcId:npcId,content:content,activityId:activityId,actId:actId,arena:arena},function(info){
		 info = $.trim(info);
		 if(info!="ok"){
			 alert(info);
			 flag = false;
		 }
	 });
	$.ajaxSettings.async= true;
	return flag;
}
</script>
</body>
</html>