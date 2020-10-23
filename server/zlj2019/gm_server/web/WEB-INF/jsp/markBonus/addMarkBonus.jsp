<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<title>Insert title here</title>
<script type="text/javascript" src="jslib/jquery.js"></script>
<script type="text/javascript">
$().ready(function(){
	   if("${currency}"==""){
		   $("#option0").attr("selected","selected");
	   }else{
		   $("#option${currency}").attr("selected","selected");
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

<c:choose>
 <c:when test="${res eq 'failure'}">
		<script type="text/javascript">
			alert("<%=lang.readGm(GMLangConstants.CMDFAILED)%>");
		</script>
 </c:when>
 <c:when test="${res eq ''}">
		<script type="text/javascript">
			alert("<%=lang.readGm(GMLangConstants.CMDSUCCESS)%>");
			window.location="markBonus.do?action=init";
		</script>
 </c:when>
  <c:when test="${idRepeat eq true}">
		<script type="text/javascript">
			alert("<%=lang.readGm(GMLangConstants.PASSPORTID_REPEAT)%>:${res}");
			window.location="markBonus.do?action=init";
		</script>
 </c:when>
</c:choose>





<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>  
<a class="link" href="markBonus.do?action=init"><%=lang.readGm(GMLangConstants.MARK_BONUS)%></a>>><%=lang.readGm(GMLangConstants.NEW_ADD)%></div>
<div style="clear: both;"></div>
<form  method="post" name="form1"
	action="markBonus.do?action=addMarkBonus" onsubmit="return is_ok();">
<input id="days" type="hidden"  value="${validDays}"/>
<table name='tab_1' class="detail" style="width:50%;" cellspacing="0"
	cellpadding="0" border="0">
	<tbody>
		<tr>
			<td colspan="4" class="header"><%=lang.readGm(GMLangConstants.MARK_BONUS)%></td>
		</tr>
        <tr>
			<td class="label"><%= lang.readGm(GMLangConstants.BONUS_INFO_FMT)%></td>
			<td colspan="3"><textarea id="passportIds" cols="50" rows="5" name="passportIds">${passportIds}</textarea></td>
		</tr>
		<tr>
			<td class="label"><%= lang.readGm(GMLangConstants.GOLDEN_BONUS)%>ID:
			</td>
			<td><input id="goldenBonusId" name="goldenBonusId" value="${goldenBonusId}"/></td>
			<td class="label"><%= lang.readGm(GMLangConstants.VALID_DAYS)%></td>
			<td><input id="goldenValidDays" name="goldenValidDays" value="${goldenValidDays}"/></td>
		</tr>
		<tr>
			<td class="label"><%= lang.readGm(GMLangConstants.SILVER_BONUS)%>ID:
			</td>
			<td><input id="silverBonusId" name="silverBonusId" value="${silverBonusId}"/></td>
			<td class="label"><%= lang.readGm(GMLangConstants.VALID_DAYS)%></td>
			<td><input id="silverValidDays" name="silverValidDays" value="${silverValidDays}"/></td>
		</tr>
		<tr>
			<td colspan="4"  class="bottom"><input class="butcom"
				id="submit" type="submit"
				value="<%= lang.readGm(GMLangConstants.COMMON_SUBMIT)%>" /> <span
				style="padding: 10px;" /><input id="reset" type="reset" class="butcom"
				value="<%= lang.readGm(GMLangConstants.RESET)%>" />
            <span
				style="padding: 10px;" /><input id="return" type="button" class="butcom"
				value="<%= lang.readGm(GMLangConstants.RETURN)%>"  onclick="javaScript:window.location='markBonus.do?action=init';"/>
           </td>
		</tr>
	</tbody>
</table>
</form>
</div>
<script type="text/javascript">
function is_ok(){
	var passportIds =$.trim($("#passportIds").val());
	if(is_null(passportIds)==true){
		alert("<%= lang.readGm(GMLangConstants.USERID_NOT_NULL)%>");
		return false;
	}else{
		var pattern=/^([0-9;]+)$/;
		if(!pattern.test(passportIds)){
			alert("<%= lang.readGm(GMLangConstants.USERID_WRONG)%>");
			return false;
		}
	}
	var goldenBonusId=$.trim($("#goldenBonusId").val());
	if(is_null(goldenBonusId)==false){
		var pattern=/^([0-9]+)$/;
		if(!pattern.test(goldenBonusId)){
			alert("<%= lang.readGm(GMLangConstants.GOLDEN_BONUS)%><%= lang.readGm(GMLangConstants.FMT_WRONG)%>");
			return false;
		}
		var goldenValidDays = $.trim($("#goldenValidDays").val());
		if(!pattern.test(goldenValidDays)){
			alert("<%= lang.readGm(GMLangConstants.GOLDEN_BONUS)%><%= lang.readGm(GMLangConstants.VALID_DAYS)%><%= lang.readGm(GMLangConstants.VALID_NUM)%>");
			return false;
		}
		var days = $.trim($("#days").val());
		if(parseInt(goldenValidDays)>parseInt(days)){
			alert("<%= lang.readGm(GMLangConstants.GOLDEN_BONUS)%><%= lang.readGm(GMLangConstants.VALID_DAYS)%>>${validDays}<%= lang.readGm(GMLangConstants.DAY)%>");
			return false;
		}
	}
	var silverBonusId=$.trim($('#silverBonusId').val());
	if(is_null(silverBonusId)== false){
		var pattern=/^([0-9]+)$/;
		if(!pattern.test(silverBonusId)){
			alert("<%= lang.readGm(GMLangConstants.SILVER_BONUS)%><%= lang.readGm(GMLangConstants.FMT_WRONG)%>");
			return false;
		}
		var silverValidDays = $.trim($("#silverValidDays").val());
		if(!pattern.test(silverValidDays)){
			alert("<%= lang.readGm(GMLangConstants.SILVER_BONUS)%><%= lang.readGm(GMLangConstants.VALID_DAYS)%><%= lang.readGm(GMLangConstants.VALID_NUM)%>");
			return false;
		}
		var days = $.trim($("#days").val());
		if(parseInt(silverValidDays)>parseInt(days)){
			alert("<%= lang.readGm(GMLangConstants.SILVER_BONUS)%><%= lang.readGm(GMLangConstants.VALID_DAYS)%>>${validDays}<%= lang.readGm(GMLangConstants.DAY)%>");
			return false;
		}
	}
	return true;
}
</script>
</body>
</html>