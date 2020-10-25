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
	//服务器ID
    var sId="${sId}";
	var arr = sId.split(",");
	for(var i=0;i<arr.length;i++){
		var tmp=$.trim(arr[i]);
		$("#sId"+tmp).attr("checked","checked");
	}
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
<a href="gameNotice.do?action=init">
<%=lang.readGm(GMLangConstants.GAME)%><%=lang.readGm(GMLangConstants.NOTICE)%>
</a> >><%=lang.readGm(GMLangConstants.EDIT)%>&nbsp;OR&nbsp;<%=lang.readGm(GMLangConstants.ADD) %>
</span></div>
<div style="clear: both;"></div>
<form id="timeNotice" name="timeNotice" method="post" action="gameNotice.do?action=saveGameNotice&id=${id}" onsubmit="return is_ok();">
<input id="serIds" name="serIds" value="${serIds}" type="hidden"/>
<table name='tab_1' class="detail" style="width:70%;" cellspacing="0"
	cellpadding="0" border="0">
	<tbody>
		<tr>
			<th colspan="2"><%=lang.readGm(GMLangConstants.NOTICE)%><%=lang.readGm(GMLangConstants.INFO)%>
			<input id="download"
	name="download" type="button" style="margin-left: 1em;"
	value="<%=lang.readGm(GMLangConstants.VIEW)%>"
	onclick="javaScript:window.location='game_notice.txt?t='+ new Date().getTime()" class="butcom" /> 
			</th>
		</tr>
		
		<tr>
		    <td class="label"><%= lang.readGm(GMLangConstants.EDIT_NOTICE)%></td>
			<td >
			  <textarea id="content" name="content" rows="10" cols="70">${content}</textarea>
			</td>
		</tr>
		
        
        <tr>
			<td class="label red" ><%= lang.readGm(GMLangConstants.ATTENTIONS)%>:</td>
			<td><%= lang.readGm(GMLangConstants.LINK_HINT)%></td>
		</tr>

        <tr>
			<td colspan="2" class="bottom">
			  <input id="submit" type="submit" value="<%= lang.readGm(GMLangConstants.COMMON_SUBMIT)%>" class="butcom"/>
			  <span style="padding: 10px;"/>
			  <input id="coverLink" type="button" value="<%= lang.readGm(GMLangConstants.COVER_LINK)%>" class="butcom" onclick="javaScript:cover();"/>
			  <span style="padding: 10px;"/>	
			  <input id="reset" type="reset" value="<%= lang.readGm(GMLangConstants.RESET)%>" class="butcom"/>
			<span
				style="padding: 10px;" /><input id="return" type="button" class="butcom"
				value="<%= lang.readGm(GMLangConstants.RETURN)%>"  onclick="javaScript:window.location='gameNotice.do?action=init';"/>
			</td>
		</tr>
	</tbody>
</table>
</form>
</div>
<script type="text/javascript" language="javascript">
function is_ok(){
/*
	var content= $.trim($("#content").val());
	if(is_null(content)==true){
		alert('<%= lang.readGm(GMLangConstants.CONTENT_NOT_NULL)%>');
		$("#content").focus();
		return false;
	}
	if(content.length>${noticeLen}){
		alert('<%= lang.readGm(GMLangConstants.CONTENT_IS_LONG)%>');
		$("#content").focus();
		return false;
	}

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
	
    var flag = true;
	 $.ajaxSettings.async= false;
	 $.post("gameNotice.do?action=checkData",{content:content},function(info){
		 info = $.trim(info);
		 if(info!="ok"){
			 alert(info);
			 flag = false;
		 }
	 });
	$.ajaxSettings.async= true;
	*/
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
</script>
</body>
</html>