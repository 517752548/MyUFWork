<%@ page language="java" contentType="text/html; charset=UTF-8"
    pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<%@ page import="java.lang.String"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<link rel="stylesheet" type="text/css"
	href="jslib/jsTimePicker/timepicker.css" />
<script type="text/javascript" src="jslib/jsTimePicker/timepicker.js"></script>
<title>Insert title here</title>
<script type="text/javascript">

</script>
</head>
<body>
<form action="mobileActivity.do?action=startPresetActivity" method="post">
<div id="man_zone">
<div class="topnav">
<%= lang.readGm(GMLangConstants.WEL_HOME_PAGE) %>>><%= lang.readGm(GMLangConstants.PRESET_ACTIVITY) %>
</div>
<br/>
<c:choose>
<c:when test="${error_msg ne null}">
<span id="error_msg" class="error_msg">${error_msg}</span>
</c:when>
</c:choose>

<br/>
<div class="nofloat">
<table name='tab_1' class="detail" style="width:50%;" cellspacing="0" cellpadding="0" border="0">
	<tr>
		<td class="header" colspan="2">
			<%= lang.readGm(GMLangConstants.PRESET_ACTIVITY) %>
		</td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_ACTIVY_WEB_NAME)%><%=lang.readGm(GMLangConstants.MOBILE_ACTIVITY_START_TIME)%></td>
		 <td>
         	<span><%=lang.readGm(GMLangConstants.DATE)%>:<input id="dateStart" name="dateStart"type="text" class="limitWidth" value="${mobileActivityShowData.startDate}" /> 
				<img id="dateStartImg" src="jslib/jscalendar/img.gif" /> <script
				type="text/javascript" language="javascript">
			Calendar.setup(
				    {
				      inputField  : "dateStart",         // ID of the input field
				      ifFormat    :  "%Y-%m-%d",       // format of the input field
				      showsTime   :  false,
				      timeFormat  :  "24",
				      onClose  :  function (cal){
				    	          cal.hide();
			                     },
				      button   : "dateStartImg"     // ID of the button
				    }
			    );
				</script>
			</span>&nbsp;&nbsp;	
			
			<span><%=lang.readGm(GMLangConstants.START_TIME)%>：<input
				id="startTime" name="startTime" value="${mobileActivityShowData.startTime}" class="time_gap" />
			<img id="startTimeImg" src="jslib/jscalendar/img.gif" /> <script
				type="text/javascript" language="javascript">
			$('#startTimeImg').timepicker({
			    defaultTime: new Date()
			});
			</script> 
			</span>
         </td>
	</tr>
	<tr>
		<td class="label"><%=lang.readGm(GMLangConstants.COMMON_SERVER)%></td>
		<td>
			<c:forEach items="${serverList}" var="s">
			   <input id="sId" name="sId" type="checkbox" value="${s.id}"/>
				${s.dbServerName}
                </c:forEach> 
		</td>
	</tr>
	 <tr>
		<td colspan="2"><input class="butcom" type="button" id="selectAll" onclick="javascript:hh();"
           value="<%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%><%=lang.readGm(GMLangConstants.COMMON_SERVER)%>"/>
        <input class="butcom" type="submit" onclick="return is_ok();" value="<%=lang.readGm(GMLangConstants.START_PRESET_ACTIVITY)%>"/>
        <input class="butcom" type="button" onclick="goBackAcvitvity();" value="<%=lang.readGm(GMLangConstants.ACTIVITY_WEB_GO_BACK)%>"/>
        </td>
	</tr>
</table>
</div>
</div>
</form>
<script type="text/javascript">
     function goBackAcvitvity(){
      	  window.location.href="mobileActivity.do?action=init";
      }
     function is_ok(){
    	//服务器
  		var svr="";
  		 $("input[name=sId]").each(function(){
                var svrChecked = $(this).attr("checked");
                if(svrChecked==true){
              	  svr+=$(this).val();
                  }
            });
  		if(svr==""){
  			alert('<%=lang.readGm(GMLangConstants.CMD_NSERVER_ALERT)%>');
 			    return false;
 		      }
 		return true;
     }
     function forceEnd(id){
     	  window.location.href="mobileActivity.do?action=forceEndActivity&Id="+id;
     }
     
     function hh(){
         var selAll = $("#selectAll").attr("selAll");
         if(selAll=="false"){
              $("input[name=sId]").each(function(){
                   $(this).attr("checked",false);
                });
              $("#selectAll").attr("selAll","true");
              $("#selectAll").val("<%=lang.readGm(GMLangConstants.COMMON_SElECT_ALL)%><%=lang.readGm(GMLangConstants.COMMON_SERVER)%>");  
          }else{
        	  $("input[name=sId]").each(function(){
                  $(this).attr("checked",true);
               });
        	    $("#selectAll").attr("selAll","false");
        	    $("#selectAll").val("<%=lang.readGm(GMLangConstants.COMMON_SElECT_NONE)%><%=lang.readGm(GMLangConstants.COMMON_SERVER)%>");  
            }
         }
     
     function doAjaxQueryGroupsPrize(){
   	  	var activityTypes = $("#activityType").val();
		$.ajaxSettings.async= false;
		$.post("mobileActivity.do?action=ajaxQueryGroupsPrizes",{activityType:activityTypes},function(info){
			info = $.trim(info);
			$("#activityPrize").val("");
			$("#activityPrize").append(info);
		});
		$.ajaxSettings.async= true;
	}
</script>

</body>
</html>