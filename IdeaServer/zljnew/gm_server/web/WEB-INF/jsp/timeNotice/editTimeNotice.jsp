<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
<script type="text/javascript" src="jslib/jquery_for_editor.js"></script>
<script type="text/javascript" src="jslib/xheditor-zh-cn.js"></script>
<script type="text/javascript">
$().ready(function(){
	//开启方式
    var openType = "${openType}";
    $("#radio"+openType).attr("checked","checked");
    if($("#radio0").attr("checked")){
		$("#selBut").attr("checked",true);
		$("#selBut").attr("disabled",true);
		var checks=document.getElementsByName("serverId");
		for(var i=0;i<checks.length;i++){
			checks[i].checked=true;
			checks[i].disabled=true;
		}
	}else if($("#radio1").attr("checked")){
		var checks=document.getElementsByName("serverId");
		for(var i=0;i<checks.length;i++){
			checks[i].checked=false;
			checks[i].disabled=false;
		}
		//服务器ID
	    var sId="${sId}";
		var arr = sId.split(",");
		for(var i=0;i<arr.length;i++){
			var tmp=$.trim(arr[i]);
			$("#sId"+tmp).attr("checked","checked");
		}
	}

  	//公告子类型
    var subType = "${subType}";
    $("#tRadio"+subType).attr("checked","checked");
});
   function selectAll(){
	   var sel=$("#selBut").attr("checked");
	   if(sel){
         $("input[name='serverId']").each(function(){
			$(this).attr("checked",true);
          });
	   }else{
		   $("input[name='serverId']").each(function(){
				$(this).attr("checked",false);
	       });
	  }
   }
   function selPattern(value,name){
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
   function cover(){
		var content= $.trim($("#content").val());
		if(is_null(content)==true){
			alert('<%=lang.readGm(GMLangConstants.CONTENT_NOT_NULL)%>');
			$("#content").focus();
			return false;
		}
		$.post("gameNotice.do?action=coverLink",{content:content},function(info){
			$("#content").val(info);

			
		})
	}
	function showLinkTmpl() {
		var obj ="linkTmpl";
		for(var i=1;i<4;i++){
			$("#"+obj+i).remove();
		}
		 var value=$("#linkTmpl").val();
		if(value==0){
			
		}else if(value==1){
			var html ="<tr id='linkTmpl1'><td class='label'><%=lang.readGm(GMLangConstants.ITEM_ID)%></td><td> <input id='itemId' name='itemId' value=''/>"
				+ "<%=lang.readGm(GMLangConstants.ITEM_NAME)%><input id='itemName' name='itemName' value=''/></td>"
				+ "<td class='label'><%=lang.readGm(GMLangConstants.QUALITY)%></td><td> <select id='itemColor'>" 
                + "<option id='quality1' value='FFFFFF' selected><%=lang.readGm(GMLangConstants.ITEM_QUALITY_WHITE)%></option>"
                + "<option id='quality2' value='01FE0D'><%=lang.readGm(GMLangConstants.ITEM_QUALITY_GREEN)%></option>"
                + "<option id='quality3' value='1C8BFD'><%=lang.readGm(GMLangConstants.ITEM_QUALITY_BLUE)%></option>"
                + "<option id='quality4' value='974EFB'><%=lang.readGm(GMLangConstants.ITEM_QUALITY_PURPLE)%></option>"
                + "<option id='quality5' value='F76221'><%=lang.readGm(GMLangConstants.ITEM_QUALITY_ORANGE)%></option>"
           		+ "</select></td></tr>";
			
			$("#bottomTr").before(html);
		}else if(value==2){
			var html ="<tr id='linkTmpl2'><td class='label'><%=lang.readGm(GMLangConstants.MAIN_PANEL)%></td><td><select id='mainPanel'>" 
                + "<option id='panel1' value='60'><%=lang.readGm(GMLangConstants.MAIN_PANEL_NOTICE)%></option>"
                + "<option id='panel2' value='46'><%=lang.readGm(GMLangConstants.MAIN_PANEL_XINFA)%></option>"
                + "<option id='panel3' value='4'><%=lang.readGm(GMLangConstants.MAIN_PANEL_SKILL)%></option>"
                + "<option id='panel4' value='42'><%=lang.readGm(GMLangConstants.MAIN_PANEL_TITLE)%></option>"
                + "<option id='panel5' value='23'><%=lang.readGm(GMLangConstants.MAIN_PANEL_PRODUCE)%></option>"
           		+ "</select></td><td class='label'><%=lang.readGm(GMLangConstants.SUB_PANEL)%></td><td> <input type='text' id='subPanel' name='subPanel' value='' size='2'/>"
           		+ "<%=lang.readGm(GMLangConstants.PANEL_NAME)%><input id='panelName' name='panelName' value=''/></td></tr>";
			$("#bottomTr").before(html);
		}else if(value==3){
			var html ="<tr id='linkTmpl3'><td class='label'><%=lang.readGm(GMLangConstants.WEB_ADDRESS)%></td><td> <input type='text' id='webAddress' name='webAddress' value='http://' size='35'/></td>"
				     + "<td class='label'><%=lang.readGm(GMLangConstants.WEB_ADDRESS_NAME)%></td><td> <input type='text' id='webAddressName' name='webAddressName' value='' size='30'/></td></tr>";
			$("#bottomTr").before(html);
		}
	}
	function createLinkTmpl(){
		 var value=$("#linkTmpl").val();
			if(value==0){
				alert('<%=lang.readGm(GMLangConstants.CONTENT_NOT_NULL)%>');
			}else if(value==1){
				//物品模板
				var itemId = $.trim($("#itemId").val());
				if(is_null(itemId)==true){
					alert('<%=lang.readGm(GMLangConstants.ITEM_ID_NOT_NULL)%>');
					$("#itemId").focus();
					return false;
				}
				var itemName = $.trim($("#itemName").val());
				if(is_null(itemName)==true){
					alert('<%=lang.readGm(GMLangConstants.PARAM_NOT_NULL)%>');
					$("#itemName").focus();
					return false;
				}
				var itemQuality =$.trim($("#itemColor").val());
				if(is_null(itemQuality)==true){
					return false;
				}
				var linkTmpl = "[Link item='model:-1,3," + itemId + "," + itemName + ",#" + itemQuality + "'][/Link]";
				var flag = true;
				 $.ajaxSettings.async= false;
				 $.post("timeNotice.do?action=checkData",{content:"",itemId:itemId},function(info){
					 info = $.trim(info);
					 if(info!="ok"){
						 alert(info);
					 }else{
						 $("#help").val(linkTmpl);
					 }
				 });
			}else if(value==2){
				//面板模板
				var mainPanel = $.trim($("#mainPanel").val());
				if(is_null(mainPanel)==true){
					return false;
				}
				var subPanel = $.trim($("#subPanel").val());
				if(is_null(subPanel)==true){
					subPanel=-1;
				}
				if(is_num(subPanel)==false){
					alert('Error type!');
					$("#subPanel").focus();
					return false;
				}
				var panelName =$.trim($("#panelName").val());
				if(is_null(panelName)==true){
					alert('<%=lang.readGm(GMLangConstants.PARAM_NOT_NULL)%>');
					return false;
				}
				var linkTmpl = "[Link href='event:gm," + mainPanel + "," + subPanel + "'][u]" + panelName + "[/u][/Link]";
				$("#help").val(linkTmpl);
			}else if(value==3){
				//链接模板
				var webAddress = $.trim($("#webAddress").val());
				if(is_null(webAddress)==true){
					alert('<%=lang.readGm(GMLangConstants.PARAM_NOT_NULL)%>');
					$("#webAddress").focus();
					return false;
				}
				var webAddressName = $.trim($("#webAddressName").val());
				if(is_null(webAddressName)==true){
					alert('<%=lang.readGm(GMLangConstants.PARAM_NOT_NULL)%>');
					$("#webAddressName").focus();
					return false;
				}
				var linkTmpl = "[Link href='event:" + webAddress + "'][u]" + webAddressName + "[/u][/Link]";
				$("#help").val(linkTmpl);
			}
	}
	function is_ok(){
		//校验开始时间
		var startTime = $.trim($("#startTime").val());
		if(is_null(startTime)==true){
			alert('<%=lang.readGm(GMLangConstants.STARTTIME_NOT_NULL)%>');
			$("#startTime").focus();
			return false;
		}
		if(validDateTime(startTime)==false){
			alert('<%=lang.readGm(GMLangConstants.STARTTTIME_NOT_CORRECT)%>');
			$("#startTime").focus();
			return false;
		}

		var endTime = $.trim($("#endTime").val());
		//校验结束时间
		if(is_null(endTime)==true){
			alert('<%=lang.readGm(GMLangConstants.ENDTIME_NOT_NULL)%>');
			$("#endTime").focus();
			return false;
		}
		if(validDateTime(endTime)==false){
			alert('<%=lang.readGm(GMLangConstants.ENDTTIME_NOT_CORRECT)%>');
			$("#endTime").focus();
			return false;
		}
		
		if(endTime<=startTime){
			alert('<%=lang.readGm(GMLangConstants.END_MORE_START)%>');
			$("#endTime").focus();
			return false;
		}
		//校验间隔时间
		var intervalTime = $.trim($("#intervalTime").val());
		if(is_null(intervalTime)==true){
			alert('<%=lang.readGm(GMLangConstants.INTERVAL_NOT_NULL)%>');
			$("#intervalTime").focus();
			return false;
		}
		if(is_int(intervalTime)==false){
			alert('<%=lang.readGm(GMLangConstants.INTERVAL_NOT_NEG)%>');
			$("#intervalTime").focus();
			return false;
		}
		if(intervalTime.length>9){
			alert('<%=lang.readGm(GMLangConstants.TOO_LONG)%>');
			$("#intervalTime").focus();
			return false;
		}

		//选择服务器
		var ser_cont = 0;
		var sIds="";
	    $("input[name='sId']").each(function(){
			var s_checked= $(this).attr("checked");
			if(s_checked){
				sIds+=$(this).val()+",";
				ser_cont=+1;
			}
	      });
	    sIds=sIds.substr(0,sIds.length-1);
	    $("#serIds").val(sIds);
	    if(ser_cont==0){
	    	alert("<%=lang.readGm(GMLangConstants.CMD_NSERVER_ALERT)%>");
	    	return false;
	     }
	  
	    //校验操作人
	    var operator = $.trim($("#operator").val());
	    if(is_null(operator)==true){
			alert('<%=lang.readGm(GMLangConstants.OPERATOR_NOT_NULL)%>');
			$("#operator").focus();
			return false;
		}
	    //校验内容
	    var content = $.trim($("#content").val());
		if(is_null(content)==true){
			alert('<%=lang.readGm(GMLangConstants.CONTENT_NOT_NULL)%>');
			$("#content").focus();
			return false;
		}
		if(content.length>${noticeLen}){
			alert('<%=lang.readGm(GMLangConstants.CONTENT_IS_LONG)%>');
			$("#content").focus();
			return false;
		}
		
		var flag = true;
		 $.ajaxSettings.async= false;
		 $.post("timeNotice.do?action=checkData",{content:content,itemId:-1},function(info){
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
</head>
<body>
<c:if test="${fail eq true}">
<script type="text/javascript">
alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
</script>
</c:if>
<c:if test="${htmlFail eq true}">
<script type="text/javascript">
alert("<%=lang.readGm(GMLangConstants.CONTENT_NOT_MATCH)%>");
</script>
</c:if>
<div id="man_zone">
<div id="nav">
<ul>
	<li id="man_nav_1" class="bg_image_onclick"><%=lang.readGm(GMLangConstants.NOTICE)%><%=lang.readGm(GMLangConstants.MANAGE)%>
	</li>
</ul>
</div>
<div id="sub_info">&nbsp;&nbsp;<img src="images/hi.gif" />&nbsp;<span id="show_text"><a
	href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>
<c:if test="${type eq 0}">
<%=lang.readGm(GMLangConstants.WEL_TIME_NOTICE)%>
</c:if>
<c:if test="${type eq 1}">
<%=lang.readGm(GMLangConstants.WEL_CHAT_TIME_NOTICE)%>
</c:if>
</a> >><%=lang.readGm(GMLangConstants.EDIT)%>&nbsp;OR&nbsp;<%=lang.readGm(GMLangConstants.ADD)%>
</span></div>
<div class="nofloat" />
<form id="timeNotice" name="timeNotice" method="post" action="timeNotice.do?action=saveTimeNotice&id=${id}&type=${type}" onsubmit="return is_ok();">
<input id="serIds" name="serIds" value="${serIds}" type="hidden"/>
<table name='tab_1' class="detail" style="width:62%;" cellspacing="0"
	cellpadding="0" border="0">
	<tbody>
		<c:if test="${type eq 1}">
			<tr>
				<th colspan="4"><%=lang.readGm(GMLangConstants.NOTICE_TYPE)%></th>
			</tr>
			<tr>
				<td class="label"><%=lang.readGm(GMLangConstants.SELECT_NOTICE_TYPE)%>
				</td>
				<td>
					<input id="tRadio0" type="radio" name="subType" value="0" checked
						onclick="" /><%=lang.readGm(GMLangConstants.NOTICE_TYPE_NOTICE)%>
					<input id="tRadio1" type="radio" name="subType" value="1"
						onclick="" /><%=lang.readGm(GMLangConstants.NOTICE_TYPE_GM)%>
					<input id="tRadio2" type="radio" name="subType" value="2"
						onclick="" /><%=lang.readGm(GMLangConstants.NOTICE_TYPE_NPC)%>
					<input id="tRadio3" type="radio" name="subType" value="3" 
						onclick="" /><%=lang.readGm(GMLangConstants.NOTICE_TYPE_OTHER)%>
                </td>
			</tr>
		</c:if>
		<tr>
			<th colspan="4"><%=lang.readGm(GMLangConstants.NOTICE)%><%=lang.readGm(GMLangConstants.INFO)%></th>
		</tr>
		<tr>
			<td class="label" ><%=lang.readGm(GMLangConstants.START_TIME)%></td>
			<td>
            <input id="startTime" name="startTime" type="text" value="${fn:substring(startTime,0,19)}"/>
            <img id="startTimeImg" src="jslib/jscalendar/img.gif" /></td>
			<td class="label"><%=lang.readGm(GMLangConstants.END_TIME)%></td>
			<td><input id="endTime" name="endTime" type="text" value="${fn:substring(endTime,0,19)}"/> <img
				id="endTimeImg" src="jslib/jscalendar/img.gif" /></td>
		</tr>
		<tr>
			<td class="label" ><%=lang.readGm(GMLangConstants.ECHO)%><%=lang.readGm(GMLangConstants.INTERVAL)%>
			(<%=lang.readGm(GMLangConstants.SECOND)%>)</td>
			<td><input id="intervalTime" name="interval" type="text" value="${interval}" /></td>
			<td class="label" ><%=lang.readGm(GMLangConstants.OPEN_TYPE)%></td>
			<td>
			<input id="radio0" type="radio" name="pattern" value="0" checked onclick="selPattern(this.value,'serverId')"/><%=lang.readGm(GMLangConstants.ALL_OPEN)%>
		</tr>
		</tr>
		<tr>
			<td class="label"><%=lang.readGm(GMLangConstants.CMD_NSERVER_ALERT)%>
			</td>
			<td><span onclick="selectAll()" >
                <!--2012-04-23 <c:forEach items="${serverIds}" var="s">
					<input id="sId${s}" name="serverId" type="checkbox" checked value="${s}" />${s}
                </c:forEach>
             -->
             <c:forEach items="${serverIds}" var="s">
			   <input id="sId" name="sId" type="checkbox" value="${s.id}"/>
				${s.dbServerName}
                </c:forEach> 
             </td>
			<td class="label"><%=lang.readGm(GMLangConstants.OPERATOR)%></td>
			<td><input type="text" id="operator" name="operator" value="${operator}" /></td>
		</tr>
		<tr>
		    <td class="label"><%=lang.readGm(GMLangConstants.CONTENT)%></td>
			<td colspan="3">
			  <textarea id="content" name="content" rows="10" cols="80">${content}</textarea>
			</td>
		</tr>

		<c:if test="${type eq 0}">
			<tr>
				<td class="label"><%=lang.readGm(GMLangConstants.NOTICE_TEXT)%></td>
				<td colspan="3"><object
					classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"
					codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
					width="600" height="365">
					<param name="movie" value="images/demo15.swf">
					<param name="quality" value="high">
					<embed src="images/demo15.swf" quality="high"
						pluginspage="http://www.macromedia.com/go/getflashplayer"
						type="application/x-shockwave-flash" width="600" height="365"></embed>
				</object></td>
			</tr>
			<tr>
				<td class="label red"><%=lang.readGm(GMLangConstants.ATTENTIONS)%>:</td>
				<td class="red" colspan="3"><%=lang.readGm(GMLangConstants.LINK_HINT)%></td>
			</tr>
		</c:if>
		<c:if test="${type eq 1}">
			<tr>
				<td class="label"><%=lang.readGm(GMLangConstants.CHAT_NOTICE_TEXT)%></td>
				<td colspan="3">
				<select id="linkTmpl" onchange="showLinkTmpl()">
                    <option id="null" value="0"/>
					<option id="item" value="1"><%=lang.readGm(GMLangConstants.NOTICE_PANEL_TYPE_ITEM)%></option>
					<option id="panel" value="2"><%=lang.readGm(GMLangConstants.NOTICE_PANEL_TYPE_PANEL)%></option>
					<option id="address" value="3"><%=lang.readGm(GMLangConstants.NOTICE_PANEL_TYPE_HREF)%></option>
				</select>
				<input id="createLink" type="button" value="<%= lang.readGm(GMLangConstants.PRODUCE_LINK_TMPL)%>" class="butcom" onclick="javaScript:createLinkTmpl();"/></td>
			</tr>
			<tr id="bottomTr">
				<td class="label"><%=lang.readGm(GMLangConstants.NOTICE_TEXT)%></td>
				<td colspan="3"><textarea id="help" name="help" rows="3"
					cols="80"></textarea></td>
			</tr>
		</c:if>

		<tr>
			<td colspan="4"  class="bottom">
			  <input id="submit" type="submit" value="<%=lang.readGm(GMLangConstants.COMMON_SUBMIT)%>" class="butcom" />
			  <span style="padding: 10px;"/>
			  <input id="coverLink" type="button" value="<%= lang.readGm(GMLangConstants.COVER_LINK)%>" class="butcom" onclick="javaScript:cover();"/>
			  <span style="padding: 10px;"/>
			  <input id="reset" type="reset" value="<%=lang.readGm(GMLangConstants.RESET)%>" class="butcom"/>
            <span
				style="padding: 10px;" /><input id="return" type="button" class="butcom"
				value="<%=lang.readGm(GMLangConstants.RETURN)%>"  onclick="javaScript:window.location='timeNotice.do?action=init&type=${type}';"/>
			</td>
		</tr>
	</tbody>
</table>
</form>
</div>
<script type="text/javascript">
Calendar.setup(
	    {
	      inputField  : "startTime",         // ID of the input field
	      ifFormat    :  "%Y-%m-%d %H:%M:%S",       // format of the input field
	      showsTime   :  true,
	      timeFormat  :  "24",
	      button      : "startTimeImg"    // ID of the button
	    }
	  );
Calendar.setup(
	    {
	      inputField  : "endTime",         // ID of the input field
	      ifFormat    : "%Y-%m-%d %H:%M:%S",       // format of the input field
	      showsTime   :  true,
	      timeFormat  :  "24",
	      button      : "endTimeImg"     // ID of the button
	    }
	  );
</script>
</body>
</html>