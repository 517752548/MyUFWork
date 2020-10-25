<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<%@ include file="../../../common/taglibs.jsp"%>
<%@ page import="java.lang.String"%>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<script type="text/javascript" src="jslib/jquery.js"></script>
<script type="text/javascript">

   function is_ok(){
		alert("is_ok?");
		var cdkeyPlansId =$.trim($("#cdkeyPlansId").val());
		if( 0 == cdkeyPlansId) {
			alert("<%= lang.readGm(GMLangConstants.CDKEY_PLANS_ID_CAN_NOT_NULL)%>");
			$("#cdkeyPlansId").focus();
			return false;
		}
		
		var worldGiftId = $.trim($("#worldGiftId").val());
		if(0 == worldGiftId){
			alert("<%= lang.readGm(GMLangConstants.CDKEY_GIFT_ID_CAN_NOT_NULL)%>");
			$("#worldGiftId").focus();
			return false;
		}

		return true;
	}
</script>
</head>
<body>

<div id="man_zone">
<div class="topnav">
<a class="link" href="homePage.do?action=welcome"><%=lang.readGm(GMLangConstants.WEL_HOME_PAGE)%></a>>>  
<a class="link" href="cdkeyManager.do?action=init"><%=lang.readGm(GMLangConstants.CDKEY)%></a>>><%=lang.readGm(GMLangConstants.NEW_ADD)%></div>

<form method="post" name="form1" action="cdkeyManager.do?action=addCDKeyGift" onsubmit="return true;">
<table class="detail" style="width:50%;" cellspacing="0" cellpadding="0" border="0">
	<tbody>
		<tr>
			<td colspan="4" class="header"><%=lang.readGm(GMLangConstants.CDKEY)%></td>
		</tr>
        <tr>
			<th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_PLANS_ID)%></th>
			<td colspan="3">
				<select id="cdkeyPlansId" name="cdkeyPlansId">
					<option id="plansOp0" value="0"><%= lang.readGm(GMLangConstants.CDKEY_PLANS_FOR_CHOSE)%></option>
					<c:forEach items="${plansList}" var="plansVo">
						<option id="plansOp${plansVo.id}"  value="${plansVo.cdkeyPlansId}">${plansVo.cdkeyPlansId}</option>
					</c:forEach>
				</select>
			</td>
		</tr>
		<tr>
		 	<th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_GIFT_ID)%></th>
		 	<td colspan="3">
	 			<select id="worldGiftId" name="worldGiftId">
					<option id="giftOp-0" value="0" ><%= lang.readGm(GMLangConstants.CDKEY_PLANS_FOR_CHOSE)%></option>
					<c:forEach items="${giftList}" var="giftVo">
						<option id="giftOp-${giftVo.id}"  value="${giftVo.giftId}">${giftVo.giftId}</option>
					</c:forEach>
				</select>
		 	</td>
		</tr>
		<tr>
		 	<th>&nbsp;<%=lang.readGm(GMLangConstants.CDKEY_CREATE_NUM)%></th>
		 	<td colspan="3" ><input id="createNum" name="createNum" value="${createNum}"/></td>
		</tr>
		<tr>
			<td colspan="4"  class="bottom">
			<input class="butcom" id="submit" type="submit"	value="<%= lang.readGm(GMLangConstants.COMMON_SUBMIT)%>" />
			<span style="padding: 10px;" /></span>
			<input id="reset" type="reset" class="butcom" value="<%= lang.readGm(GMLangConstants.RESET)%>" />
            <span style="padding: 10px;" /></span>
            <input id="return" type="button" class="butcom"	value="<%= lang.readGm(GMLangConstants.RETURN)%>"
              onclick="javaScript:window.location='cdkeyManager.do?action=init';"/>
          
           </td>
		</tr>
	</tbody>
</table>
</form>
</div>

</body>
</html>