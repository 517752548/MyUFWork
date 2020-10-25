<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/logCommon.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title></title>
</head>

<body>
<script type="text/javascript" charset="UTF-8">

function goTo(i){
	  var openId = $("#openId").val();
	  var reason=$("#reason").val();
	  var date = $("#date").val();
	  var startTime=$("#startTime").val();
	  var endTime=$("#endTime").val();
	  window.location.href="cdkeyManager.do?action=init&currentPage="+i+"&openId="+openId+"&reason="+reason+"&startTime="+startTime+"&endTime="+endTime+"&date="+date;	
}
function search(){
	  var activityName = $("#activityName").val();
	  var date = $("#date").val();
	  if(is_null(activityName) && is_null(date)) {
		  alert("<%=lang.readGm(GMLangConstants.CDKEY_SEARCH_BY_ACT_NAME_OR_DATE_CAN_NOT_NULL)%>");
		  return;
	  }
	  window.location.href="cdkeyManager.do?action=searchByActivityNameOrDate&activityName="+activityName+"&date="+date;	
}
function del(id){
	  var con= confirm("<%=lang.readGm(GMLangConstants.CONFRIM_DEL)%>?");
		if(con){
			var currentPage = $("#curPage").val();
			var date = $("#date").val();
			var startTime=$("#startTime").val();
			var endTime=$("#endTime").val();
			$.post("cdkeyManager.do?action=delUserPrize",{id:id},function(){
		        alert("<%=lang.readGm(GMLangConstants.DEL_SUCCESS)%>");
		        window.location="cdkeyManager.do?action=init&currentPage="+currentPage+"&startTime="+startTime+"&endTime="+endTime+"&date="+date;	
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
				$.post("cdkeyManager.do?action=delUserPrize",{ids:ids},function(){
			        alert("<%=lang.readGm(GMLangConstants.DEL_SUCCESS)%>");
			        window.location="cdkeyManager.do?action=init&currentPage="+currentPage+"&startTime="+startTime+"&endTime="+endTime+"&date="+date;	
				});	
			}
	}
  
  function delCDKey(plansId,giftId,groupId){
	var con= confirm("<%=lang.readGm(GMLangConstants.CONFRIM_DEL)%>?");
	if(con){
		$.post("cdkeyManager.do?action=delCDKey&plansId="+plansId+"&giftId="+giftId+"&groupId="+groupId
				,function(){alert("<%=lang.readGm(GMLangConstants.DEL_SUCCESS)%>");
		       window.location="cdkeyManager.do?action=init";
		});	
 	 }
  }
	
  function exportCDKey(plansId,giftId,groupId){
	  $.ajaxSettings.async= false;
		 $.post("cdkeyManager.do?action=doExport&plansId="+plansId+"&giftId="+giftId+"&groupId="+groupId,function(info){
			 info = $.trim(info);
			 if(info!="ok"){
				 alert(info);
			 }else
			 {
				var download = $("#download");
				download.attr("disabled",false);
				download.attr("class", "butcom");
				alert("<%=lang.readGm(GMLangConstants.DOWNLOAD_FILE_HINT)%>");
			 }
		 });
		$.ajaxSettings.async= true;
  }
  
</script>

<div id="man_zone">
	<div class="topnav">
		<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>><%=lang.readGm(GMLangConstants.CDKEY)%> 
	</div>
			
<div id="sub_info">
	<input id="download" name="download" type="button" style="margin-left: 1em;"
		value="<%=lang.readGm(GMLangConstants.DOWNLOAD)%>"
		onclick="javaScript:window.location='result.xls'" disabled="disabled"/>
</div>
<div>
	<p>
		<br></br>
	</p>
	&nbsp;&nbsp;<font color="#FF0000"><%=lang.readGm(GMLangConstants.CDKEY_EXPORT_DES)%></font>
</div>
<table class="detail" cellspacing="0" cellpadding="0" border="0" width="60%" >
	<tbody>
		<tr>
         <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_PLANS_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_GIFT_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_GROUP_ID)%></th>
		 <th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_OPERATOR_GM_ID)%></th>
		 <c:if test="${DBType eq 1}">
         	<th>&nbsp;<%=lang.readGm(GMLangConstants.COMMON_OPERATION)%>
			<img class="pointer" title="<%=lang.readGm(GMLangConstants.NEW_ADD)%>" src="images/add.gif" onclick="javaScript:window.location='cdkeyManager.do?action=createView'"/>	
		 	&nbsp;
			</th>
		</c:if>
		</tr>
    	<c:forEach items="${cdkeylist}" var="cdkeyVo">
        <tr>
		 <td>&nbsp;${cdkeyVo.plansId}</td>
		 <td>&nbsp;${cdkeyVo.giftId}</td>
         <td>&nbsp;${cdkeyVo.groupId}</td>
         <td>&nbsp;${cdkeyVo.gmId}</td>
		 <c:if test="${DBType eq 1}">
			 <td> 
				<img class="pointer" title="<%=lang.readGm(GMLangConstants.COMMON_DELETE)%>" 
				src="images/b_drop.png" onclick="javaScript:delCDKey('${cdkeyVo.plansId}','${cdkeyVo.giftId}','${cdkeyVo.groupId}');"/>
				<input id="export" type="button" style="margin-left: 1em;"
					value="<%=lang.readGm(GMLangConstants.EXPORT)%>"
					onClick="javaScript:exportCDKey('${cdkeyVo.plansId}','${cdkeyVo.giftId}','${cdkeyVo.groupId}');" />
	         </td>
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